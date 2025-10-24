using Duende.IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fumbbl.Api
{
    internal class FumbblAuthHandler : DelegatingHandler
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FumbblApi> _logger;
        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private string _accessToken = String.Empty;
        private CancellationTokenSource _accessTokenExpiry = new();

        public FumbblAuthHandler(IConfiguration config, ILogger<FumbblApi> logger) : base()
        {
            _httpClient = new HttpClient();
            _logger = logger;

            _baseUrl = config["Fumbbl:OAuth:base"] ?? string.Empty;
            _clientId = config["Fumbbl:OAuth:client_id"] ?? string.Empty;
            _clientSecret = config["Fumbbl:OAuth:client_secret"] ?? string.Empty;

            _accessTokenExpiry.Cancel();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int maxAuthAttempts = 3;
            while (_accessTokenExpiry.IsCancellationRequested)
            {
                _logger.LogTrace("Getting access token from FUMBBL");
                _accessTokenExpiry.Dispose();
                _accessTokenExpiry = await Authenticate();

                maxAuthAttempts--;
                if (!_accessTokenExpiry.IsCancellationRequested)
                {
                    break;
                }
                else if (maxAuthAttempts < 0)
                {
                    _logger.LogError("Error getting access token from FUMBBL");
                    throw new UnauthorizedAccessException("Unable to authorize with Fumbbl API");
                }
                _logger.LogWarning("Authentication failed, retrying");
                await Task.Delay(200, CancellationToken.None);
            }

            request.SetToken("Bearer", _accessToken);

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<CancellationTokenSource> Authenticate()
        {
            var request = new ClientCredentialsTokenRequest
            {
                Address = _baseUrl + "/oauth/token",
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                ClientCredentialStyle = ClientCredentialStyle.PostBody,
                Method = HttpMethod.Post
            };

            var response = await _httpClient.RequestClientCredentialsTokenAsync(request);

            var tokenSource = new CancellationTokenSource();

            if (!response.IsError)
            {
                _accessToken = response.AccessToken ?? string.Empty;
                tokenSource.CancelAfter(TimeSpan.FromSeconds(response.ExpiresIn - 10));
            }
            else
            {
                tokenSource.Cancel();
            }

            return tokenSource;
        }

    }
}
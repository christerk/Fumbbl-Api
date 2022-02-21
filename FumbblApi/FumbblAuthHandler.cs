using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fumbbl.Api
{
    internal class FumbblAuthHandler : DelegatingHandler
    {
        private HttpClient _httpClient;
        private ILogger<FumbblApi> _logger;
        private string _baseUrl;
        private string _clientId;
        private string _clientSecret;
        private string _accessToken = String.Empty;
        private CancellationTokenSource _accessTokenExpiry = new CancellationTokenSource();

        public FumbblAuthHandler(IConfiguration config, ILogger<FumbblApi> logger) : base()
        {
            _httpClient = new HttpClient();
            _logger = logger;

            _baseUrl = config["Fumbbl:OAuth:base"];
            _clientId = config["Fumbbl:OAuth:client_id"];
            _clientSecret = config["Fumbbl:OAuth:client_secret"];

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
                await Task.Delay(200);
            }

            request.SetToken("Bearer", _accessToken);

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<CancellationTokenSource> Authenticate()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _baseUrl + "/oauth/token",
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                ClientCredentialStyle = ClientCredentialStyle.PostBody,
            });

            var tokenSource = new CancellationTokenSource();

            if (!response.IsError)
            {
                _accessToken = response.AccessToken;
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
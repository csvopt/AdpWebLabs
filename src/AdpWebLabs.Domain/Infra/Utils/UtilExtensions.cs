using Microsoft.Extensions.Configuration;

namespace AdpWebLabs.Domain.Infra.Utils
{
    public class UtilExtensions
    {
        private readonly IConfiguration _configuration;

        public UtilExtensions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetUrl(string key)
        {
            string result;
            try
			{
                result = _configuration.GetSection("URL").Value;
			}
			catch { throw new Exception("URL not found in appSettings"); }

            return result;
        }
    }
}

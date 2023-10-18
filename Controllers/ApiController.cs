using ExampleInject.Infrastructure.AppSettings;
using ExampleInject.Infrastructure.Interfaces;
using System.Web.Http;

namespace ExampleInject.Controllers
{
    [Route("api")]
    public class ApiController : System.Web.Http.ApiController
    {
        private readonly ServiceSettings _serviceSettings;

        public ApiController(IOptions<ServiceSettings> serviceSettings)
        {
            _serviceSettings = serviceSettings.Value;
        }

        // GET api/settings
        public ServiceSettings Get()
        {
            return _serviceSettings;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ExampleInject.Infrastructure.AppSettings
{
    public class ServiceSettings
    {
        [Required]
        public string AppName { get; set; }

        [Required]
        public string AppVersion { get; set; }
    }
}
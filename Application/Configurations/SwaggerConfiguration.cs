using Microsoft.OpenApi.Models;

namespace TodoApiDTO.Configurations
{
    public class SwaggerConfiguration
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public OpenApiInfo OpenApiInfo { get; set; }
    }
}

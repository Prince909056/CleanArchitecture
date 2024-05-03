using Asp.Versioning;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class MvcBuilderService : IWebApplicationBuilderRegistrar
    {
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddEndpointsApiExplorer();
        }
    }
}

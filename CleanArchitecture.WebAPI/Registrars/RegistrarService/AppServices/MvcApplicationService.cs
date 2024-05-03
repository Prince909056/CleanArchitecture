using Asp.Versioning.ApiExplorer;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.AppServices
{
    public class MvcApplicationService : IWebApplicationRegistrar
    {
        public void RegistrarApplicationServices(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }
                await next();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToString());
                }
            });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}

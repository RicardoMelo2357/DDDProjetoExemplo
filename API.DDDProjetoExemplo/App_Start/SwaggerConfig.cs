using System.Web.Http;
using WebActivatorEx;
using API.DDDProjetoExemplo;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace API.DDDProjetoExemplo
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "API.DDDProjetoExemplo");
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}

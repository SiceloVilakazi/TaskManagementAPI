

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Models.ExampleProvider
{
    public class DeletedReasonsDTOExampleProvider : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = GetExample();
        }

        public OpenApiObject GetExample()
        {
            return new OpenApiObject
            {
                ["id"] = new OpenApiInteger(1),
                ["reason"] = new OpenApiString("Task not important")
            };
        }
    }
}

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ExampleProvider
{
    public class GetTaskStatusDTOExampleProvider : ISchemaFilter
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
                ["status"] = new OpenApiString("Pending")
            };
        }
    }
}


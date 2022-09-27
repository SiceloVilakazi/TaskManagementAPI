using Models.ExampleProvider;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    [SwaggerSchemaFilter(typeof(GetTaskStatusDTOExampleProvider))]
    public class GetTaskStatusesDTO
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string status { get; set; } = null!;
    }
}

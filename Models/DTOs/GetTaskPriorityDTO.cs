using Models.ExampleProvider;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    [SwaggerSchemaFilter(typeof(GetTaskPriorityDTOExampleProvider))]
    public class GetTaskPriorityDTO
    {
        /// <summary>
        /// Gets or sets the Id of the task priority
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the priority 
        /// </summary>
        public string priority { get; set; } = null!;
    }
}

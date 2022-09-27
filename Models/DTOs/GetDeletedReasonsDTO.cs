using Models.ExampleProvider;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    [SwaggerSchemaFilter(typeof(DeletedReasonsDTOExampleProvider))]
    public class GetDeletedReasonsDTO
    {
        /// <summary>
        /// Gets or sets the deleted reason Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the deleted reason
        /// </summary>
        public string reason { get; set; } = null!;
    }
}

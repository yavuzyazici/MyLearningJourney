using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.FeatureDtos
{
    public class UIFeatureDto
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Icon { get; set; }
    }
}

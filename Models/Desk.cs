using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public class Desk
    {
        public int DeskId { get; set; }

        [Range(24, 96)]
        public decimal Width { get; set; }

        [Range(12, 48)]
        public decimal Depth { get; set; }

        [Range(0, 7)]
        [Display(Name = "Number Of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // Navigation Properties
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}

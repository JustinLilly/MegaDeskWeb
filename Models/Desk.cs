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

        public decimal Width { get; set; }

        public decimal Depth { get; set; }


        [Display(Name = "Number Of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // Navigation Properties
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}

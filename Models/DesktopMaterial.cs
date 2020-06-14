using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public class DesktopMaterial
    {
        public int DesktopMaterialId { get; set; }

        [Display(Name="Desktop Material")]
        public string DesktopMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}

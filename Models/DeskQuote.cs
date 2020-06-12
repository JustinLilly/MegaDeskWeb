using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MegaDeskWeb.Data;

namespace MegaDeskWeb.Models
{
    public class DeskQuote
    {
        public DeskQuote()
        {
        }

        // Constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        // Properties
        public int DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QuotePrice { get; set; }

        public int DeskId { get; set; }

        [Display(Name = "Delivery Type")]
        public int DeliveryTypeId { get; set; }

        // Navigation properties
        public Desk Desk { get; set; }

        public Delivery DeliveryType { get; set; }

        // Methods
        public decimal GetQuotePrice(MegaDeskWebContext context)
        {
            // Return Value
            decimal quotePrice = BASE_DESK_PRICE;

            // Surface Area
            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;

            // Surface Price
            decimal surfacePrice = 0.00M;
            if (surfaceArea > 1000) {
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_COST;
            }

            // Drawers 
            decimal drawerPrice = this.Desk.NumberOfDrawers * DRAWER_COST;

            // Surface Materials
            decimal surfaceMaterialPrice = 0.00M;
            var surfaceMaterialPrices = context.DesktopMaterial
                .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();

            surfaceMaterialPrice = surfaceMaterialPrices.Cost;

            // Shipping
            decimal shippingPrice = 0.00M;

            var shippingPrices = context.Delivery.Where(d => d.DeliveryId == this.DeliveryTypeId).FirstOrDefault();

            if (surfaceArea < 1000){
                shippingPrice = shippingPrices.PriceUnder1000;    
            } else if (surfaceArea > 1000 && surfaceArea < 2000 ){
                shippingPrice = shippingPrices.PriceBetween1000And2000;
            } else {
                shippingPrice = shippingPrices.PriceOver2000;
            }


            quotePrice += surfacePrice = drawerPrice + surfaceMaterialPrice + shippingPrice;
            return quotePrice;
        }
    }
}

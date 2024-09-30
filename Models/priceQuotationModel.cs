using System.ComponentModel.DataAnnotations;

namespace priceQuotation.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter the subtotal")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal should be greater than zero")]
        public decimal? SubTotal { get; set; }

        [Required(ErrorMessage = "Please enter the discount percent")]
        [Range(0, 100, ErrorMessage = "Discount percent should be between 0 and 100")]
        public decimal? DiscountPercent { get; set; }

        // Method to calculate the discount amount
        public decimal? DiscountAmount()
        {
            // If both SubTotal and DiscountPercent are available and discount value should be between 0 and 100, calculate the discount amount
            if (SubTotal.HasValue && DiscountPercent.HasValue && DiscountPercent.Value > 0 && DiscountPercent.Value <= 100)
            {
                return SubTotal.Value * DiscountPercent.Value / 100;
            }
            return null;
        }

        // Method to calculate the total after discount
        public decimal? Total()
        {
            // Calculate the discount amount first
            decimal? discount = DiscountAmount();

            // If both SubTotal and DiscountAmount are available and discount value should be equal or less than subTotal and subTotal value is greater than zer, calculate the total
            if (SubTotal.HasValue && discount.HasValue && discount.Value <= SubTotal.Value && SubTotal.Value > 0)
            {
                return SubTotal.Value - discount.Value;
            }
            return null;
        }
    }
}

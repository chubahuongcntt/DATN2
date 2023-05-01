using DATN2.Models;

namespace DATN2.ModelViews
{
    public class CartItem
    {
        public Produce produce { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * produce.Discount.Value;    }
}

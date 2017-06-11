using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSuperMarket.Helpers
{
    public class MoneyHelper
    {
        public static string PriceToVND(long price)
        {
            if (price == 0) return "0";

            System.Globalization.CultureInfo elGRs = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            return String.Format(elGRs, "{0:0,0} VNĐ", Convert.ToInt64(price));
        }

        public static int VNDToPrice(string vnd)
        {
            return Convert.ToInt32(vnd
                                    .Replace(",", "")
                                    .Replace(".", "")
                                    .Replace("VNĐ", "")
                                    .Replace("VND", "")
                                    .Replace(" ", ""));
        }
    }
}

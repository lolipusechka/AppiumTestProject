using AppiumFramework.Core.Helpers;

namespace DnsGui.Helpers
{
    public static class CommonHelper
    {
        public static decimal ParsePriceToDecimal(string price)
        {
            var priceStr = price.Replace(" ", "").Replace("₽", "");

            if (decimal.TryParse(priceStr, out var decimalPrice))
            {
                return decimalPrice;
            }
            else
            {
                var badMsg = $"При парсинге цены в decimal произошла ошибка! На вход пришла строка: '{price}'.";

                LogHelper.Error(badMsg);
                throw new Exception(badMsg);
            }
        }
    }
}

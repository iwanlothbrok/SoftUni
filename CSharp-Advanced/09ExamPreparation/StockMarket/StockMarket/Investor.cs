using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;

        public Investor(string fullName, string email, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = email;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            Portfolio.Add(stock);
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest >= stock.PricePerShare) // >= 10000
            {
                // chek if is this
                MoneyToInvest -= stock.PricePerShare;
            }
            else
            {
                Portfolio.Remove(stock);
            }


        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock companyNameToChek = Portfolio.FirstOrDefault(N => N.CompanyName == companyName);
            Stock seelingPriceChek = Portfolio.FirstOrDefault(p => p.PricePerShare < sellPrice);
            if (companyNameToChek == null)
            {
                return $"{companyName} does not exist.";
            }
            if (seelingPriceChek == null)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(companyNameToChek);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            Stock companyNameToChek = Portfolio.FirstOrDefault(N => N.CompanyName == companyName);
            return companyNameToChek;
        }
        public Stock FindBiggestCompany()
        {
            Stock biggestCompany = Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            return biggestCompany;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock items in Portfolio) // var || stock
            {
                sb.AppendLine(items.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}

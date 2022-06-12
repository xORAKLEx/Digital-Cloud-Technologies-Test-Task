using BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Core.Models
{
    public class Asset : IAssets
    {
        public string Asset_id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Website { get; set; }

        public string Ethereum_contract_address { get; set; }

        public decimal Price { get; set; }

        public decimal Volume_24h { get; set; }

        public decimal Change_1h { get; set; }

        public decimal Change_24h { get; set; }

        public decimal Change_7d { get; set; }

        public decimal Total_supply { get; set; }

        public decimal Circulating_supply { get; set; }

        public decimal Max_supply { get; set; }

        public decimal Market_cap { get; set; }

        public decimal Fully_diluted_market_cap { get; set; }

        public string Status { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }
    }
}

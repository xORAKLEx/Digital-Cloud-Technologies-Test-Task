using BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Core.Models
{
    public class Market : IMarket
    {
        public string Exchange_id { get; set; }

        public string Symbol { get; set; }

        public string Base_asset { get; set; }

        public string Quote_asset { get; set; }

        public decimal Price_unconverted { get; set; }

        public decimal Price { get; set; }

        public decimal Change_24h { get; set; }

        public decimal Spread { get; set; }

        public decimal Volume_24h { get; set; }

        public string Status { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.Models
{
    interface IMarket
    {
        string Exchange_id { get; }
        string Symbol { get; }
        string Base_asset { get; }
        string Quote_asset { get; }
        decimal Price_unconverted { get; }
        decimal Price { get; }
        decimal Change_24h { get; }
        decimal Spread { get; }
        decimal Volume_24h { get; }
        string Status { get; }
        string Created_at { get; }
        string Updated_at { get; }
    }
}

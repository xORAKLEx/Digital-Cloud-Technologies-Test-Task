using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.Models
{
    interface IAssets
    {
        string Asset_id { get; }
        string Name { get; }
        string Description { get; }
        string Website { get; }
        decimal Ethereum_contract_address { get; }
        decimal Price { get; }
        decimal Volume_24h { get; }
        decimal Change_1h { get; }
        decimal Change_24h { get; }
        decimal Change_7d { get; }
        string Total_supply { get; }
        string Circulating_supply { get; }
        string Max_supply { get; }
        string Market_cap { get; }
        string Fully_diluted_market_cap { get; }
        string Status { get; }
        string Created_at { get; }
        string Updated_at { get; }
    }
}

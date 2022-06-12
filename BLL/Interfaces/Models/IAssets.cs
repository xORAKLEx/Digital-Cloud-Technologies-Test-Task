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

        string Ethereum_contract_address { get; }

        decimal Price { get; }

        decimal Volume_24h { get; }

        decimal Change_1h { get; }

        decimal Change_24h { get; }

        decimal Change_7d { get; }

        decimal Total_supply { get; }

        decimal Circulating_supply { get; }

        decimal Max_supply { get; }

        decimal Market_cap { get; }

        decimal Fully_diluted_market_cap { get; }

        string Status { get; }

        string Created_at { get; }

        string Updated_at { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Assets
{
     class ListOfValidAssets
    {
        public static List<FungibleAsset> ListOfFungibleAssets { get; } = new List<FungibleAsset> {
            new FungibleAsset("Nafta", "l", 0.50),
            new FungibleAsset("Drvo", "m^3", 7),
            new FungibleAsset("Benzin", "l", 1),
            new FungibleAsset("Bitcoin", "BTC", 17031),
            new FungibleAsset("Etherium", "ETH", 1222),
            new FungibleAsset("Solana", "SOL", 14.06),
            new FungibleAsset("Dogecoin", "Doge", 0.096),
            new FungibleAsset("Terra", "LUNC", 1.62),
            new FungibleAsset("XRP", "XRP", 0.3892),
            new FungibleAsset("Cardano", "ADA", 0.3806)
        };

        public static List<NonFungibleAsset> ListOfNonFungibleAssets { get; } = new List<NonFungibleAsset> {
            new NonFungibleAsset("Kuća 1", 100, ListOfFungibleAssets[3].Address),
            new NonFungibleAsset("Kuća 2", 98, ListOfFungibleAssets[4].Address),
            new NonFungibleAsset("Kuća 3", 56, ListOfFungibleAssets[3].Address),
            new NonFungibleAsset("Slika 1", 7, ListOfFungibleAssets[5].Address),
            new NonFungibleAsset("SLika 2", 5, ListOfFungibleAssets[3].Address),
            new NonFungibleAsset("Slika 3", 52, ListOfFungibleAssets[9].Address),
            new NonFungibleAsset("Slika 4", 12, ListOfFungibleAssets[7].Address),
            new NonFungibleAsset("Sat 1", 41, ListOfFungibleAssets[6].Address),
            new NonFungibleAsset("Sat 2", 72, ListOfFungibleAssets[7].Address),
            new NonFungibleAsset("Sat 3", 43, ListOfFungibleAssets[5].Address),
            new NonFungibleAsset("Sat 4", 55, ListOfFungibleAssets[4].Address),
            new NonFungibleAsset("Sat 5", 59, ListOfFungibleAssets[2].Address),
            new NonFungibleAsset("Auto 1", 26, ListOfFungibleAssets[6].Address),
            new NonFungibleAsset("Auto 2", 34, ListOfFungibleAssets[1].Address),
            new NonFungibleAsset("Auto 3", 105, ListOfFungibleAssets[8].Address),
            new NonFungibleAsset("Motor 1", 206, ListOfFungibleAssets[8].Address),
            new NonFungibleAsset("Motor 2", 157, ListOfFungibleAssets[9].Address),
            new NonFungibleAsset("Motor 3", 96, ListOfFungibleAssets[1].Address),
            new NonFungibleAsset("Motor 4", 30, ListOfFungibleAssets[1].Address),
            new NonFungibleAsset("Motor 5", 49, ListOfFungibleAssets[1].Address)

        };

        public static bool IsAddressFromFungibleAsset(Guid address)
        {
            foreach(var item in ListOfFungibleAssets)
                if (item.Address == address)
                    return true;
            return false;
        }


    }
}

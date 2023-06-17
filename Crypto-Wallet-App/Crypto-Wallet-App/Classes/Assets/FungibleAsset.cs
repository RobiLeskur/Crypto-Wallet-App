using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Assets
{
     class FungibleAsset : Asset
    {
        public string Type { get; set; }
        public FungibleAsset(string nameOfAsset,string typeOfAsset, double valueOfAsset) : base(nameOfAsset, valueOfAsset){ 
            Type = typeOfAsset;

        }
    }
}

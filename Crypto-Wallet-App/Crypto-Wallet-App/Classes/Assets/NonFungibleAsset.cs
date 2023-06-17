using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Assets
{
    
     class NonFungibleAsset
    {
        public Guid adressOfFungibleAssetToWhichItRefers;

        public NonFungibleAsset(string nameOfAsset, double valueOfAsset , Guid anAdressOfFungibleAssetToWhichItRefers) : base(nameOfAsset, valueOfAsset)
        {
            adressOfFungibleAssetToWhichItRefers = anAdressOfFungibleAssetToWhichItRefers;

        }

    }
}

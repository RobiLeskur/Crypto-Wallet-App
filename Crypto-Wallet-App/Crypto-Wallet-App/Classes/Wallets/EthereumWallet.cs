using Crypto_Wallet_App.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
     class EthereumWallet : WalletContainingNonFungibleAssets
    {
        public EthereumWallet(bool isNew) : base(isNew) {

            ListOfSupportedFungibleAssets = new List<Guid>() {
ListOfValidAssets.ListOfFungibleAssets[1].Address,
ListOfValidAssets.ListOfFungibleAssets[3].Address,
ListOfValidAssets.ListOfFungibleAssets[5].Address,
ListOfValidAssets.ListOfFungibleAssets[7].Address,
ListOfValidAssets.ListOfFungibleAssets[8].Address,
ListOfValidAssets.ListOfFungibleAssets[9].Address
            };
            
            ListOfSupportedNonFungibleAssets = new List<Guid>() {
ListOfValidAssets.ListOfNonFungibleAssets[0].Address,
ListOfValidAssets.ListOfNonFungibleAssets[1].Address,
ListOfValidAssets.ListOfNonFungibleAssets[3].Address,
ListOfValidAssets.ListOfNonFungibleAssets[4].Address,
ListOfValidAssets.ListOfNonFungibleAssets[6].Address,
ListOfValidAssets.ListOfNonFungibleAssets[7].Address,
ListOfValidAssets.ListOfNonFungibleAssets[8].Address,
ListOfValidAssets.ListOfNonFungibleAssets[11].Address,
ListOfValidAssets.ListOfNonFungibleAssets[12].Address,
ListOfValidAssets.ListOfNonFungibleAssets[15].Address,
ListOfValidAssets.ListOfNonFungibleAssets[16].Address,
ListOfValidAssets.ListOfNonFungibleAssets[17].Address,
ListOfValidAssets.ListOfNonFungibleAssets[19].Address
};

            if (isNew == false)
            {
                GiveAllSupportedAssetsAValue();
            }

            WalletType = "ETH";
        }



        

    }
}

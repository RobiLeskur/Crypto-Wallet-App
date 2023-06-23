using Crypto_Wallet_App.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
     class SolanaWallet : WalletContainingNonFungibleAssets
    {
        public SolanaWallet(bool isNew) : base(isNew) {

            ListOfSupportedFungibleAssets = new List<Guid>()
            {
ListOfValidAssets.ListOfFungibleAssets[1].Address,
ListOfValidAssets.ListOfFungibleAssets[2].Address,
ListOfValidAssets.ListOfFungibleAssets[5].Address,
ListOfValidAssets.ListOfFungibleAssets[6].Address,
ListOfValidAssets.ListOfFungibleAssets[8].Address,
ListOfValidAssets.ListOfFungibleAssets[9].Address
            };
            
        ListOfSupportedNonFungibleAssets = new List<Guid>()
            {
ListOfValidAssets.ListOfNonFungibleAssets[0].Address,
ListOfValidAssets.ListOfNonFungibleAssets[1].Address,
ListOfValidAssets.ListOfNonFungibleAssets[2].Address,
ListOfValidAssets.ListOfNonFungibleAssets[4].Address,
ListOfValidAssets.ListOfNonFungibleAssets[6].Address,
ListOfValidAssets.ListOfNonFungibleAssets[8].Address,
ListOfValidAssets.ListOfNonFungibleAssets[10].Address,
ListOfValidAssets.ListOfNonFungibleAssets[12].Address,
ListOfValidAssets.ListOfNonFungibleAssets[14].Address,
ListOfValidAssets.ListOfNonFungibleAssets[16].Address,
ListOfValidAssets.ListOfNonFungibleAssets[18].Address,
ListOfValidAssets.ListOfNonFungibleAssets[19].Address
            };

            if (isNew == false)
            {
                GiveAllSupportedAssetsAValue();
            }



            WalletType = "SOL";
        }
  
    }
}

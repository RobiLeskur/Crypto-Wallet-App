using Crypto_Wallet_App.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
    class BitcoinWallet : Wallet
    {
        public BitcoinWallet(bool isNew) : base(isNew) {
            ListOfSupportedFungibleAssets = new List<Guid>
            {
ListOfValidAssets.ListOfFungibleAssets[0].Address,
ListOfValidAssets.ListOfFungibleAssets[3].Address,
ListOfValidAssets.ListOfFungibleAssets[4].Address,
ListOfValidAssets.ListOfFungibleAssets[5].Address,
ListOfValidAssets.ListOfFungibleAssets[7].Address,
ListOfValidAssets.ListOfFungibleAssets[9].Address
            };

            if(isNew == false ) { 
            GiveAllSupportedAssetsAValue();
              }

            WalletType = "BTC";
        }
        

    }
}

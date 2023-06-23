using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
     abstract class Wallet
    {
        public Guid Address { get; }
        public Dictionary<Guid, double> FungibleAssetBalance { get; private set; } = new Dictionary<Guid, double>();
        public List<Guid> ListOfSupportedFungibleAssets { get; set; } = new List<Guid>();
        public List<Guid> ListOfTransactionAddresses { get; private set; } = new List<Guid>();
        public string WalletType { get; set; } = "";

        public bool isNew;

        public Wallet(bool aIsNew) {
            Address = Guid.NewGuid();
            isNew = aIsNew;
        }

        public void GiveAllSupportedAssetsAValue()
        {
            foreach (var item in ListOfSupportedFungibleAssets)
            {
                Random random = new Random();
                FungibleAssetBalance.Add(item, random.NextDouble() * 29 + 1);
            }
        }

        


    }
}

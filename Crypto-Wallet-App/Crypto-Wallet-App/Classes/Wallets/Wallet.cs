using Crypto_Wallet_App.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
     abstract class Wallet
    {
        public Guid Address { get; }
        public Dictionary<Guid, double> FungibleAssetBalance { get;  private set; } = new Dictionary<Guid, double>();
        public Dictionary<Guid, double> FungibleAssetBalanceBefore { get; private set; } = new Dictionary<Guid, double>();
        public List<Guid> ListOfSupportedFungibleAssets { get; set; } = new List<Guid>();
        public List<Guid> ListOfTransactionAddresses { get; private set; } = new List<Guid>();
        
        public string WalletType { get; set; } = "";

        public bool isNew;

        public void SetBeforeBalanceToCurrent()
        {
            FungibleAssetBalanceBefore = FungibleAssetBalance;
        }


        public Wallet(bool aIsNew) {
            Address = Guid.NewGuid();
            isNew = aIsNew;
        }

        public void GiveAllSupportedAssetsAValue()
        {
            foreach (var item in ListOfSupportedFungibleAssets)
            {
                Random random = new Random();
                double num = random.NextDouble() * 29 + 1;
                FungibleAssetBalance.Add(item, num);
                FungibleAssetBalanceBefore.Add(item, num);

            }
        }

        public virtual double ValueOfAllAssets()
        {
            double sum = 0;
            foreach(var item in FungibleAssetBalance)
            {
                if(ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key) != null) { 
                FungibleAsset asset = ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key);
                sum += (item.Value * asset.Value);
                }
            }
            return sum;
            
        }

        public virtual double ValueOfAllAssetsBefore()
        {
            double sum = 0;
            foreach (var item in FungibleAssetBalanceBefore)
            {

                FungibleAsset asset = ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key);
                sum += (item.Value * asset.Value);
            }
            return sum;
        }


    }
}

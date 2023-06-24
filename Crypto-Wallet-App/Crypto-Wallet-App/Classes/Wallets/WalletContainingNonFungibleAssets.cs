using Crypto_Wallet_App.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
    abstract class WalletContainingNonFungibleAssets : Wallet
    {
        public List<Guid> ContainedNonFungibleAssets { get; set; } = new List<Guid>();
        public List<Guid> ListOfSupportedNonFungibleAssets { get; set; } = new List<Guid>();


        public WalletContainingNonFungibleAssets(bool isNew) : base(isNew) { }

        public override double ValueOfAllAssets()
        {
            double sum = 0;
            foreach (var item in FungibleAssetBalance)
            {
                if(ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key) != null) { 
                FungibleAsset asset = ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key);
                sum += (item.Value * asset.Value);
                }

            }

            foreach (var item in ContainedNonFungibleAssets)
            {
                NonFungibleAsset asset = ListOfValidAssets.ListOfNonFungibleAssets.Find(obj => obj.Address == item);
                sum += (asset.Value);
            }

            return sum;
        }

        public override double ValueOfAllAssetsBefore()
        {
            double sum = 0;
            foreach (var item in FungibleAssetBalanceBefore)
            {
                FungibleAsset asset = ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == item.Key);
                sum += (item.Value * asset.Value);

            }

            foreach (var item in ContainedNonFungibleAssets)
            {
                NonFungibleAsset asset = ListOfValidAssets.ListOfNonFungibleAssets.Find(obj => obj.Address == item);
                sum += (asset.Value);
            }

            return sum;
        }

    }
}

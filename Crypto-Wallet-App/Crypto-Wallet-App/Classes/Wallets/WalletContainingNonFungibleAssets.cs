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
        
    }
}

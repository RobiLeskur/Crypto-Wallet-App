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

        public Wallet() {
            Address = new Guid();


        }

    }
}

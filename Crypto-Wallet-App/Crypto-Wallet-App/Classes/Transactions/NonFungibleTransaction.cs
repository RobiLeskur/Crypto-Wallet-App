using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Transactions
{
     class NonFungibleTransaction : Transaction
    {
        public NonFungibleTransaction(Guid aAssetAddress, DateTime aTimeOfTransaction, Guid aSendingAddress, Guid aReceivingAddress, bool isRevoked) : base( aAssetAddress,  aTimeOfTransaction,  aSendingAddress,  aReceivingAddress,  isRevoked) { }


    }
}

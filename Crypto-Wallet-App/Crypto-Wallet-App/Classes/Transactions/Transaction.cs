using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Transactions
{
     abstract class Transaction
    {
        public Guid Id { get; }
        public Guid AssetAddress { get; }
        public DateTime TimeOfTransaction { get; }
        public Guid SendingAddress { get; }
        public Guid ReceivingAddress { get; }
        public bool IsRevoked { get; set; }

        public Transaction(Guid aAssetAddress , DateTime aTimeOfTransaction, Guid aSendingAddress, Guid aReceivingAddress, bool isRevoked)
        {
            Id = Guid.NewGuid();
            AssetAddress = aAssetAddress;
            TimeOfTransaction = aTimeOfTransaction;
            SendingAddress = aSendingAddress;
            ReceivingAddress = aReceivingAddress;
            IsRevoked = isRevoked;
            
        }
        
        

       

    }
}

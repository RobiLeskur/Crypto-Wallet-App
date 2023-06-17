using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Transactions
{
    
    class FungibleTransaction : Transaction
    {

        public double WalletBalanceBeforeSending { get; set; }
        public double WalletBalanceAfterSending { get; set; }
        public double WalletBalanceBeforeReceiving { get; set; }
        public double WalletBalanceAfterReceiving { get; set; }
        public double HowMuchIsSent { get; set; }

        public FungibleTransaction(Guid anAddress, DateTime aTimeOfTransaction, Guid aSendingAddress, Guid aReceivingAddress,double aHowMuchIsSent ,bool aIsRevoked) : base(anAddress, aTimeOfTransaction, aSendingAddress, aReceivingAddress, aIsRevoked) {
           WalletBalanceBeforeSending = ;
           WalletBalanceAfterSending = ;
            WalletBalanceBeforeReceiving = ;
            WalletBalanceAfterReceiving = ;
        
        }
    }
}

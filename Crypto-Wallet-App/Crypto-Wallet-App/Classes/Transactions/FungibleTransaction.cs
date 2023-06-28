using Crypto_Wallet_App.Classes.Wallets;
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
        public double howMuch { get; set; }
        

        public FungibleTransaction(Guid anAssetAddress, DateTime aTimeOfTransaction, Guid aSendingAddress, Guid aReceivingAddress,double aHowMuchIsSent ,bool aIsRevoked) : base(anAssetAddress, aTimeOfTransaction, aSendingAddress, aReceivingAddress, aIsRevoked) {
            WalletBalanceBeforeSending = GetWalletByAddress(ListOfWallets.AllWallets, SendingAddress).FungibleAssetBalance[anAssetAddress];
            GetWalletByAddress(ListOfWallets.AllWallets, SendingAddress).FungibleAssetBalance[anAssetAddress] -= aHowMuchIsSent;
            WalletBalanceAfterSending = GetWalletByAddress(ListOfWallets.AllWallets, SendingAddress).FungibleAssetBalance[anAssetAddress];
            WalletBalanceBeforeReceiving = GetWalletByAddress(ListOfWallets.AllWallets, ReceivingAddress).FungibleAssetBalance[anAssetAddress];
            GetWalletByAddress(ListOfWallets.AllWallets, SendingAddress).FungibleAssetBalance[anAssetAddress] += aHowMuchIsSent;
            WalletBalanceAfterSending = GetWalletByAddress(ListOfWallets.AllWallets, SendingAddress).FungibleAssetBalance[anAssetAddress]; howMuch = aHowMuchIsSent;
        }
        

        

        

      

    }
}

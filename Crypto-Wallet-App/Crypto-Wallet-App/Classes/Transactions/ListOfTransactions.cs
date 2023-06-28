using Crypto_Wallet_App.Classes.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Transactions
{
     class ListOfTransactions
    {
        public static List<Transaction> TransactionList { get; set; } = new List<Transaction>();
        public static List<FungibleTransaction> FungibleTransactionList { get; set; } = new List<FungibleTransaction>();
        public static List<NonFungibleTransaction> NonFungibleTransactionList { get; set; } = new List<NonFungibleTransaction>();






        public static void PrintTransactions()
        {
            foreach (var item in TransactionList)
            {
                Console.WriteLine("Id Transakcije - " + item.Id);
                Console.WriteLine("Je li opozvana - " + item.IsRevoked);
            }

        }
    }

    


}

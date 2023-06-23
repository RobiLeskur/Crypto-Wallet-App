using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Wallets
{
      class ListOfWallets
    {
         public static List<Wallet> AllWallets = new List<Wallet>()
        {
            new BitcoinWallet(false),
            new BitcoinWallet(false),
            new BitcoinWallet(false),
            new EthereumWallet(false),
            new EthereumWallet(false),
            new EthereumWallet(false),
            new SolanaWallet(false),
            new SolanaWallet(false), 
            new SolanaWallet(false)

        };


    }
}

using Crypto_Wallet_App.Classes.Assets;
using Crypto_Wallet_App.Classes.Wallets;
using System;
using System.Data;

namespace Crypto_Wallet_App
{
    internal class Program
    {
        static int InputIncludingParsing(int numberOfOptions)
        {
            bool isValid = false;
            int num;
            do {
                Console.Write("Unesi broj: ");
                var input = Console.ReadLine();
                isValid = int.TryParse(input, out num);

                if (isValid != true || num > numberOfOptions || num <= 0)
                    Console.WriteLine("Krivi unos!!");
            } while (isValid != true || num > numberOfOptions || num <=0);

            return num;
        }

        static int StartingMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Kreiraj wallet");
            Console.WriteLine("2 - Pristupi walletu");
            Console.WriteLine("3 - Izlazak iz aplikacije");
            return InputIncludingParsing(3);

        }

        static int CreateWalletMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Bitcoin wallet");
            Console.WriteLine("2 - Etherium wallet");
            Console.WriteLine("3 - Solana wallet");
            Console.WriteLine("4 - Povratak");
            return InputIncludingParsing(4);

        }

        static void WalletCreatedMessage(string typeOfWallet)
        {
            Console.WriteLine($"{typeOfWallet} wallet uspijesno kreiran!");
            Console.Write("Za povratak klikni bilo koji botun: ");
            Console.ReadLine();
        }
        
        

        static void Main()
        {

            while (true)
            {
            
                switch(StartingMenu())
                {
                    case 1:
                        switch (CreateWalletMenu())
                        {
                            case 1:
                                Console.WriteLine(ListOfWallets.AllWallets.Last().Address);
                                Console.ReadLine();
                                ListOfWallets.AllWallets.Add( new BitcoinWallet(true));
                                WalletCreatedMessage("Bitcoin");
                                break;
                            case 2:
                                ListOfWallets.AllWallets.Add(new EthereumWallet(true));
                                WalletCreatedMessage("Ethereum");
                                break;
                            case 3:
                                ListOfWallets.AllWallets.Add(new SolanaWallet(true));
                                WalletCreatedMessage("Solana");
                                break;
                            case 4:
                                break;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        return;

                        
                }

                Console.WriteLine(ListOfWallets.AllWallets.Last().Address);
                Console.ReadLine() ;

            }
            

        }

    }
}
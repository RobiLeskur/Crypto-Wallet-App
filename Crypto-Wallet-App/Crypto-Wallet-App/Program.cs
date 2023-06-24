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

        static Guid InputGuidIncludingParsing()
        {
            bool isValid = false;
            Guid num;
            do
            {
                Console.Write("Unesi adresu: ");
                var input = Console.ReadLine();
                isValid = Guid.TryParse(input, out num);

                if (isValid != true )
                    Console.WriteLine("Krivi unos!!");
            } while (isValid != true);

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
            Console.WriteLine("--KREIRANJE WALLETA--");
            Console.WriteLine("1 - Bitcoin wallet");
            Console.WriteLine("2 - Etherium wallet");
            Console.WriteLine("3 - Solana wallet");
            Console.WriteLine("4 - Povratak");
            return InputIncludingParsing(4);

        }

        static int AccessWalletMenu()
        {
            Console.Clear();
            Console.WriteLine("--PRISTUP WALLETU--");
            Console.WriteLine("1 - Portfolio");
            Console.WriteLine("2 - Transfer");
            Console.WriteLine("3 - Povijest transakcija");
            Console.WriteLine("4 - Opozovi transakciju");
            Console.WriteLine("5 - povratak na inicijalni menu");
            return InputIncludingParsing(5);

        }

        static void WalletCreatedMessage(string typeOfWallet)
        {
            Console.WriteLine($"{typeOfWallet} wallet uspijesno kreiran!");
            Console.Write("Za povratak klikni bilo koji botun: ");
            Console.ReadLine();
        }

        
        static void PrintWallet(Wallet wallet)
        {
            Console.WriteLine($"Tip walleta : {wallet.WalletType}");
            Console.WriteLine($"Adresa walleta : {wallet.Address}");
            Console.WriteLine($"Ukupna vrijednosti asseta : {wallet.ValueOfAllAssets()}");
            Console.WriteLine($"Promjena vrijenosti : {wallet.ValueOfAllAssets()/wallet.ValueOfAllAssetsBefore()}");

            wallet.SetBeforeBalanceToCurrent();

        }

        static bool checkIfGivenAddressExists(Guid address)
        {
            foreach(var item in ListOfWallets.AllWallets)
                if (item.Address == address)
                    return true;
            Console.WriteLine("Adresa koju ste unijeli ne postoji");
            return false;
           

        }

        public void Portfolio(Guid address)
        {
            Wallet wallet = ListOfWallets.AllWallets.Find(obj => obj.Address == address);
            Console.WriteLine(wallet.ValueOfAllAssets());
           

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
                        foreach(var item in ListOfWallets.AllWallets)
                            PrintWallet(item);

                        Console.WriteLine("Unesi adresu zeljenog wallta");
                        Guid walletAddres = InputGuidIncludingParsing();
                       while(checkIfGivenAddressExists(walletAddres) == false)
                        walletAddres = InputGuidIncludingParsing();

                       

                        switch (AccessWalletMenu())
                        {
                            case 1:
                                
                                break;
                            case 2:
                                break;
                            case 3:
                            
                                break;
                            case 4:
                                break;
                        }

                        break;
                    case 3:
                        return;

                        
                }

          

            }
            

        }

    }
}
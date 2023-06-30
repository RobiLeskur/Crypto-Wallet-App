using Crypto_Wallet_App.Classes.Assets;
using Crypto_Wallet_App.Classes.Transactions;
using Crypto_Wallet_App.Classes.Wallets;
using System;
using System.Data;
using System.Security.Cryptography;

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
            Console.WriteLine($"Promjena vrijenosti : {wallet.ValueOfAllAssets()/wallet.ValueOfAllAssetsBefore()*100}%");

            wallet.SetBeforeBalanceToCurrent();

        }

        static bool checkIfGivenTransactionAddressExists(Guid address)
        {
            foreach (var item in ListOfTransactions.TransactionList)
                if (item.Id == address)
                    return true;
            Console.WriteLine("Adresa koju ste unijeli ne postoji");
            return false;


        }

        static bool checkIfGivenWalletAddressExists(Guid address)
        {
            foreach(var item in ListOfWallets.AllWallets)
                if (item.Address == address)
                    return true;
            Console.WriteLine("Adresa koju ste unijeli ne postoji");
            return false;
           

        }

        static void Portfolio(Guid address)
        {
            Wallet wallet = ListOfWallets.AllWallets.Find(obj => obj.Address == address);
            Console.WriteLine("Ukupna vrijednost svih asseta: " + wallet.ValueOfAllAssets());
            foreach(var item in ListOfValidAssets.ListOfFungibleAssets)
            {
                Console.WriteLine("Adresa: " + item.Address);
                Console.WriteLine("Ime asseta: " + item.Name);
                Console.WriteLine("Oznaka: " + item.Type);
                Console.WriteLine("Vrijednost: " + item.Value);
                Console.WriteLine("Promijena vrijednosti: 100%" );

            }
           

        }

        static void TransferMenu(Guid SenderAddress)
        {
            Console.Clear();
            foreach (var item in ListOfWallets.AllWallets)
                PrintWallet(item);
            Console.WriteLine("\nWALLET KOJEM SE SALJE ");
            Guid ReceiverAddress = InputGuidIncludingParsing();


            Wallet SenderWallet = ListOfWallets.AllWallets.Find(obj => obj.Address == SenderAddress);
            string senderType = SenderWallet.WalletType;

            Wallet ReceiverWallet = ListOfWallets.AllWallets.Find(obj => obj.Address == ReceiverAddress);
            string receiverType = ReceiverWallet.WalletType;


            if (senderType == "BTC" ||receiverType =="BTC") { 
                Console.WriteLine("-FUNGIBLE ASSETI-");
          

            foreach (var item in ListOfValidAssets.ListOfFungibleAssets)
                if (SenderWallet.ListOfSupportedFungibleAssets.Contains(item.Address) && ReceiverWallet.ListOfSupportedFungibleAssets.Contains(item.Address))
                    Console.WriteLine(item.Name + " <-> " + item.Address);
            }

            else {

                Console.WriteLine("FUNGIBLE ASSETI-");
                foreach (var item in ListOfValidAssets.ListOfFungibleAssets)
                    if (SenderWallet.ListOfAllSupportedAssets.Contains(item.Address) && ReceiverWallet.ListOfAllSupportedAssets.Contains(item.Address))
                        Console.WriteLine(item.Name + "<->" + item.Address);


                Console.WriteLine("-NONFUNGIBLE ASSETI-");
            foreach (var item in ListOfValidAssets.ListOfNonFungibleAssets)
                    if(SenderWallet.ListOfAllSupportedAssets.Contains(item.Address) && ReceiverWallet.ListOfAllSupportedAssets.Contains(item.Address))
                Console.WriteLine(item.Name + "<->" + item.Address);
            }
            Console.WriteLine("\nASSET KOJI SE SALJE ");

            Guid assetAddress = InputGuidIncludingParsing();
            
            if (ListOfValidAssets.IsAddressFromFungibleAsset(assetAddress) == true)
            {
                Console.WriteLine("Unesite količinu: ");
                double howMuch = double.Parse(Console.ReadLine());

                FungibleTransaction newTransaction = new FungibleTransaction(assetAddress, DateTime.Now, SenderAddress, ReceiverAddress, howMuch, false);
                ListOfTransactions.TransactionList.Add(newTransaction);
                ListOfTransactions.FungibleTransactionList.Add(newTransaction);

                foreach (var item in ListOfWallets.AllWallets)
                {
                    if (SenderAddress == item.Address || ReceiverAddress == item.Address)
                        item.ListOfTransactionAddresses.Add(newTransaction.Id);
                }

                foreach (var item in ListOfValidAssets.ListOfFungibleAssets)
                    if (item.Address == assetAddress)
                    {
                        Random random = new Random();
                        double randomNumber = (random.NextDouble() * 5) - 2.5;
                        item.changeAssetValue(randomNumber);
                    }


            }
            else
            {
                NonFungibleTransaction newTransaction = new NonFungibleTransaction(assetAddress, DateTime.Now, SenderAddress, ReceiverAddress, false);
                ListOfTransactions.TransactionList.Add(newTransaction);
                ListOfTransactions.NonFungibleTransactionList.Add(newTransaction);

                foreach (var item in ListOfWallets.AllWallets)
                {
                    if (SenderAddress == item.Address || ReceiverAddress == item.Address)
                        item.ListOfTransactionAddresses.Add(newTransaction.Id);
                }


                foreach (var item in ListOfValidAssets.ListOfNonFungibleAssets)
                {
                    if (item.Address == assetAddress)
                        foreach (var fungible in ListOfValidAssets.ListOfFungibleAssets)
                            if (item.Address == item.adressOfFungibleAssetToWhichItRefers)
                            {
                                Random random = new Random();
                                double randomNumber = (random.NextDouble() * 5) - 2.5;
                                item.changeAssetValue(randomNumber);
                            }

                }



            }

        }

        static void historyOfTransactions(Guid currentWalletAddress)
        {
            foreach(var transaction in ListOfTransactions.TransactionList)
            {
                Wallet wallet = ListOfWallets.AllWallets.Find(obj => obj.Address == currentWalletAddress);
                if (wallet.ListOfTransactionAddresses.Contains(transaction.Id)) { 
                    Console.WriteLine("ID: " + transaction.Id);
                     Console.WriteLine("Vrijeme: " + transaction.TimeOfTransaction);
                Console.WriteLine("Adresa walleta koji prima: " + transaction.ReceivingAddress);
                   Console.WriteLine("Adresa walleta koji salje: " + transaction.SendingAddress);

                    if(transaction is FungibleTransaction fung && fung != null)
                    {
                        Console.WriteLine("Kolicina: " + fung.howMuch);
                        FungibleAsset fungAsset = ListOfValidAssets.ListOfFungibleAssets.Find(obj => obj.Address == fung.Id);
                        if (fungAsset != null)
                        {
                            Console.WriteLine("Ime: " + fungAsset.Name);
                        }
                    }
                    else if (transaction is NonFungibleTransaction nonFung && nonFung != null)
                    {
                        NonFungibleAsset fungAsset = ListOfValidAssets.ListOfNonFungibleAssets.Find(obj => obj.Address == nonFung.Id);
                        if (fungAsset != null)
                        {
                            Console.WriteLine("Ime: " + fungAsset.Name);
                        }

                    }

                    Console.WriteLine("Je li opozvana: " + transaction.IsRevoked);
                }
               



            }

        }

        static void RevokeTransaction()
        {
            Console.Clear();
            Console.WriteLine("--TRANSAKCIJE--");
            if(ListOfTransactions.TransactionList.Count == 0 ) { Console.WriteLine("Nema transakcija"); return; }
            ListOfTransactions.PrintTransactions();
            Console.WriteLine();
            Console.WriteLine("1 - Opozivanje");
            Console.WriteLine("2 - Povratak");
            switch(InputIncludingParsing(2)) {
                case 1:

            Console.WriteLine("Unesite adresu koju bi opozvali: ");
            Guid transactionAddress = InputGuidIncludingParsing();
            while (checkIfGivenTransactionAddressExists(transactionAddress) == false)
                transactionAddress = InputGuidIncludingParsing();
            foreach(var item in ListOfTransactions.FungibleTransactionList)
            {
                if(item.Id == transactionAddress)
                {
                    item.revertTransaction(item.AssetAddress, item.howMuch);
                    if(item.IsRevoked == true) { 
                        Console.WriteLine("Transakcija je vec opozvana!");
                    return;
                    }
                    item.IsRevoked = true;
                    
                    
                }
                        else
                        {
                            item.IsRevoked = true;
                        }
                    
            }
                    break;
                    case 2:
                    break;
        }

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
                        Console.Clear();
                        foreach(var item in ListOfWallets.AllWallets)
                            PrintWallet(item);

                        Console.WriteLine("Unesi adresu zeljenog wallta");
                        Guid walletAddres = InputGuidIncludingParsing();
                       while(checkIfGivenWalletAddressExists(walletAddres) == false)
                        walletAddres = InputGuidIncludingParsing();

                        while (true) { 
                        int checker = AccessWalletMenu();
                            if (checker == 5) break;
                        switch (checker)
                        {
                            case 1:
                                    Console.Clear();
                                Portfolio(walletAddres);
                                    Console.Write("Bilo sto za povratak: ");
                                    Console.ReadLine();

                                break; 
                            case 2:
                                    Console.Clear();
                                    TransferMenu(walletAddres);
                                    Console.Write("Bilo sto za povratak: ");
                                    Console.ReadLine();
                                 break;
                            case 3:
                                    Console.Clear();

                                    historyOfTransactions(walletAddres);
                                    Console.ReadLine();

                                continue;
                            case 4:
                                    Console.Clear();
                                    RevokeTransaction();
                                break;
                        }
                            
                        }


                        break;
                        
                    case 3:
                        return;

                        
                }

          

            }
            

        }

    }
}
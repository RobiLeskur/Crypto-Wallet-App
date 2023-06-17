using Crypto_Wallet_App.Classes.Assets;
using Crypto_Wallet_App.Classes.Wallets;
using System;

namespace Crypto_Wallet_App
{
    internal class Program
    {
        static void Main()
        {
           
            FungibleAsset asset = new FungibleAsset("Ime", 2.32);
            Console.WriteLine(asset.Name);

        }

    }
}
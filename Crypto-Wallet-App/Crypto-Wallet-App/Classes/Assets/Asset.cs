using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet_App.Classes.Assets
{
    abstract class Asset
    {
        public Guid Address { get; }
        public string Name { get; set; } 
        public double Value { get; private set; }

        public Asset(string nameOfAsset, double valueOfAsset) { 
            Name = nameOfAsset;
            Value = valueOfAsset;
        }

    }
}

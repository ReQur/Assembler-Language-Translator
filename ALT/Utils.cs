using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT
{
    partial class ALT
    {
        private static int ToHex(string Number)
        {
            return Int32.Parse(Number, System.Globalization.NumberStyles.HexNumber);
        }
        public static void SaveInFile(string path)
        {
            _translationResult.SaveInFile(path);
        }
    }

}

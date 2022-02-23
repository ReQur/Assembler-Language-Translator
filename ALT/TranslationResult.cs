using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT
{
    class TranslationResult
    {
        private List<CommandResult> translatioResults;
        public TranslationResult()
        {
            translatioResults = new List<CommandResult>();
        }

        public void Add(CommandResult cR)
        {
            translatioResults.Add(cR);
        }

        public void SaveInFile(string path)
        {
            using (StreamWriter sw =
                           File.CreateText(path))
            {
                foreach (var code in translatioResults)
                {
                    code.SaveInFile(sw);
                }
            }
        }
    }
}

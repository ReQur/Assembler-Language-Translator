using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALT
{
    //partial class ALT
    //{
    //    private static ValidationResult _validationResult = new ValidationResult();
    //    public static void Validate(string file)
    //    {
    //        int lineNumber = 0;
    //        foreach (string line in File.ReadLines(file))
    //        {
    //            lineNumber++;
    //            if (!Regex.IsMatch(line, ".*;"))
    //            {
    //                if (!Regex.IsMatch(line, ".*:"))
    //                {
    //                    _validationResult.Add(new Exception("Incorrect line format"), lineNumber);
    //                }
    //            }
    //            var command = line.Replace(";", "");
    //            var commandArray = command.Split(' ');
    //            var commandResult = _commandDictionary[commandArray[0]].Invoke(commandArray);
    //        }
    //    }
    //}
}

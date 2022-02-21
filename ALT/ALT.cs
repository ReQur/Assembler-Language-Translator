using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALT
{
    partial class ALT
    {
        private static ValidationResult _validationResult = new ValidationResult();
        ALT()
        {

        }

        private static int ToHex(string Number)
        {
            return Int32.Parse(Number, System.Globalization.NumberStyles.HexNumber);
        }
        public static void Translate(string file)
        {
            int lineNumber = 0;
            foreach (string line in File.ReadLines(file))
            {
                lineNumber++;
                if (!Regex.IsMatch(line, ".*;"))
                {
                    if (!Regex.IsMatch(line, ".*:"))
                    {
                        _validationResult.Add(new Exception("Incorrect line format"), lineNumber);
                    }
                }
                var command = line.Replace(";", "");
                var commandArray = command.Split(' ');

                CommandResult commandResult;
                if (!_commandDictionary.ContainsKey(commandArray[0]))
                {
                    _validationResult.Add(new Exception("Invalid command"), lineNumber);
                }
                try
                {
                    commandResult = _commandDictionary[commandArray[0]].Invoke(commandArray);
                    commandResult.PrintResult();
                }
                catch (Exception e)
                {
                    _validationResult.Add(e, lineNumber);
                }
            }
        }
        private static CommandResult ADD_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (!_addCommandDictionary.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid argument");
            }

            return new CommandResult(_addCommandDictionary[commandArray[1]]);
        }
        private static CommandResult ADI_func(string[] commandArray)
        {
            return new CommandResult(0xC6, ToHex(commandArray[1]));
        }
        private static CommandResult ADC_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (!_adcCommandDictionary.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(_adcCommandDictionary[commandArray[1]]);
        }
        private static CommandResult ACI_func(string[] commandArray)
        {
            return new CommandResult(0xCE, ToHex(commandArray[1]));
        }

        private static CommandResult ANA_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (!_anaCommandDictionary.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(_anaCommandDictionary[commandArray[1]]);
        }
        private static CommandResult ANI_func(string[] commandArray)
        {
            return new CommandResult(0xE6, ToHex(commandArray[1]));
        }

        private static CommandResult CALL_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xCD, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CZ_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xCC, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CNZ_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xC4, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CP_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xF4, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CM_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xFC, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CC_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xDC, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CNC_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xD4, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CPE_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xEC, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CPO_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(0xE4, ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult CMA_func(string[] commandArray)
        {
            return new CommandResult(0x2F);
        }
        private static CommandResult CMC_func(string[] commandArray)
        {
            return new CommandResult(0x3F);
        }

        private static CommandResult CMP_func(string[] commandArray)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (!_cmpCommandDictionary.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(_cmpCommandDictionary[commandArray[1]]);
        }
        private static CommandResult CPI_func(string[] commandArray)
        {
            return new CommandResult(0xFE, ToHex(commandArray[1]));
        }
    }
}

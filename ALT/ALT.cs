using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALT
{
    static partial class ALT
    {
        private static ValidationResult _validationResult = new ValidationResult();
        private static TranslationResult _translationResult = new TranslationResult();

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
                        continue;
                    }
                }
                var command = line.Replace(";", "");

                if (Regex.IsMatch(command, ".*\\s.,\\s."))
                {
                    command = command.Replace(", ", " ");
                }
                else if (Regex.IsMatch(command, ".*\\s.,."))
                {
                    command = command.Replace(",", " ");
                }

                var commandArray = command.Split(' ');
                
                if (!_commandDictionary.ContainsKey(commandArray[0]))
                {
                    _validationResult.Add(new Exception("Invalid command"), lineNumber);
                }
                try
                {
                    CommandResult commandResult = _commandDictionary[commandArray[0]].Item1.Invoke(commandArray, _commandDictionary[commandArray[0]].Item2);
                    _translationResult.Add(commandResult);
                }
                catch (Exception e)
                {
                    _validationResult.Add(e, lineNumber);
                }
            }
        }

        private static CommandResult first_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (!commandCode.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid argument");
            }

            return new CommandResult(commandCode[commandArray[1]]);
        }

        private static CommandResult second_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFF)
            {
                throw new Exception("Invalid argument");
            }
            return new CommandResult(commandCode[commandArray[0]], ToHex(commandArray[1]));
        }
        private static CommandResult CALL_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            if (!commandCode.ContainsKey(commandArray[0]))
            {
                throw new Exception("Invalid command");
            }
            return new CommandResult(commandCode[commandArray[0]], ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }
        private static CommandResult third_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 1)
            {
                throw new Exception("Invalid format");
            }

            if (!commandCode.ContainsKey(commandArray[0]))
            {
                throw new Exception("Invalid command");
            }
            return new CommandResult(commandCode[commandArray[0]]);
        }
        private static CommandResult fourth_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 2)
            {
                throw new Exception("Invalid Number of arguments");
            }

            if (ToHex(commandArray[1]) < 0 || ToHex(commandArray[1]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            if (!commandCode.ContainsKey(commandArray[0]))
            {
                throw new Exception("Invalid command");
            }
            return new CommandResult(commandCode[commandArray[0]], ToHex(commandArray[1].Substring(2, 2)), ToHex(commandArray[1].Substring(0, 2)));
        }

        private static CommandResult MOV_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 3)
            {
                throw new Exception("Invalid Number of arguments");
            }
            if (!commandCode.ContainsKey(commandArray[1] + commandArray[2]))
            {
                throw new Exception("Invalid arguments");
            }
            return new CommandResult(commandCode[commandArray[1] + commandArray[2]]);
        }

        private static CommandResult LXI_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 3)
            {
                throw new Exception("Invalid Number of arguments");
            }
            if (ToHex(commandArray[2]) < 0 || ToHex(commandArray[2]) > 0xFFFF)
            {
                throw new Exception("Invalid argument");
            }
            if (!commandCode.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid arguments");
            }
            return new CommandResult(commandCode[commandArray[1]], ToHex(commandArray[2].Substring(2, 2)), ToHex(commandArray[2].Substring(0, 2)));
        }
        private static CommandResult MVI_type_func(string[] commandArray, Dictionary<string, int> commandCode)
        {
            if (commandArray.Length != 3)
            {
                throw new Exception("Invalid Number of arguments");
            }
            if (!commandCode.ContainsKey(commandArray[1]))
            {
                throw new Exception("Invalid arguments");
            }
            return new CommandResult(commandCode[commandArray[1]], ToHex(commandArray[2]));
        }

    }
}

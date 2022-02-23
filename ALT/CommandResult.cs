using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT
{
    class CommandResult
    {
        private readonly int _firstByte;
        private readonly int _secondByte;
        private readonly int _thirdByte;

        public CommandResult(int first)
        {
            _firstByte = first;
            _secondByte = 0xFFFF;
            _thirdByte = 0xFFFF;
        }
        public CommandResult(int first, int second)
        {
            _firstByte = first;
            _secondByte = second;
            _thirdByte = 0xFFFF;

        }
        public CommandResult(int first, int second, int third)
        {
            _firstByte = first;
            _secondByte = second;
            _thirdByte = third;
        }

        public void PrintResult()
        {
            Console.WriteLine(_firstByte.ToString("x2"));

            if (_secondByte != 0xFFFF) Console.WriteLine(_secondByte.ToString("x2"));
            if (_thirdByte != 0xFFFF) Console.WriteLine(_thirdByte.ToString("x2"));
        }

        public void SaveInFile(StreamWriter sw)
        {
            sw.WriteLine(_firstByte.ToString("x2"));

            if (_secondByte != 0xFFFF) sw.WriteLine(_secondByte.ToString("x2"));
            if (_thirdByte != 0xFFFF) sw.WriteLine(_thirdByte.ToString("x2"));
        }
    }
}

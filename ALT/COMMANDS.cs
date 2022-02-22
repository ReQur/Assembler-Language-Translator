using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ALT
{
    partial class ALT
    {
        private static Dictionary<string, int> _addCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x87},
            {"B", 0x80},
            {"C", 0x81},
            {"D", 0x82},
            {"E", 0x83},
            {"H", 0x84},
            {"L", 0x85},
            {"M", 0x86},
        };
        private static Dictionary<string, int> _adcCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x8F},
            {"B", 0x88},
            {"C", 0x89},
            {"D", 0x8A},
            {"E", 0x8B},
            {"H", 0x8C},
            {"L", 0x8D},
            {"M", 0x8E},
        };
        private static Dictionary<string, int> _anaCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0xA7},
            {"B", 0xA0},
            {"C", 0xA1},
            {"D", 0xA2},
            {"E", 0xA3},
            {"H", 0xA4},
            {"L", 0xA5},
            {"M", 0xA6},
        };
        private static Dictionary<string, int> _cmpCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0xBF},
            {"B", 0xB8},
            {"C", 0xB9},
            {"D", 0xBA},
            {"E", 0xBB},
            {"H", 0xBC},
            {"L", 0xBD},
            {"M", 0xBE},
        };
        private static Dictionary<string, int> _dadCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x09},
            {"D", 0x19},
            {"H", 0x29},
            {"SP", 0x39},
        };
        private static Dictionary<string, int> _dcrCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x3D},
            {"B", 0x05},
            {"C", 0x0D},
            {"D", 0x15},
            {"E", 0x1D},
            {"H", 0x25},
            {"L", 0x2D},
            {"M", 0x35},
        };
        private static Dictionary<string, int> _secondTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"ADI", 0xC6},
            {"ACI", 0xCE},
            {"ANI", 0xE6},
            {"XRI", 0xEE},
            {"ORI", 0xF6},
            {"CPI", 0xFE},
            {"SUI", 0xD6},
            {"SBI", 0xDE},
        };
        private static Dictionary<string, int> _callTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"CALL", 0xCD},
            {"CZ", 0xCC},
            {"CNZ", 0xC4},
            {"CP", 0xF4},
            {"CM", 0xFC},
            {"CC", 0xDC},
            {"CNC", 0xD4},
            {"CPE", 0xEC},
            {"CPO", 0xE4},
        };

        private static Dictionary<string, int> _thirdTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"CMA", 0x2F},
            {"CMC", 0x3F},
            {"DAA", 0x27},
            {"DI", 0xF3},
            {"EI", 0xFB},
            {"HLT", 0x76},
            {"NOP", 0x00},
            {"PCHL", 0xE9},
            {"RAL", 0x17},
            {"RAR", 0x1F},
            {"RLC", 0x07},
            {"RRC", 0x0F},
            {"RIM", 0x20},
            {"RET", 0xC9},
            {"RZ", 0xC8},
            {"RNZ", 0xC0},
            {"RP", 0xF0},
            {"RM", 0xF8},
            {"RC", 0xD8},
            {"RNC", 0xD0},
            {"RPE", 0xE8},
            {"RPO", 0xE0},
        };

        private static Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>> _commandDictionary =
            new Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>>()
            {
                {"ADD", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _addCommandDictionary)},
                {"ADI", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(second_type_func, _secondTypeCommandDictionary)},
                {"ADC", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _adcCommandDictionary)},
                {"ACI", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(second_type_func, _secondTypeCommandDictionary)},
                {"ANA", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _anaCommandDictionary)},
                {"ANI", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(second_type_func, _secondTypeCommandDictionary)},
                {"CALL", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CZ", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CNZ", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CP", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CM", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CC", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CNC", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CPE", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CPO", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(CALL_type_func, _callTypeCommandDictionary)},
                {"CMA", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(third_type_func, _thirdTypeCommandDictionary)},
                {"CMC", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(third_type_func, _thirdTypeCommandDictionary)},
                {"CMP", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _cmpCommandDictionary)},
                {"CPI", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(second_type_func, _secondTypeCommandDictionary)},
                {"DAA", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(third_type_func, _thirdTypeCommandDictionary)},
                {"DAD", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _dadCommandDictionary)},
                {"DCR", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _dcrCommandDictionary)},
            };
    }
}

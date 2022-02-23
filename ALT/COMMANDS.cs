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
        private static Dictionary<string, int> _dcxCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x0B},
            {"D", 0x1B},
            {"H", 0x2B},
            {"SP", 0x3B},
        };
        private static Dictionary<string, int> _inrCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x3C},
            {"B", 0x04},
            {"C", 0x0C},
            {"D", 0x14},
            {"E", 0x1C},
            {"H", 0x24},
            {"L", 0x2C},
            {"M", 0x34},
        };
        private static Dictionary<string, int> _inxCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x03},
            {"D", 0x13},
            {"H", 0x23},
            {"SP", 0x33},
        };
        private static Dictionary<string, int> _ldaxTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x0A},
            {"D", 0x1A},
        };
        private static Dictionary<string, int> _staxTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x02},
            {"D", 0x12},
        };
        private static Dictionary<string, int> _oraCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0xB7},
            {"B", 0xB0},
            {"C", 0xB1},
            {"D", 0xB2},
            {"E", 0xB3},
            {"H", 0xB4},
            {"L", 0xB5},
            {"M", 0xB6},
        };
        private static Dictionary<string, int> _subCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x97},
            {"B", 0x90},
            {"C", 0x91},
            {"D", 0x92},
            {"E", 0x93},
            {"H", 0x94},
            {"L", 0x95},
            {"M", 0x96},
        };
        private static Dictionary<string, int> _sbbCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x9F},
            {"B", 0x98},
            {"C", 0x99},
            {"D", 0x9A},
            {"E", 0x9B},
            {"H", 0x9C},
            {"L", 0x9D},
            {"M", 0x9E},
        };
        private static Dictionary<string, int> _xraCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0xAF},
            {"B", 0xA8},
            {"C", 0xA9},
            {"D", 0xAA},
            {"E", 0xAB},
            {"H", 0xAC},
            {"L", 0xAD},
            {"M", 0xAE},
        };
        private static Dictionary<string, int> _popCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0xC1},
            {"D", 0xD1},
            {"H", 0xE1},
            {"PSW", 0xF1},
        };
        private static Dictionary<string, int> _pushCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0xC5},
            {"D", 0xD5},
            {"H", 0xE5},
            {"PSW", 0xF5},
        };
        private static Dictionary<string, int> _rstCommandDictionary = new Dictionary<string, int>()
        {

            {"0", 0xC7},
            {"1", 0xCF},
            {"2", 0xD7},
            {"3", 0xDF},
            {"4", 0xE7},
            {"5", 0xEF},
            {"6", 0xF7},
            {"7", 0xFF},
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
            {"IN", 0xDB},
            {"ORI", 0xF6},
            {"OUT", 0xD3},
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
        private static Dictionary<string, int> _jmpTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"JMP", 0xC3},
            {"JZ", 0xCA},
            {"JNZ", 0xC2},
            {"JP", 0xF2},
            {"JM", 0xFA},
            {"JC", 0xDA},
            {"JNC", 0xD2},
            {"JPE", 0xEA},
            {"JPO", 0xE2},
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
            {"SIM", 0x30},
            {"SPHL", 0xF9},
            {"STC", 0x37},
            {"XCHG", 0xEB},
            {"XTHL", 0xE3},
        };

        private static Dictionary<string, int> _fourthTypeCommandDictionary = new Dictionary<string, int>()
        {
            {"LDA", 0x3A},
            {"LHLD", 0x2A},
            {"STA", 0x32},
            {"SHLD", 0x22},
        };
        private static Dictionary<string, int> _movCommandDictionary = new Dictionary<string, int>()
        {
            {"AA", 0x7F},
            {"AB", 0x78},
            {"AC", 0x79},
            {"AD", 0x7A},
            {"AE", 0x7B},
            {"AH", 0x7C},
            {"AL", 0x7D},
            {"AM", 0x7E},
            {"BA", 0x47},
            {"BB", 0x40},
            {"BC", 0x41},
            {"BD", 0x42},
            {"BE", 0x43},
            {"BH", 0x44},
            {"BL", 0x45},
            {"BM", 0x46},
            {"CA", 0x4F},
            {"CB", 0x48},
            {"CC", 0x49},
            {"CD", 0x4A},
            {"CE", 0x4B},
            {"CH", 0x4C},
            {"CL", 0x4D},
            {"CM", 0x4E},
            {"DA", 0x57},
            {"DB", 0x50},
            {"DC", 0x51},
            {"DD", 0x52},
            {"DE", 0x53},
            {"DH", 0x54},
            {"DL", 0x55},
            {"DM", 0x56},
            {"EA", 0x5F},
            {"EB", 0x58},
            {"EC", 0x59},
            {"ED", 0x5A},
            {"EE", 0x5B},
            {"EH", 0x5C},
            {"EL", 0x5D},
            {"EM", 0x5E},
            {"HA", 0x67},
            {"HB", 0x60},
            {"HC", 0x61},
            {"HD", 0x62},
            {"HE", 0x63},
            {"HH", 0x64},
            {"HL", 0x65},
            {"HM", 0x66},
            {"LA", 0x6F},
            {"LB", 0x68},
            {"LC", 0x69},
            {"LD", 0x6A},
            {"LE", 0x6B},
            {"LH", 0x6C},
            {"LL", 0x6D},
            {"LM", 0x6E},
            {"MA", 0x77},
            {"MB", 0x70},
            {"MC", 0x71},
            {"MD", 0x72},
            {"ME", 0x73},
            {"MH", 0x74},
            {"ML", 0x75},
        };
        private static Dictionary<string, int> _lxiCommandDictionary = new Dictionary<string, int>()
        {
            {"B", 0x01},
            {"H", 0x21},
            {"SP", 0x31},
        };
        private static Dictionary<string, int> _mviCommandDictionary = new Dictionary<string, int>()
        {
            {"A", 0x3E},
            {"B", 0x06},
            {"C", 0x0E},
            {"D", 0x16},
            {"E", 0x1E},
            {"H", 0x26},
            {"L", 0x2E},
            {"M", 0x36},
        };

        private static Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>
            MakeTuple(Func<string[], Dictionary<string, int>, CommandResult> func, Dictionary<string, int> dictionary)
        {
            return new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(
                func, dictionary);
        }

        private static Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>> _commandDictionary =
            new Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>>()
            {
                {"ADD", MakeTuple(first_type_func, _addCommandDictionary)},
                {"ADI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"ADC", MakeTuple(first_type_func, _adcCommandDictionary)},
                {"ACI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"ANA", MakeTuple(first_type_func, _anaCommandDictionary)},
                {"ANI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"CALL", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CZ", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CNZ", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CP", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CM", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CC", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CNC", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CPE", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CPO", MakeTuple(CALL_type_func, _callTypeCommandDictionary)},
                {"CMA", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"CMC", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"CMP", MakeTuple(first_type_func, _cmpCommandDictionary)},
                {"CPI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"DAA", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"DAD", MakeTuple(first_type_func, _dadCommandDictionary)},
                {"DCR", MakeTuple(first_type_func, _dcrCommandDictionary)},
                {"DCX", MakeTuple(first_type_func, _dcxCommandDictionary)},
                {"IN", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"INR", MakeTuple(first_type_func, _inrCommandDictionary)},
                {"INX", MakeTuple(first_type_func, _inxCommandDictionary)},
                {"JMP", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JZ", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JNZ", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JP", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JM", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JC", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JNC", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JPE", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"JPO", MakeTuple(CALL_type_func, _jmpTypeCommandDictionary)},
                {"LDA", MakeTuple(fourth_type_func, _fourthTypeCommandDictionary)},
                {"LHLD", MakeTuple(fourth_type_func, _fourthTypeCommandDictionary)},
                {"LDAX", MakeTuple(first_type_func, _ldaxTypeCommandDictionary)},
                {"LXI", MakeTuple(LXI_type_func, _lxiCommandDictionary)},
                {"MOV", MakeTuple(MOV_type_func, _movCommandDictionary)},
                {"MVI", MakeTuple(MVI_type_func, _mviCommandDictionary)},
                {"NOP", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"ORA", MakeTuple(first_type_func, _oraCommandDictionary)},
                {"PCHL", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"POP", MakeTuple(first_type_func, _popCommandDictionary)},
                {"PUSH", MakeTuple(first_type_func, _pushCommandDictionary)},
                {"RAL", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RAR", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RLC", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RRC", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RIM", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RET", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RZ", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RNZ", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RP", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RM", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RC", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RNC", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RPE", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RPO", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"RST", MakeTuple(first_type_func, _rstCommandDictionary)},
                {"SIM", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"SPHL", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"SHLD", MakeTuple(fourth_type_func, _fourthTypeCommandDictionary)},
                {"STA", MakeTuple(fourth_type_func, _fourthTypeCommandDictionary)},
                {"STAX", MakeTuple(first_type_func, _staxTypeCommandDictionary)},
                {"STС", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"SUB", MakeTuple(first_type_func, _subCommandDictionary)},
                {"SUI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"SBB", MakeTuple(first_type_func, _sbbCommandDictionary)},
                {"SBI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
                {"XCHG", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"XTHL", MakeTuple(third_type_func, _thirdTypeCommandDictionary)},
                {"XRA", MakeTuple(first_type_func, _sbbCommandDictionary)},
                {"XRI", MakeTuple(second_type_func, _secondTypeCommandDictionary)},
            };
    }
}

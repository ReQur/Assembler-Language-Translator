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
        private static Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>> _commandDictionary =
            new Dictionary<string, Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>>()
            {
                {"ADD", new Tuple<Func<string[], Dictionary<string, int>, CommandResult>, Dictionary<string, int>>(first_type_func, _addCommandDictionary)},
                //{"ADI", (ADI_func, null)},
                //{"ADC", (first_type_func, _adcCommandDictionary)},
                //{"ACI", ACI_func},
                //{"ANA", (first_type_func, _anaCommandDictionary)},
                //{"ANI", ANI_func},
                //{"CALL", CALL_func},
                //{"CZ", CZ_func},
                //{"CNZ", CNZ_func},
                //{"CP", CP_func},
                //{"CM", CM_func},
                //{"CC", CC_func},
                //{"CNC", CNC_func},
                //{"CPE", CPE_func},
                //{"CPO", CPO_func},
                //{"CMA", CMA_func},
                //{"CMC", CMC_func},
                //{"CMP", (first_type_func, _cmpCommandDictionary)},
                //{"CPI", CPI_func},
                //{"DAA", DAA_func},
                //{"DAD", (first_type_func, _dadCommandDictionary)},
                //{"DCR", (first_type_func,_dcrCommandDictionary)},
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT
{
    partial class ALT
    {
        private static Dictionary<string, Func<string[], CommandResult>> _commandDictionary = new Dictionary<string, Func<string[], CommandResult>>()
        {
            {"ADD", ADD_func},
            {"ADI", ADI_func},
            {"ADC", ADC_func},
            {"ACI", ACI_func},
            {"ANA", ANA_func},
            {"ANI", ANI_func},
            {"CALL", CALL_func},
            {"CZ", CZ_func},
            {"CNZ", CNZ_func},
            {"CP", CP_func},
            {"CM", CM_func},
            {"CC", CC_func},
            {"CNC", CNC_func},
            {"CPE", CPE_func},
            {"CPO", CPO_func},
            {"CMA", CMA_func},
            {"CMC", CMC_func},
            {"CMP", CMP_func},
            {"CPI", CPI_func},
        };


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
    }
}

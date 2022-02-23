using System;
using System.IO;

namespace ALT
{
    class Program
    {
        static void Main(string[] args)
        {
            ALT.Translate("A:\\mming\\Assembler-Language-Translator\\ALT\\testFile.txt");
            ALT.SaveInFile("A:\\mming\\Assembler-Language-Translator\\ALT\\testResultFile.txt");
            CompareTestFiles();
        }

        private static void DoTestFiles()
        {
            using (StreamWriter swt = File.CreateText("A:\\mming\\Assembler-Language-Translator\\ALT\\testFile.txt"))
            {
                using (StreamWriter swa =
                       File.CreateText("A:\\mming\\Assembler-Language-Translator\\ALT\\answerFile.txt"))
                {
                    foreach (string line in File.ReadLines("A:\\mming\\Assembler-Language-Translator\\ALT\\doc.txt"))
                    {
                        var lineArray = line.Split('\t');

                        swt.WriteLine(lineArray[0] + ';');
                        swa.WriteLine(lineArray[1]);
                    }
                }
            }
        }
        private static void CompareTestFiles()
        {
            var testResult = File.ReadAllLines("A:\\mming\\Assembler-Language-Translator\\ALT\\testResultFile.txt");
            var Answers = File.ReadAllLines("A:\\mming\\Assembler-Language-Translator\\ALT\\answerFile.txt");
            for (int i = 0; i < Answers.Length; i++)
            {
                if (testResult[i] != Answers[i])
                {
                    Console.WriteLine("in line " + i.ToString() + "Is incorrect answer. Should be " + Answers[i] + " But value is " + testResult[i]);
                }
            }
        }
    }
}

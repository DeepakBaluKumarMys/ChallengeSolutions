using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleAppThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            //Code start
            string txt = Console.ReadLine();
            Console.WriteLine(MorseCombinations(txt));
            //Code end
            Console.WriteLine("End");
            Console.ReadKey();
        }

        private static int MorseCombinations(string txt)
        {
            #region morse dictionary
            Dictionary<char, string> morseDict = new Dictionary<char, string>()
            {
                {'A',".-"},
                {'B',"-..."},
                {'C',"-.-."},
                {'D',"-.."},
                {'E',"."},
                {'F',"..-."},
                {'G',"--."},
                {'H',"...."},
                {'I',".."},
                {'J',".---"},
                {'K',"-.-"},
                {'L',".-.."},
                {'M',"--"},
                {'N',"-."},
                {'O',"---"},
                {'P',".--."},
                {'Q',"--.-"},
                {'R',".-."},
                {'S',"..."},
                {'T',"-"},
                {'U',"..-"},
                {'V',"...-"},
                {'W',".--"},
                {'X',"-..-"},
                {'Y',"-.--"},
                {'Z',"--.."}
            };
            #endregion

            Dictionary<string, string> combinations = new Dictionary<string, string>();
            int iStrLength = txt.Length;
            int iSpaces = iStrLength - 1;
            string morseInput = "";
            txt = txt.ToUpper();
            string maxbin = string.Empty, startBin = string.Empty;

            string spaceBin = "";
            int tempSpaces = iSpaces;
            //Convert to Morse code
            for (int i = 0; i < iStrLength; i++)
            {
                morseInput += (morseDict[txt[i]]);
                if (tempSpaces > 0)
                {
                    tempSpaces--;
                    spaceBin += "1";
                }
            }

            for (int i = 1; i < morseInput.Length; i++)
            {
                maxbin += "1";
                startBin += "0";
            }

            int maxIterations = Convert.ToInt32(maxbin, 2);
            int startIteration = Convert.ToInt32(spaceBin, 2);
            for (int i = startIteration; i <= maxIterations; i++)
            {
                string morseInputCopy = morseInput;
                int binSpaces = 0;
                string bin = Convert.ToString(i, 2);
                foreach (var item in bin)
                {
                    if (item == '1') binSpaces++;
                }

                if (binSpaces != iSpaces) continue;
                string checkBin = startBin.Substring(0, (startBin.Length - bin.Length)) + bin;
                if (Regex.IsMatch(checkBin, "[0]{4}")) continue;
                int spacesToMorse = 1;
                for (int j = 0; j < checkBin.Length; j++)
                {
                    if (checkBin[j] == '1')
                    {
                        morseInputCopy = morseInputCopy.Insert(j + spacesToMorse, " ");
                        spacesToMorse++;
                    }
                }
                //check for character matches
                string[] temp = morseInputCopy.Split(" ");
                string tempMorse = string.Empty;
                string tempStr = string.Empty;
                for (int k = 0; k < temp.Length; k++)
                {
                    if (morseDict.ContainsValue(temp[k]))
                    {
                        tempMorse += " " + temp[k];
                        tempStr += "" + morseDict.FirstOrDefault(x => x.Value == temp[k]).Key;
                    }
                }
                if (tempStr.Length == txt.Length)
                {
                    combinations.Add(tempStr.Trim(), tempMorse.Trim());
                }                
            }
            return combinations.Count;
        }
    }
}

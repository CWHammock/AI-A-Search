using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vertices
{
    class MapImport
    {
        public static int[,] getArray()
        {
            int j = 0;
            int[,] returnArray = new int[40, 40];
            
            string fileName = @"C:\Users\Hammock\Desktop\Programming Assignments\Maps\map1.txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] stringArray = sr.ReadLine().Split(',');
                    for (int i = 0; i < stringArray.Length; i++)
                    {
                        string stringNumber = stringArray[i].Trim();
                        if (string.IsNullOrEmpty(stringNumber))
                        {
                            stringNumber = "0";
                        }
                        int intNumber = Int32.Parse(stringNumber);
                        returnArray[j, i] = intNumber;
                    }
                    j++;
                }
            }
            return returnArray;
        }
    }
}







    
   


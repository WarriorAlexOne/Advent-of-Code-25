using System;
using System.IO;

class Day1 {
    static string[] inputLines = File.ReadAllLines("input.txt");
    static char LRIndicator;
    static string ?inputNumStr;
    static int inputNum = 0;
    static int currentNum = 50;
    static int zeroCounter = 0;

    public static void Day1_ () {
        for (int i = 0; i < inputLines.Length; i++) {
            Console.WriteLine("\nRun: " + (i+1));  // Track loop cycle

            // Collect info from strings
            LRIndicator = inputLines[i][0];
            inputNumStr = inputLines[i][1..];
            inputNum = int.Parse(inputNumStr);

            // Check Right (Addition) or Left (Subtraction)
            if (LRIndicator == 'R') currentNum += inputNum;
            if (LRIndicator == 'L') currentNum -= inputNum;

            // Check if new Num is 0 to 99
            if (currentNum >= 0 && currentNum <= 99) {
                if (currentNum == 0) {
                    zeroCounter++;
                }
                Console.WriteLine(LRIndicator + "" + inputNum + "\nCurrent Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
                continue;
            }
            
            // If Num is not 0 to 99, correct overflowed value
            if (LRIndicator == 'R') {
                Console.WriteLine("R" + inputNum + "   Subtraction Multiple: " + (int)(currentNum / 100)  + "   Subtraction Value: " + (((int)(currentNum / 100)) * 100));
                currentNum -= ((int)(currentNum / 100)) * 100;
            }
            if (LRIndicator == 'L') {
                Console.WriteLine("L" + inputNum + "   Addition Multiple: " + ((int)(-currentNum / 100)) + "   Addition Value: " + (((int)(-currentNum / 100)) * 100));
                currentNum += ((int)(-currentNum / 100)) * 100;
                if (currentNum > -100 && currentNum < 0) currentNum += 100;
            }

            // Check if new Num is now 0
            if (currentNum == 0) {
                zeroCounter++;
            }

            Console.WriteLine("Current Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
        }
    }
}

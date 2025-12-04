using System;
using System.IO;

class Day1 {
    static string[] inputLines = File.ReadAllLines("testinput.txt");
    static char LRIndicator;
    static string ?inputNumStr;
    static int inputNum = 0;
    static int currentNum = 50;
    static int trueNum = 50;
    static int lastNum = 50;
    static int zeroCounter = 0;

    static bool part2 = true;

    public static void Day1_ () {
        Console.WriteLine("\nStart Value: " + currentNum);
        for (int i = 0; i < inputLines.Length; i++) {
            Console.WriteLine("\nRun: " + (i+1));  // Track loop cycle
            lastNum = currentNum;

            // Collect info from strings
            LRIndicator = inputLines[i][0];
            inputNumStr = inputLines[i][1..];
            inputNum = int.Parse(inputNumStr);

            // Check Right (Addition) or Left (Subtraction)
            if (LRIndicator == 'R') {
                currentNum += inputNum;
                trueNum = currentNum;
            }
            if (LRIndicator == 'L') {
                currentNum -= inputNum;
                trueNum = currentNum;
            }

            // Check if new Num is 0 to 99
            if (currentNum >= 0 && currentNum <= 99) {
                if (currentNum == 0) zeroCounter++;
                Console.WriteLine(LRIndicator + "" + inputNum + "\nCurrent Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
                // Console.WriteLine(currentNum);
                continue;
            }

            // If Num is not 0 to 99, correct overflowed value
            if (LRIndicator == 'R') {
                int correctionMultiple = (int)(currentNum / 100);
                Console.WriteLine("R" + inputNum + "   Subtraction Multiple: " + correctionMultiple  + "   Subtraction Value: " + (correctionMultiple * 100));
                currentNum -= correctionMultiple * 100;

                zeroCounter += correctionMultiple;
                // Console.WriteLine("CorrectionMultiple: " + correctionMultiple);
            }
            if (LRIndicator == 'L') {
                int correctionMultiple = (int)(-currentNum / 100);
                // Console.WriteLine("L" + inputNum);
                Console.Write("L" + inputNum);
                if (correctionMultiple == 0) correctionMultiple = 1;
                currentNum += correctionMultiple * 100;

                if (currentNum < 0) {
                    currentNum += 100;
                    correctionMultiple++;
                }
                
                if (trueNum < 0 && lastNum == 0 && trueNum > -100) {
                    correctionMultiple--;
                }
                zeroCounter += correctionMultiple;
                Console.WriteLine("   Addition Multiple: " + (correctionMultiple == 0 ? 1 : correctionMultiple) + "   Addition Value: " + ((correctionMultiple == 0 ? 1 : correctionMultiple) * 100));
                // Console.WriteLine("CorrectionMultiple: " + correctionMultiple);
            }
            // Console.WriteLine(currentNum);

            // Check if new Num is now 0
            // if (currentNum == 0) zeroCounter++;

            Console.WriteLine("Current Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
        }
    }
}

// 1
//
// 3
//
// 5
// 6
//
// 8
//
// 10
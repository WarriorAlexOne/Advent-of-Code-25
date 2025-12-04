class Day1 {
    static readonly string[] inputLines = File.ReadAllLines("input_day1.txt");
    static int currentNum = 50;
    static int zeroCounter = 0;

    public static void Day1_Part1 () {
        for (int i = 0; i < inputLines.Length; i++) {
            Console.WriteLine("\nRun: " + (i+1));  // Track loop cycle

            // Collect info from strings
            char LRIndicator = inputLines[i][0];
            string inputNumStr = inputLines[i][1..];
            int inputNum = int.Parse(inputNumStr);

            // Check Right (Addition) or Left (Subtraction)
            if (LRIndicator == 'R') currentNum += inputNum;
            if (LRIndicator == 'L') currentNum -= inputNum;

            // Check if new Num is 0 to 99
            if (currentNum >= 0 && currentNum <= 99) {
                if (currentNum == 0) zeroCounter++;
                Console.WriteLine(LRIndicator + "" + inputNum + "\nCurrent Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
                continue;
            }

            // If Num is not 0 to 99, correct overflowed value
            if (LRIndicator == 'R') {
                int correctionMultiple = (int)(currentNum / 100);
                Console.WriteLine("R" + inputNum + "   Subtraction Multiple: " + correctionMultiple  + "   Subtraction Value: " + (correctionMultiple * 100));
                currentNum -= correctionMultiple * 100;

                Console.WriteLine("CorrectionMultiple: " + correctionMultiple);
            }
            if (LRIndicator == 'L') {
                int correctionMultiple = (int)(-currentNum / 100);
                Console.WriteLine("L" + inputNum + "   Addition Multiple: " + (correctionMultiple == 0 ? 1 : correctionMultiple) + "   Addition Value: " + ((correctionMultiple == 0 ? 1 : correctionMultiple) * 100));
                if (correctionMultiple == 0) correctionMultiple = 1;
                currentNum += correctionMultiple * 100;
                
                Console.WriteLine("CorrectionMultiple: " + correctionMultiple);
            }

            // Check if new Num is now 0
            if (currentNum == 0) zeroCounter++;

            Console.WriteLine("Current Value: " + currentNum + "   Zero's Detected: " + zeroCounter);
        }
    }

    public static void Day1_Part2 () {
        for (int i = 0; i < inputLines.Length; i++) {
            Console.WriteLine("\nRun: " + (i+1));
            
            // Collect info from strings
            char LRIndicator = inputLines[i][0];
            string inputNumStr = inputLines[i][1..];
            int inputNum = int.Parse(inputNumStr);

            if (LRIndicator == 'R') {
                for (int j = 0; j < inputNum; j++) {
                    currentNum++;
                    if (currentNum > 99) {
                        currentNum = 0;
                        zeroCounter++;
                    }
                }
                Console.WriteLine("Count: " + currentNum);
            }
            if (LRIndicator == 'L') {
                for (int j = 0; j < inputNum; j++) {
                    currentNum--;
                    if (currentNum == 0) zeroCounter++;
                    if (currentNum < 0) currentNum = 99;
                }
                Console.WriteLine("Count: " + currentNum);
            }
            Console.WriteLine("Zeros: " + zeroCounter);
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
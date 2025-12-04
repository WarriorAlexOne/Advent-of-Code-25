class Day2 {
    static readonly string input = File.ReadAllText("input_day2.txt");
    static string[] numberStrings = input.Split(',');
    static string[] ?numberPair;
    static long result = 0;
    public static void Day2_Part1 () {
        for (int i = 0; i < numberStrings.Length; i++) {
            numberPair = numberStrings[i].Split('-');
            long num1 = long.Parse(numberPair[0]);
            long num2 = long.Parse(numberPair[1]);

            for (long j = num1; j <= num2; j++) {
                string numStr = j.ToString();

                if (numStr.Length % 2 != 0) continue;

                string numHalf1 = numStr[..(numStr.Length/2)];
                string numHalf2 = numStr[(numStr.Length/2)..];

                if (numHalf1 == numHalf2) {
                    result += j;
                }
            }
        }
        Console.WriteLine("Result: " + result);
    }

    public static void Day2_Part2 () {
        
    }
}

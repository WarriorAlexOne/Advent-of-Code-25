class AoC25 {
    public static void Main (string[] args) {
        if (args.Length <= 0) {
            Console.WriteLine("No Args!!!");
            return;
        }
        
        switch (args[0]) {
            default:
                Console.WriteLine("Invalid Argument! Please type day<number>part<number> to run code for that Advent of Code 2025 day.");
                break;
            case "day1part1":
                Day1.Day1_Part1();
                break;
            case "day1part2":
                Day1.Day1_Part2();
                break;
        }

        Console.WriteLine();
    }
}

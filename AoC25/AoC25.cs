class AoC25 {
    public static void Main (string[] args) {
        if (args.Length <= 0) {
            Console.WriteLine("No Args!!!");
            return;
        }
        
        switch (args[0]) {
            default:
                Console.WriteLine("Invalid Args!!!");
                break;
            case "1":
                Day1.Day1_();
                break;
        }
    }
}

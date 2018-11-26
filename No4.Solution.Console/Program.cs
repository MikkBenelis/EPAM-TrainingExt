namespace No4.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRandomFileGenerator randomFileGenerator;
            
            randomFileGenerator = new RandomBytesFileGenerator(@"C:/Users/Mikk/Desktop", ".bytes");
            randomFileGenerator.GenerateRandomFile(100);

            randomFileGenerator = new RandomCharsFileGenerator(@"C:/Users/Mikk/Desktop", ".chars");
            randomFileGenerator.GenerateRandomFile(100);
        }
    }
}

using System.Collections.Generic;

namespace No5.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parts = new List<DocumentPart>
            {
                new PlainText(),
                new Hyperlink(),
                new BoldText()
            };

            Document document = new Document(parts);
            System.Console.WriteLine("Plain text:");
            System.Console.WriteLine(document.ToPlainText());
            System.Console.WriteLine("HTML:");
            System.Console.WriteLine(document.ToHTML());
            System.Console.WriteLine("LaTeX:");
            System.Console.WriteLine(document.ToLaTeX());
        }
    }
}

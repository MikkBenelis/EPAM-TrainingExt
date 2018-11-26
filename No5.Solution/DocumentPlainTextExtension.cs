using System;

namespace No5.Solution
{
    public static class DocumentPlainTextExtension
    {
        private static string toPlainText(DocumentPart part)
        {
            if (part is PlainText)
            {
                return part.Text;
            }
            else if (part is Hyperlink)
            {
                return part.Text;
            }
            else if (part is BoldText)
            {
                return part.Text;
            }

            throw new NotImplementedException();
        }

        public static string ToPlainText(this Document document)
        {
            string output = string.Empty;

            foreach (DocumentPart part in document.parts)
            {
                output += $"{toPlainText(part)}\n";
            }

            return output;
        }
    }
}

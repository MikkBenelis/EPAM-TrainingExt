using System;

namespace No5.Solution
{
    public static class DocumentLaTeXExtenstion
    {
        private static string toLaTeX(DocumentPart part)
        {
            if (part is PlainText)
            {
                return part.Text;
            }
            else if (part is Hyperlink)
            {
                return "\\href{" + (part as Hyperlink).Url + "}{" + part.Text + "}";
            }
            else if (part is BoldText)
            {
                return "\\textbf{" + part.Text + "}";
            }

            throw new NotImplementedException();
        }

        public static string ToLaTeX(this Document document)
        {
            string output = string.Empty;

            foreach (DocumentPart part in document.parts)
            {
                output += $"{toLaTeX(part)}\n";
            }

            return output;
        }
    }
}

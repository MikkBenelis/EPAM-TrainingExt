using System;

namespace No5.Solution
{
    public static class DocumentHTMLExtension
    {
        private static string toHTML(DocumentPart part)
        {
            if (part is PlainText)
            {
                return part.Text;
            }
            else if (part is Hyperlink)
            {
                return "<a href=\"" + (part as Hyperlink).Url + "\">" + part.Text + "</a>";
            }
            else if (part is BoldText)
            {
                return "<b>" + part.Text + "</b>";
            }

            throw new NotImplementedException();
        }

        public static string ToHTML(this Document document)
        {
            string output = string.Empty;

            foreach (DocumentPart part in document.parts)
            {
                output += $"{toHTML(part)}\n";
            }

            return output;
        }
    }
}

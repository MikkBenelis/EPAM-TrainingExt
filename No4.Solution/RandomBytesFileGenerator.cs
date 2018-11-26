using System;

namespace No4.Solution
{
    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        public RandomBytesFileGenerator(string directory, string extension) : base(directory, extension)
        {
        }

        public sealed override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();
            var fileContent = new byte[contentLength];
            random.NextBytes(fileContent);
            return fileContent;
        }
    }
}
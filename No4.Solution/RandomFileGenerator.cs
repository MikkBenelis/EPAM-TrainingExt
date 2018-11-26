using System;
using System.IO;

namespace No4.Solution
{
    public abstract class RandomFileGenerator : IRandomFileGenerator
    {
        private readonly string workingDirectory;
        private readonly string fileExtension;

        public RandomFileGenerator(string directory, string extension)
        {
            workingDirectory = directory;
            fileExtension = extension;
        }

        public void GenerateRandomFile(int contentLength)
        {
            GenerateRandomFiles(1, contentLength);
        }

        public void GenerateRandomFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);
                var generatedFileName = $"{Guid.NewGuid()}{this.fileExtension}";
                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        public abstract byte[] GenerateFileContent(int contentLength);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(workingDirectory))
            {
                Directory.CreateDirectory(workingDirectory);
            }

            File.WriteAllBytes($"{workingDirectory}//{fileName}", content);
        }
    }
}

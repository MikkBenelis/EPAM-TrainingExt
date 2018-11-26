namespace No4.Solution
{
    public interface IRandomFileGenerator
    {
        void GenerateRandomFile(int contentLength);
        void GenerateRandomFiles(int filesCount, int contentLength);
        byte[] GenerateFileContent(int contentLength);
    }
}

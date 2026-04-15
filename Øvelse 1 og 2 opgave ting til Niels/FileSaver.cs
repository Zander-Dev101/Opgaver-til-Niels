namespace Øvelse_1_og_2_opgave_ting_til_Niels;

public abstract class FileSaver
{
    public abstract string Save(string fileName, string content);

    protected static string BuildFilePath(string folderPath, string fileName)
    {
        Directory.CreateDirectory(folderPath);
        return Path.Combine(folderPath, fileName);
    }

    protected static string FindProjectRoot()
    {
        DirectoryInfo? currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (currentDirectory != null)
        {
            bool hasProjectFile = currentDirectory
                .GetFiles("*.csproj", SearchOption.TopDirectoryOnly)
                .Length > 0;

            if (hasProjectFile)
            {
                return currentDirectory.FullName;
            }

            currentDirectory = currentDirectory.Parent;
        }

        return Directory.GetCurrentDirectory();
    }
}
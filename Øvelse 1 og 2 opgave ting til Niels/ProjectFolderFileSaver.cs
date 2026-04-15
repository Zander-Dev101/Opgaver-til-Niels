namespace Øvelse_1_og_2_opgave_ting_til_Niels;

public class ProjectFolderFileSaver : FileSaver
{
    public override string Save(string fileName, string content)
    {
        string projectPath = FindProjectRoot();
        string filePath = BuildFilePath(projectPath, fileName);

        File.WriteAllText(filePath, content);

        return filePath;
    }
}
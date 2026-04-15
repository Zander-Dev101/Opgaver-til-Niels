namespace Øvelse_1_og_2_opgave_ting_til_Niels;

public class UserFolderFileSaver : FileSaver
{
    public override string Save(string fileName, string content)
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        if (string.IsNullOrWhiteSpace(folderPath))
        {
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        string filePath = BuildFilePath(folderPath, fileName);
        File.WriteAllText(filePath, content);

        return filePath;
    }
}
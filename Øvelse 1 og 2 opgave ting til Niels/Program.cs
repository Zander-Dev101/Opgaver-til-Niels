using Øvelse_1_og_2_opgave_ting_til_Niels;

Console.Write("Indtast ord du vil søge efter: ");
string searchWord = Console.ReadLine() ?? string.Empty;

Console.Write("Indtast tekst: ");
string text = Console.ReadLine() ?? string.Empty;

Result<int> wordCountResult = WordCount(searchWord, text);

if (!wordCountResult.IsSuccess)
{
    Console.WriteLine(wordCountResult.ErrorMessage);
}
else
{
    int count = wordCountResult.Value;
    bool? analysisResult = AnalyzeCount(count);

    Console.WriteLine(GetMessage(searchWord, count, analysisResult));

    if (analysisResult == true)
    {
        Console.Write("Vælg hvor filen skal gemmes (1 = user folder, 2 = projekt): ");
        string saveChoice = Console.ReadLine() ?? string.Empty;

        FileSaver saver = saveChoice == "1"
            ? new UserFolderFileSaver()
            : new ProjectFolderFileSaver();

        string savedPath = saver.Save("output.txt", text);
        Console.WriteLine($"Fil gemt her: {savedPath}");
    }
}

Console.WriteLine();
Console.Write("Skriv en værdi til dynamic-metoden: ");
string dynamicInput = Console.ReadLine() ?? string.Empty;
dynamic dynamicValue = ParseDynamicInput(dynamicInput);
dynamic dynamicResult = ProcessDynamicValue(dynamicValue);
Console.WriteLine($"Dynamic resultat: {dynamicResult}");

Console.WriteLine("Dynamic kan være farligt, fordi fejl ofte først opdages, når programmet kører.");

static Result<int> WordCount(string word, string text)
{
    if (string.IsNullOrWhiteSpace(word))
    {
        return Result<int>.Failure("Fejl: ordet du vil søge efter må ikke være tomt.");
    }

    if (string.IsNullOrWhiteSpace(text))
    {
        return Result<int>.Failure("Fejl: teksten du vil søge i må ikke være tom.");
    }

    word = word.ToLowerInvariant();
    text = text.ToLowerInvariant();

    int count = 0;
    int index = 0;

    while ((index = text.IndexOf(word, index, StringComparison.Ordinal)) != -1)
    {
        count++;
        index += word.Length;
    }

    return Result<int>.Success(count);
}

static bool? AnalyzeCount(int count)
{
    if (count == 0)
    {
        return null;
    }

    if (count < 10)
    {
        return false;
    }

    return true;
}

static string GetMessage(string word, int count, bool? result)
{
    if (result == null)
    {
        return "Det søgte ord findes ikke i den angivne tekst.";
    }

    return $"Ordet '{word}' forekommer {count} gange.";
}

static dynamic ParseDynamicInput(string input)
{
    if (int.TryParse(input, out int number))
    {
        return number;
    }

    if (bool.TryParse(input, out bool boolean))
    {
        return boolean;
    }

    return input;
}

static dynamic ProcessDynamicValue(dynamic value)
{
    if (value is int number)
    {
        return 100 + number;
    }

    if (value is string textValue)
    {
        return $"Følgende tekst modtaget: {textValue}";
    }

    return false;
}

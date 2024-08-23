using Fire_Emblem_View;

namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;
    
    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public void Play() {
        ReadTeamsFile();
    }

    private void ReadTeamsFile() {
        string[] filePathNames = Directory.GetFiles(_teamsFolder);
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < filePathNames.Length; i++) {
            _view.WriteLine($"{i}: {ReturnFileName(filePathNames[i])}");
        }
        int input = int.Parse(_view.ReadLine());
        string selectedFile = ReturnNormalizedFilePath(filePathNames[input]);
        DeserializeUnits(selectedFile);
        
    }
    private string ReturnFileName(string filePath) {
        string fileName = filePath.Split("\\").Last();
        return fileName;
    }

    private string ReturnNormalizedFilePath(string filePath) {
        string[] filePathParts = filePath.Split("\\");
        return Path.Combine(filePathParts);
    }
    private void DeserializeUnits(string fileName) {
        string jsonString = File.ReadAllText(fileName);
        Console.WriteLine(jsonString);
    }
}
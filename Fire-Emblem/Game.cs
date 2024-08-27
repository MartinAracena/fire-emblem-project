using Fire_Emblem_View;
using Fire_Emblem.Configuration;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Serialization;

namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    private JsonDataLoader _jsonDataLoader;
    
    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;

        _unitCatalog = new UnitCatalog();
        _abilityCatalog= new AbilityCatalog();

        _jsonDataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        
        LoadGameSetup();

    }

    private void LoadGameSetup() {
        _jsonDataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _jsonDataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
    }
    
    public void Play() {
        
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
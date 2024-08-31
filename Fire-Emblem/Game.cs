using Fire_Emblem_View;
using Fire_Emblem.Configuration;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;
using Fire_Emblem.Serialization;

namespace Fire_Emblem;

public class Game {
    private GameView _gameView;
    private string _teamsFolder;
    private InputParser _inputParser;
    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    private JsonDataLoader _jsonDataLoader;
    private TeamBuilder _teamBuilder;

    private List<Player> _players;
    
    public Game(View view, string teamsFolder) {
        _gameView = new GameView(view);
        _teamsFolder = teamsFolder;
        
        _inputParser = new InputParser();
        _unitCatalog = new UnitCatalog();
        _abilityCatalog= new AbilityCatalog();
        _jsonDataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        _teamBuilder = new TeamBuilder(_unitCatalog, _abilityCatalog);

        _players = new List<Player>();
    }
    
    public void Play() {
        LoadGame();
    }
    
    private void LoadGame() {
        LoadCatalogs();
        LoadPlayers();
    }

    private void LoadCatalogs() {
        _jsonDataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _jsonDataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
    }

    private void LoadPlayers() {
        _players.Add(new Player(1));
        _players.Add(new Player(2));
    }

    private void LoadTeams(string input) {
        var playerTeams = _inputParser.ParseInput(input);
        foreach (var VARIABLE in playerTeams) {
            
        }
    }
    
    private void ReadTeamsFile() {
        string[] filePathNames = Directory.GetFiles(_teamsFolder);
        _gameView.SayToSelectFile();
        for (int i = 0; i < filePathNames.Length; i++) {
            _gameView.ShowFileSelection(i, ReturnFileName(filePathNames[i]));
        }

        int input = _gameView.ReadLine();
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
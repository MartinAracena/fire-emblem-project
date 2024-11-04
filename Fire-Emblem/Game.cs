using Fire_Emblem_View;
using Fire_Emblem.Combat;
using Fire_Emblem.Configuration;
using Fire_Emblem.Controllers;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;
using Fire_Emblem.Serialization;
using Fire_Emblem.Validation;

namespace Fire_Emblem;

public class Game {
    private GameView _gameView;
    private string _teamsFolder;
    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    private JsonDataLoader _jsonDataLoader;
    private TeamBuilder _teamBuilder;
    private TeamValidator _teamValidator;
    
    private GameController _gameController;

    private List<Player> _players;
    
    public Game(View view, string teamsFolder) {
        _gameView = new GameView(view);
        _teamsFolder = teamsFolder;
        
        _unitCatalog = new UnitCatalog();
        _abilityCatalog= new AbilityCatalog();
        _jsonDataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        _teamBuilder = new TeamBuilder(_unitCatalog, _abilityCatalog);
        _teamValidator = new TeamValidator();
        _players = new List<Player>();
    }
    
    public void Play() {
        if (!LoadGame()) {return;}
        _gameController.StartGame();
    }
    
    private bool LoadGame() {
        LoadCatalogs();
        LoadTeams();
        if (!ValidateTeams()) {return false;}
        LoadCombatSystem();
        return true;
    }

    private void LoadCatalogs() {
        _jsonDataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _jsonDataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
    }
    
    private void LoadTeams() {
        var (team1, team2) = _teamBuilder.BuildTeams(ReadTeamsFile());
        
        Player player1 = new Player(1);
        Player player2 = new Player(2);

        player1.AddTeam(team1);
        player2.AddTeam(team2);
        
        _players.Add(player1);
        _players.Add(player2);
    }
    
    private string ReadTeamsFile() {
        string[] filePathNames = Directory.GetFiles(_teamsFolder);
        _gameView.SayToSelectFile();
        for (int i = 0; i < filePathNames.Length; i++) {
            _gameView.ShowFileSelection(i, ReturnFileName(filePathNames[i]));
        }
        int input = _gameView.ReadLine();
        return ReturnNormalizedFilePath(filePathNames[input]);
        
    }
    private string ReturnFileName(string filePath) {
        string fileName = filePath.Split("\\").Last();
        return fileName;
    }

    private string ReturnNormalizedFilePath(string filePath) {
        string[] filePathParts = filePath.Split("\\");
        return Path.Combine(filePathParts);
    }
    private bool ValidateTeams() {
        foreach (var player in _players) {
            if (!_teamValidator.IsValid(player.Team)) {
                _gameView.SayThatATeamIsInvalid();
                return false;
            }
        }

        return true;
    }

    private void LoadCombatSystem() {
        _gameController = new GameController(_gameView, _players);
    }
}
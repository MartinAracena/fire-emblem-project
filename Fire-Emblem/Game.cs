using Fire_Emblem_View;
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
    
    private GameState _gameState;
    
    public Game(View view, string teamsFolder) {
        _gameView = new GameView(view);
        _teamsFolder = teamsFolder;
        
        _unitCatalog = new UnitCatalog();
        _abilityCatalog= new AbilityCatalog();
        _jsonDataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        _teamBuilder = new TeamBuilder(_unitCatalog, _abilityCatalog);
        _teamValidator = new TeamValidator();

        _gameState = new GameState();
    }
    
    public void Play() {
        if (!LoadGame()) {return;}
        _gameController.StartGame();
    }
    
    private bool LoadGame() {
        LoadPlayers();
        LoadCatalogs();
        if (!LoadTeams()) {return false;}
        LoadCombatSystem();
        return true;
    }
    
    private void LoadPlayers() {
        _gameState.PlayerOne = new Player(1);
        _gameState.PlayerTwo = new Player(2);
    }

    private void LoadCatalogs() {
        _jsonDataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _jsonDataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
    }
    
    private bool LoadTeams() {
        var (teamOne, teamTwo) = _teamBuilder.BuildTeams(ReadTeamsFile());
        _gameState.PlayerOne.AddTeam(teamOne);
        _gameState.PlayerTwo.AddTeam(teamTwo);
        return ValidateTeams(teamOne, teamTwo);
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
    private bool ValidateTeams(Team team1, Team team2) {
        if (!_teamValidator.IsValid(team1)) {
            _gameView.SayThatATeamIsInvalid();
            return false;
        }
        if (!_teamValidator.IsValid(team2)) {
            _gameView.SayThatATeamIsInvalid();
            return false;
        }

        return true;
    }

    private void LoadCombatSystem() {
        _gameController = new GameController(_gameView, _gameState);
    }
}
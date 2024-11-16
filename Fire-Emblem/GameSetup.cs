using Fire_Emblem.Configuration;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Model;
using Fire_Emblem.Serialization;
using Fire_Emblem.TeamRules;

namespace Fire_Emblem;

public class GameSetup {
    private GameView _gameView;
    private string _teamsFolder;
    private JsonDataLoader _dataLoader;
    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    private TeamBuilder _teamBuilder;
    private TeamRulesValidator _teamRulesValidator;
    private GameState _gameState;
    
    public GameSetup(GameView gameView, string teamsFolder) {
        _gameView = gameView;
        _teamsFolder = teamsFolder;
        _unitCatalog = new UnitCatalog();
        _abilityCatalog = new AbilityCatalog();
        _dataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        _dataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _dataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
        _teamBuilder = new TeamBuilder(_unitCatalog, _abilityCatalog);
        _gameState = new GameState();
    }

    public GameState LoadGame() {
        LoadRules();
        LoadPlayers();
        if (!LoadTeams()) {
            _gameView.SayThatATeamIsInvalid();
            return null;
        };
        return _gameState;
    }

    private void LoadRules() {
        var rules = new List<ITeamRule> {
            new MinimumTeamUnitCountRule(),
            new MaximumTeamUnitCountRule(),
            new MaximumDuplicateUnitCountRule(),
            new MaximumAbilitiesPerUnitRule(),
            new MaximumDuplicateAbilityCountPerUnitRule()
        };
        _teamRulesValidator = new TeamRulesValidator(rules);
    }
    
    private void LoadPlayers() {
        _gameState.PlayerOne = new Player(1);
        _gameState.PlayerTwo = new Player(2);
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
        if (!_teamRulesValidator.IsValid(team1)) {
            //_gameView.SayThatATeamIsInvalid();
            return false;
        }
        if (!_teamRulesValidator.IsValid(team2)) {
            //_gameView.SayThatATeamIsInvalid();
            return false;
        }

        return true;
    }
}
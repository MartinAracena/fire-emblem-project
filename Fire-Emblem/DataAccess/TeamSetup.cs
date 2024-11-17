using Fire_Emblem.Model;

namespace Fire_Emblem.DataAccess;

public class TeamSetup {
    private readonly GameView _gameView;
    private readonly TeamBuilder _teamBuilder;

    public TeamSetup(GameView gameView, TeamBuilder teamBuilder) {
        _gameView = gameView;
        _teamBuilder = teamBuilder;
    }

    public (Team, Team) LoadTeams(string teamsFolder) {
        var filePath = SelectTeamsFile(teamsFolder);
        return _teamBuilder.BuildTeams(filePath);
    }

    private string SelectTeamsFile(string folderPath) {
        var filePathNames = GetFilePaths(folderPath);
        ShowFileChoices(filePathNames);
        int input = _gameView.ReadLine();
        return filePathNames[input];
    }

    private string[] GetFilePaths(string folderPath) => Directory.GetFiles(folderPath);

    private void ShowFileChoices(string[] filePathNames) {
        _gameView.SayToSelectFile();
        for (int i = 0; i < filePathNames.Length; i++) {
            _gameView.ShowFileSelection(i, Path.GetFileName(filePathNames[i]));
        }
    }

}
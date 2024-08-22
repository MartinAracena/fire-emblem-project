using Fire_Emblem_View;

namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public void Play()
    {
        SelectFileToLoadTeams();
    }

    private void SelectFileToLoadTeams() {
        string[] files = Directory.GetFiles(_teamsFolder);
        _view.WriteLine($"Elige un archivo para cargar los equipos");
        for (int i = 0; i < files.Length; i++) {
            string fileName = files[i].Split("/")[2];
            Console
            _view.WriteLine($"{i}: {files[i]}");
        }
    }
}
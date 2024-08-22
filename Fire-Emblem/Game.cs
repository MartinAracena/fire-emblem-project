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
        LoadFileThatContainsTeams();
    }

    private void LoadFileThatContainsTeams() {
        string[] files = Directory.GetFiles(_teamsFolder);
        _view.WriteLine($"Elige un archivo para cargar los equipos");
        for (int i = 0; i < files.Length; i++)
        {
            string fileName = files[i].Split("\\")[2];
            _view.WriteLine($"{i}: {fileName}");
        }
        string input = _view.ReadLine();
        _view.WriteLine("Archivo de equipos no válido");
    }
}
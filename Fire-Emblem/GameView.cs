using Fire_Emblem_View;

namespace Fire_Emblem; 

public class GameView {
    private View _view;

    public GameView(View view) {
        _view = view;
    }

    public int ReadLine() {
        return int.Parse(_view.ReadLine());
    }

    public void SayToSelectFile() {
        _view.WriteLine("Elige un archivo para cargar los equipos");
    }

    public void ShowFileSelection(int index, string fileName) {
        _view.WriteLine($"{index}: {fileName}");
    }
}
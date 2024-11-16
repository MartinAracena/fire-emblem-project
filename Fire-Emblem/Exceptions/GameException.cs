namespace Fire_Emblem.Exceptions;

public class GameException : Exception {
    public GameException(string message, GameView gameView) : base(message) {
        gameView.WriteLine(message);
    }
}
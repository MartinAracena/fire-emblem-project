namespace Fire_Emblem.Exceptions;

public class InvalidTeamException(GameView gameView) : GameException("Archivo de equipos no válido", gameView);
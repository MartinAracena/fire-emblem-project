namespace Fire_Emblem.Configuration; 

public static class GameConfig {
    public static readonly string DefaultCharacterFilePath = "characters.json";
    public static readonly string DefaultAbilityFilePath = "skills.json";

    public static readonly string Player1TeamKey = "Player 1 Team";
    public static readonly string Player2TeamKey = "Player 2 Team";

    public static readonly string PlayerTeamPattern = @"^(?<unitName>[^\(]+)\s*\((?<abilities>[^\)]+)\)$";
    
    public static readonly int MinTeamUnits = 1;
    public static readonly int MaxTeamUnits = 3;

    public static readonly int MaxDuplicateUnits = 0;

    public static readonly int MaxAbilitiesPerUnit = 2;

    public static readonly int MaxDuplicateAbilitiesPerUnit = 0;


}
namespace Fire_Emblem.Configuration; 

public static class GameConfig {
    public static readonly string DefaultCharacterFilePath = "characters.json";
    
    public static readonly string DefaultAbilityFilePath = "skills.json";
    
    public static readonly int MinTeamUnits = 1;
    
    public static readonly int MaxTeamUnits = 3;

    public static readonly int MaxDuplicateUnits = 1;

    public static readonly int MaxAbilitiesPerUnit = 2;

    public static readonly int MaxDuplicateAbilitiesPerUnit = 1;

    public static readonly double WeaponTriangleBonus = 1.2;

    public static readonly double WeaponTrianglePenalty = 0.8;
    
    public static readonly int FollowUpSpeedDifferenceRequirement = 5;

}
namespace Fire_Emblem.Model; 

public class Team {
    public List<Unit> Units = new List<Unit>();

    public void AddUnit(Unit unit) {
        Units.Add(unit);
    }
}
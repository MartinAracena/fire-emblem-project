namespace Fire_Emblem.Model; 

public class Team {
    public List<Unit> Units = new List<Unit>();

    public void AddUnit(Unit unit) {
        Units.Add(unit);
    }

    public void RemoveUnit(Unit unit) {
        Units.Remove(unit);
    }

    public bool HasUnits() {
        return Units.Count > 0;
    }
}
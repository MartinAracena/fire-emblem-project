namespace Fire_Emblem.Model; 

public class Team {
    public List<Unit> Units = new List<Unit>();

    public void AddUnit(Unit unit) {
        Units.Add(unit);
        unit.UnitDefeated += RemoveUnit;
    }

    public void RemoveUnit(Unit unit) {
        Units.Remove(unit);
        unit.UnitDefeated -= RemoveUnit;
    }

    public bool HasUnits() {
        return Units.Count > 0;
    }
}
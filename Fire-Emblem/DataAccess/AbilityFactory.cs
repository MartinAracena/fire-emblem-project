using Fire_Emblem.Abilities.Conditions;
using Fire_Emblem.Abilities.Effects;
using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataAccess; 

public class AbilityFactory {
    public Ability CreateAbility(string abilityName, string description) {
        List<IEffect> effects = new List<IEffect>();
        List<ICondition> conditions = new List<ICondition>();
        
        switch (abilityName) {
            case "Attack +6":
                effects.Add(new StatBonusEffect(StatType.Atk, 6));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Speed +5":
                effects.Add(new StatBonusEffect(StatType.Spd, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Defense +5":
                effects.Add(new StatBonusEffect(StatType.Def, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Resistance +5":
                effects.Add(new StatBonusEffect(StatType.Res, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Atk/Def +5":
                effects.Add(new StatBonusEffect(StatType.Atk, 5));
                effects.Add(new StatBonusEffect(StatType.Def, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Atk/Res +5":
                effects.Add(new StatBonusEffect(StatType.Atk, 5));
                effects.Add(new StatBonusEffect(StatType.Res, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            case "Spd/Res +5":
                effects.Add(new StatBonusEffect(StatType.Spd, 5));
                effects.Add(new StatBonusEffect(StatType.Res, 5));
                conditions.Add(new CombatPhaseCondition(CombatPhase.StartOfCombat));
                break;
            default:
                effects.Add(new NoEffect());
                conditions.Add(new NoCondition());
                break;
        }

        return new Ability(
            abilityName,
            description,
            effects,
            conditions
        );
    }
}
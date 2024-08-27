using Fire_Emblem.Abilities.Conditions;
using Fire_Emblem.Abilities.Effects;
using Fire_Emblem.DataTransfer;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataManagement; 

public class AbilityCatalog {
    private Dictionary<string, AbilityInfo> _abilityInfos = new Dictionary<string, AbilityInfo>();

    public void AddAbility(AbilityInfo abilityInfo) {
        _abilityInfos.Add(abilityInfo.Name, abilityInfo);
    }

    public Ability GetAbility(string abilityName) {
        AbilityInfo abilityInfo = _abilityInfos[abilityName];
        List<IEffect> effects = new List<IEffect>();
        List<ICondition> conditions = new List<ICondition>();
        
        effects.Add(new NoEffect());
        conditions.Add(new NoCondition());
        
        return new Ability(
            abilityInfo.Name,
            abilityInfo.Description,
            effects,
            conditions
            );
    }

}
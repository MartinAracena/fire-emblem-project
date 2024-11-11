using Fire_Emblem.Abilities.Conditions;
using Fire_Emblem.Abilities.Effects;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataTransfer;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataManagement; 

public class AbilityCatalog {
    private Dictionary<string, AbilityInfo> _abilityInfos = new Dictionary<string, AbilityInfo>();

    public void AddAbility(AbilityInfo abilityInfo) {
        _abilityInfos.Add(abilityInfo.Name, abilityInfo);
    }

    public Skill GetAbility(string abilityName) {
        AbilityInfo abilityInfo = _abilityInfos[abilityName];
        return new Skill(abilityInfo.Name, abilityInfo.Description, new List<IEffect>(), new List<ICondition>());
    }
}
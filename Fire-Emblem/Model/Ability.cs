using Fire_Emblem.Abilities.Conditions;
using Fire_Emblem.Abilities.Effects;

namespace Fire_Emblem.Model;

public class Ability {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IEffect> Effects { get; set; }
    public List<ICondition> Conditions { get; set; }

    public Ability(string name, string description, List<IEffect> effects, List<ICondition> conditions) {
        Name = name;
        Description = description;
        Effects = effects;
        Conditions = conditions;
    }
}
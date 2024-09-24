using Fire_Emblem.Abilities.Conditions;
using Fire_Emblem.Abilities.Effects;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Model;

public class Ability {
    public string Name { get; set; }
    public string Description { get; set; }
    private List<IEffect> Effects { get; set; }
    private List<ICondition> Conditions { get; set; }

    public Ability(string name, string description, List<IEffect> effects, List<ICondition> conditions) {
        Name = name;
        Description = description;
        Effects = effects;
        Conditions = conditions;
    }
    
    public void Activate(Unit owner, CombatContext context) {
        if (Conditions.All(condition => condition.IsApplicable(owner, context))) {
            foreach (var effect in Effects) {
                effect.Apply(owner, context);
            }
        }
    }
    
    public void Deactivate(Unit owner, CombatContext context) {
        foreach (var effect in Effects) {
            effect.Remove(owner, context);
        }
    }
}
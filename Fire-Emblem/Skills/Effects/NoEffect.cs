using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Effects;

public class NoEffect : IEffect{
    public void Apply(Unit owner, CombatContext context) {
        throw new NotImplementedException();
    }

    public void Remove(Unit owner, CombatContext context) {
        throw new NotImplementedException();
    }
}
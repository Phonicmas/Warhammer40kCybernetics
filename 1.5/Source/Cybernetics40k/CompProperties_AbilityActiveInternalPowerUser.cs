using RimWorld;


namespace Cybernetics40k
{
    public class CompProperties_AbilityActiveInternalPowerUser : CompProperties_AbilityEffect
    {
        public int powerUsage;

        public CompProperties_AbilityActiveInternalPowerUser()
        {
            compClass = typeof(CompAbilityEffect_ActiveInternalPowerUser);
        }
    }
}
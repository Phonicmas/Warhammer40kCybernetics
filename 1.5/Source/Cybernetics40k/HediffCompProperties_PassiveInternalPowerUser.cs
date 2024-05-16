using Verse;

namespace Cybernetics40k
{
    public class HediffCompProperties_PassiveInternalPowerUser : HediffCompProperties
    {
        public int powerUsage;

        public int tickInterval = 2500;

        public bool disablesAttack = true;

        public HediffCompProperties_PassiveInternalPowerUser()
        {
            compClass = typeof(HediffComp_PassiveInternalPowerUser);
        }
    }
}
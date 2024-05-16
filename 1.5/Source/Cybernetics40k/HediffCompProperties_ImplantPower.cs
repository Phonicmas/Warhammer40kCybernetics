using Verse;


namespace Cybernetics40k
{
    public class HediffCompProperties_ImplantPower : HediffCompProperties
    {
        public int maxPower;

        public DamageDef drainByDamageDef;

        public bool passiveDrainNearby = false;

        public HediffCompProperties_ImplantPower()
        {
            compClass = typeof(HediffComp_ImplantPower);
        }
    }
}
using HarmonyLib;
using RimWorld;
using Verse;


namespace Cybernetics40k
{
    [DefOf]
    public static class Cybernetics40kDefOf
    {
        public static HediffDef BEWH_MechadendriteNeuralSystem;

        public static HediffDef BEWH_InternalResevoir;

        public static AbilityDef BEWH_PassiveRechargeOff;
        public static AbilityDef BEWH_PassiveRechargeOn;

        static Cybernetics40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Cybernetics40kDefOf));
        }
    }
}
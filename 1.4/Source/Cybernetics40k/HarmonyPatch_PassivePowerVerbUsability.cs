using HarmonyLib;
using Verse;

namespace Cybernetics40k
{
    [HarmonyPatch(typeof(HediffComp_VerbGiver), "Verse.IVerbOwner.VerbsStillUsableBy")]
    public class PassivePowerVerbUsability
    {
        public static void Postfix(ref bool __result, HediffComp_VerbGiver __instance)
        {
            HediffComp_PassiveInternalPowerUser passivePower = __instance.parent.TryGetComp<HediffComp_PassiveInternalPowerUser>();
            if (passivePower != null && passivePower.Props.disablesAttack)
            {
                HediffComp_ImplantPower ImplantPower = __instance.parent.pawn.health.hediffSet.hediffs.Find(x => x.TryGetComp<HediffComp_ImplantPower>() is HediffComp_ImplantPower h).TryGetComp<HediffComp_ImplantPower>();
                if (passivePower == null || ImplantPower == null || !ImplantPower.HasPower(passivePower.Props.powerUsage))
                {
                    __result = false;
                }
            }
        }
    }
}
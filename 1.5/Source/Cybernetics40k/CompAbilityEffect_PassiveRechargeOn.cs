using RimWorld;
using System.Collections.Generic;
using Verse;


namespace Cybernetics40k
{
    public class CompAbilityEffect_PassiveRechargeOn : CompAbilityEffect
    {
        List<Hediff> PowerImplants
        {
            get
            {
                return parent?.pawn?.health?.hediffSet?.hediffs?.FindAll(x => x.TryGetComp<HediffComp_ImplantPower>() != null);
            }
        }

        public new CompProperties_AbilityPassiveRechargeOn Props => (CompProperties_AbilityPassiveRechargeOn)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            if (PowerImplants.NullOrEmpty())
            {
                return;
            }
            foreach (Hediff hediff in PowerImplants)
            {
                HediffComp_ImplantPower hediffComp = hediff.TryGetComp<HediffComp_ImplantPower>();
                if (!hediffComp.PassiveRecharge)
                {
                    hediffComp.PassiveRecharge = true;
                }
                parent.pawn.abilities.RemoveAbility(Cybernetics40kDefOf.BEWH_PassiveRechargeOn);
                parent.pawn.abilities.GainAbility(Cybernetics40kDefOf.BEWH_PassiveRechargeOff);
            }
        }
    }
}
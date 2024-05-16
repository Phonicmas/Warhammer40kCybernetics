using RimWorld;
using System.Collections.Generic;
using Verse;


namespace Cybernetics40k
{
    public class CompAbilityEffect_PassiveRechargeOff : CompAbilityEffect
    {
        List<Hediff> PowerImplants
        {
            get
            {
                return parent?.pawn?.health?.hediffSet?.hediffs?.FindAll(x => x.TryGetComp<HediffComp_ImplantPower>() != null);
            }
        }

        public new CompProperties_AbilityPassiveRechargeOff Props => (CompProperties_AbilityPassiveRechargeOff)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            if (PowerImplants.NullOrEmpty())
            {
                return;
            }
            foreach (Hediff hediff in PowerImplants)
            {
                HediffComp_ImplantPower hediffComp = hediff.TryGetComp<HediffComp_ImplantPower>();
                if (hediffComp.PassiveRecharge)
                {
                    hediffComp.PassiveRecharge = false;
                    
                }
            }
            parent.pawn.abilities.RemoveAbility(Cybernetics40kDefOf.BEWH_PassiveRechargeOff);
            parent.pawn.abilities.GainAbility(Cybernetics40kDefOf.BEWH_PassiveRechargeOn);
        }
    }
}
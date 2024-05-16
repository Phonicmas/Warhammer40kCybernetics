using RimWorld;
using System.Collections.Generic;
using Verse;


namespace Cybernetics40k
{
    public class CompAbilityEffect_FerricLure : CompAbilityEffect
    {
        public new CompProperties_AbilityFerricLure Props => (CompProperties_AbilityFerricLure)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Thing thing = (Thing)target;
            if (thing.def.IsRangedWeapon || thing.def.IsMeleeWeapon)
            {
                if (parent.pawn.equipment.HasAnything())
                {
                    parent.pawn.equipment.TryTransferEquipmentToContainer(parent.pawn.equipment.Primary, parent.pawn.inventory.innerContainer);
                }
                parent.pawn.equipment.AddEquipment((ThingWithComps)thing.SplitOff(thing.stackCount));
            }
            else
            {
                parent.pawn.inventory.innerContainer.TryAdd(thing.SplitOff(thing.stackCount));
            }
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Thing thing = (Thing)target;
            if (thing.def.category != ThingCategory.Item)
            {
                return false;
            }

            return base.Valid(target, throwMessages);
        }
    }
}
﻿using HarmonyLib;
using RimWorld;
using Verse;


namespace Cybernetics40k
{
    [DefOf]
    public static class Cybernetics40kDefOf
    {
        public static HediffDef BEWH_MechadendriteNeuralSystem;

        static Cybernetics40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Cybernetics40kDefOf));
        }
    }
}
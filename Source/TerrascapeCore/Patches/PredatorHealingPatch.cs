using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
using System.Reflection;
using HarmonyLib;

namespace TerrascapeCore
{

    //[HarmonyPatch(typeof(Toils_Ingest), "FinalizeIngest")]
    //static class Toils_IngestPatch
    //{
    //    static void Postfix(Pawn ingester)
    //    {
    //        if (!Terrascape_Settings.enablePredatorHealing || ingester == null)
    //        {
    //            return;
    //        }
    //        if (ingester.Faction != null)
    //        {
    //            return;
    //        }
    //        if (!ingester.AnimalOrWildMan())
    //        {
    //            return;
    //        }
    //        if (ingester.health.hediffSet.hediffs.Where((Hediff hd) => hd.Bleeding) == null)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            ingester.health.AddHediff(TSDefOf.TS_Hediff_PredatorHealing);
    //        }
    //    }
    //}
}
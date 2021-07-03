using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace TerrascapeCore
{
    //public class HediffComp_PredatorHealing : HediffComp
    //{
    //    private int ticksToTend;

    //    public HediffCompProperties_PredatorHealing Props => (HediffCompProperties_PredatorHealing)props;

    //    public override void CompPostMake()
    //    {
    //        base.CompPostMake();
    //        ResetTicksToTend();
    //    }

    //    private void ResetTicksToTend()
    //    {
    //        ticksToTend = Rand.Range(Props.minTicksToTend, Props.maxTicksToTend);
    //    }

    //    public override void CompPostTick(ref float severityAdjustment)
    //    {
    //        ticksToTend--;
    //        if (ticksToTend <= 0)
    //        {
    //            TryTendRandomWounds();
    //            ResetTicksToTend();
    //        }
    //    }

    //    public void TryTendRandomWounds()
    //    {
    //        List<Hediff> bleedingWounds = (List<Hediff>)base.Pawn.health.hediffSet.hediffs.Where((Hediff hd) => hd.Bleeding);
    //        if (bleedingWounds.NullOrEmpty())
    //        {
    //            base.Pawn.health.RemoveHediff(parent);
    //        }
    //        for (int i = 0; i < Rand.RangeInclusive(1,Props.maxWoundsTendedPerTry); i++)
    //        {
    //            if (Rand.Value <= Props.tendChance)
    //            {
    //                bleedingWounds.RandomElement<Hediff>().Tended_NewTemp(Props.tendQuality, Props.maxTendQuality);
    //            }
    //        }
    //    }
    //}

    //public class HediffCompProperties_PredatorHealing : HediffCompProperties
    //{
    //    public int minTicksToTend = 625;
    //    public int maxTicksToTend = 2500;
    //    public int maxWoundsTendedPerTry = 3;
    //    public float tendQuality = 1;
    //    public float maxTendQuality = 1;
    //    public float tendChance = 0.75f;
    //    public HediffCompProperties_PredatorHealing()
    //    {
    //        compClass = typeof(HediffComp_PredatorHealing);
    //    }
    //}
}

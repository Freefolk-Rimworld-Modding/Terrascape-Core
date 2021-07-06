using RimWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Verse;

namespace TerrascapeCore
{
    public class CompForaging : ThingComp
    {
        public int foragingInterval = 0;
        private Effecter effecter;

        public CompProperties_Foraging Props
        {
            get
            {
                return (CompProperties_Foraging)this.props;
            }
        }

        public void SpawnCustomThing()
        {

        }

        public override void CompTick()
        {
            base.CompTick();
            Pawn pawn = this.parent as Pawn;
            if (Terrascape_Settings.enableAnimalForaging && pawn.Map != null && pawn.Awake() && pawn.needs.food.CurLevelPercentage < pawn.needs.food.PercentageThreshHungry)
            {
                if (pawn.Position.GetTerrain(pawn.Map).affordances.Contains(TerrainAffordanceDefOf.Diggable))
                {
                    if (foragingInterval <= 0)
                    {
                        if (Props.acceptableTerrain != null)
                        {
                            if (Props.acceptableTerrain.Contains(pawn.Position.GetTerrain(pawn.Map).defName))
                            {
                                Thing newcorpse;

                                string thingToDig = this.Props.thingsToForage.RandomElement();
                                int index = Props.thingsToForage.IndexOf(thingToDig);
                                int amount;
                                if (Props.amountsToForage != null)
                                {
                                    amount = Props.amountsToForage[index];

                                }
                                else
                                {
                                    amount = Props.defaultAmountsToForage;
                                }
                                ThingDef newThing = ThingDef.Named(thingToDig);
                                newcorpse = GenSpawn.Spawn(newThing, pawn.Position, pawn.Map, WipeMode.Vanish);
                                newcorpse.stackCount = amount;
                                newcorpse.SetForbidden(true);
                                if (this.effecter == null)
                                {
                                    this.effecter = EffecterDefOf.Mine.Spawn();
                                }
                                this.effecter.Trigger(pawn, newcorpse);
                            }
                        }
                        foragingInterval = Props.timeToDig;
                    }
                    foragingInterval--;
                }
            }
        }
    }

    public class CompProperties_Foraging : CompProperties
    {

        //A list of things to forage for.
        public List<string> thingsToForage = null;

        //A corresponding list of amounts of extra things that can be dug up.
        public List<int> amountsToForage = null;

        //Default amount to forage if none are listed.
        public int defaultAmountsToForage = 10;

        //A list of acceptable terrains can be specified
        public List<string> acceptableTerrain = null;

        //timeToDig has a misleading name. It is a minimum counter. The user will not dig if less than timeToDig ticks have passed.
        //This is done to avoid an animal digging again if it's still hungry.
        public int timeToDig = 40000;

        //Should items be spawned forbidden?
        public bool spawnForbidden = false;

        public CompProperties_Foraging()
        {
            this.compClass = typeof(CompForaging);
        }


    }
}


using RimWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Verse;

namespace TerrascapeCore
{
    public class CompForaging : ThingComp
    {
        public int stopdiggingcounter = 0;
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
                    if (stopdiggingcounter <= 0)
                    {
                        if (Props.acceptedTerrains != null)
                        {
                            if (Props.acceptedTerrains.Contains(pawn.Position.GetTerrain(pawn.Map).defName))
                            {
                                Thing newcorpse;
                                if (Props.customThingsToDig != null)
                                {
                                    string thingToDig = this.Props.customThingsToDig.RandomElement();
                                    int index = Props.customThingsToDig.IndexOf(thingToDig);
                                    int amount;
                                    if (Props.customAmountsToDig != null)
                                    {
                                        amount = Props.customAmountsToDig[index];

                                    }
                                    else
                                    {
                                        amount = Props.customAmountToDig;
                                    }
                                    ThingDef newThing = ThingDef.Named(thingToDig);
                                    newcorpse = GenSpawn.Spawn(newThing, pawn.Position, pawn.Map, WipeMode.Vanish);
                                    newcorpse.stackCount = amount;
                                }
                                else
                                {
                                    ThingDef newThing = ThingDef.Named(this.Props.customThingToDig);
                                    newcorpse = GenSpawn.Spawn(newThing, pawn.Position, pawn.Map, WipeMode.Vanish);
                                    newcorpse.stackCount = this.Props.customAmountToDig;
                                }
                                newcorpse.SetForbidden(true);
                                if (this.effecter == null)
                                {
                                    this.effecter = EffecterDefOf.Mine.Spawn();
                                }
                                this.effecter.Trigger(pawn, newcorpse);

                            }
                        }
                        else
                        {
                            Thing newcorpse;
                            if (Props.customThingsToDig != null)
                            {
                                string thingToDig = this.Props.customThingsToDig.RandomElement();
                                int index = Props.customThingsToDig.IndexOf(thingToDig);
                                int amount;
                                if (Props.customAmountsToDig != null)
                                {
                                    amount = Props.customAmountsToDig[index];

                                }
                                else
                                {
                                    amount = Props.customAmountToDig;
                                }
                                ThingDef newThing = ThingDef.Named(thingToDig);
                                newcorpse = GenSpawn.Spawn(newThing, pawn.Position, pawn.Map, WipeMode.Vanish);
                                newcorpse.stackCount = amount;
                            }
                            else
                            {
                                ThingDef newThing = ThingDef.Named(this.Props.customThingToDig);
                                newcorpse = GenSpawn.Spawn(newThing, pawn.Position, pawn.Map, WipeMode.Vanish);
                                newcorpse.stackCount = this.Props.customAmountToDig;
                            }
                            if (Props.spawnForbidden)
                            {
                                newcorpse.SetForbidden(true);
                            }
                            if (this.effecter == null)
                            {
                                this.effecter = EffecterDefOf.Mine.Spawn();
                            }
                            this.effecter.Trigger(pawn, newcorpse);
                        }





                        stopdiggingcounter = Props.timeToDig;
                    }
                    stopdiggingcounter--;
                }
            }
        }
    }

    public class CompProperties_Foraging : CompProperties
    {

        //A list of terrain that can be foraged on, with the items found in each
        public List<string> thingsToForage = null;
        //A corresponding list of amounts of extra things that can be dug up, will default to customAmountToDig if not set.
        public List<int> customAmountsToDig = null;

        public 

        //A list of acceptable terrains can be specified
        public List<string> acceptableTerrains = null;

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


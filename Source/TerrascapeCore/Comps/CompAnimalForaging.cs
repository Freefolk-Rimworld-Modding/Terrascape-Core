using RimWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Verse;

namespace TerrascapeCore
{
    //public class compforaging : thingcomp
    //{
    //    public int foraginginterval = 0;
    //    private effecter effecter;

    //    public compproperties_foraging props
    //    {
    //        get
    //        {
    //            return (compproperties_foraging)this.props;
    //        }
    //    }

    //    public void spawncustomthing()
    //    {

    //    }

    //    public override void comptick()
    //    {
    //        base.comptick();
    //        pawn pawn = this.parent as pawn;
    //        if (terrascape_settings.enableanimalforaging && pawn.map != null && pawn.awake() && pawn.needs.food.curlevelpercentage < pawn.needs.food.percentagethreshhungry)
    //        {
    //            if (pawn.position.getterrain(pawn.map).affordances.contains(terrainaffordancedefof.diggable))
    //            {
    //                if (foraginginterval <= 0)
    //                {
    //                    if (props.acceptableterrain != null)
    //                    {
    //                        if (props.acceptableterrain.contains(pawn.position.getterrain(pawn.map).defname))
    //                        {
    //                            thing newcorpse;

    //                            string thingtodig = this.props.thingstoforage.randomelement();
    //                            int index = props.thingstoforage.indexof(thingtodig);
    //                            int amount;
    //                            if (props.amountstoforage != null)
    //                            {
    //                                amount = props.amountstoforage[index];

    //                            }
    //                            else
    //                            {
    //                                amount = props.defaultamountstoforage;
    //                            }
    //                            thingdef newthing = thingdef.named(thingtodig);
    //                            newcorpse = genspawn.spawn(newthing, pawn.position, pawn.map, wipemode.vanish);
    //                            newcorpse.stackcount = amount;
    //                            newcorpse.setforbidden(true);
    //                            if (this.effecter == null)
    //                            {
    //                                this.effecter = effecterdefof.mine.spawn();
    //                            }
    //                            this.effecter.trigger(pawn, newcorpse);
    //                        }
    //                    }
    //                    foraginginterval = props.timetodig;
    //                }
    //                foraginginterval--;
    //            }
    //        }
    //    }
    //}

    //public class compproperties_foraging : compproperties
    //{

    //    //a list of things to forage for.
    //    public list<string> thingstoforage = null;

    //    //a corresponding list of amounts of extra things that can be dug up.
    //    public list<int> amountstoforage = null;

    //    //default amount to forage if none are listed.
    //    public int defaultamountstoforage = 10;

    //    //a list of acceptable terrains can be specified
    //    public list<string> acceptableterrain = null;

    //    //timetodig has a misleading name. it is a minimum counter. the user will not dig if less than timetodig ticks have passed.
    //    //this is done to avoid an animal digging again if it's still hungry.
    //    public int timetodig = 40000;

    //    //should items be spawned forbidden?
    //    public bool spawnforbidden = false;

    //    public compproperties_foraging()
    //    {
    //        this.compclass = typeof(compforaging);
    //    }


    //}
}


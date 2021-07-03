using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using Verse.AI;
using UnityEngine;

namespace TerrascapeCore
{
    public class GenStep_RootedPlants : GenStep
    {

        public override int SeedPart => 578425222;

        public override void Generate(Map map, GenStepParams parms)
        {
            map.regionAndRoomUpdater.Enabled = false;

            // since we're looping through the list, we need to prevent new roots from being added to the list mid-loop
            // this filters the list of plants to only include plants with the comp, instead of listing all plants
            List<Thing> plantList = map.listerThings.ThingsInGroup(ThingRequestGroup.HarvestablePlant).Where(p => p.TryGetComp<CompRootedPlant>() != null).ToList();

            foreach (Thing plant in plantList)
            {
                CompRootedPlant comp = plant.TryGetComp<CompRootedPlant>();

                int rootCount = Rand.RangeInclusive(0, comp.Props.maxRoots);
                comp.IsGenStep = true;
                for (int i = 0; i < rootCount; i++)
                {
                    comp.GrowRoot();
                }
                comp.IsGenStep = false;
            }

            map.regionAndRoomUpdater.Enabled = true;
        }
    }
}


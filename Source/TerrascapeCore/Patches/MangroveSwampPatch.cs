using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Noise;

namespace TerrascapeCore
{
    [HarmonyPatch(typeof(GenStep_ElevationFertility), "Generate")]
    static class MangroveSwampPatch
    {
        static void Postfix(Map map, GenStepParams parms)
        {
            if(!map.Biome.HasModExtension<BiomeExtension>())
            {
                return;
            }

            if (!map.Biome.GetModExtension<BiomeExtension>().IsMangroveSwamp)
            {
                return;
            }


            MapGenFloatGrid fertility = MapGenerator.Fertility;

            // this will help create the characteristic shapes
            foreach (IntVec3 current in map.AllCells)
            {
                fertility[current] = Math.Abs(fertility[current] - 0.5f);
            }

            if (!map.Biome.GetModExtension<BiomeExtension>().customBeach)
            {
                return;
            }

            // generate the custom beach
            Rot4 rot = Find.World.CoastDirectionAt(map.Tile);
            if (!rot.IsValid)
            {
                return;
            }

            ModuleBase input2 = new DistFromAxis(new FloatRange(20f, 60f).RandomInRange);
            if (rot == Rot4.North)
            {
                input2 = new Rotate(0.0, 90.0, 0.0, input2);
                input2 = new Translate(0.0, 0.0, -map.Size.z, input2);
            }
            else if (rot == Rot4.East)
            {
                input2 = new Translate(-map.Size.x, 0.0, 0.0, input2);
            }
            else if (rot == Rot4.South)
            {
                input2 = new Rotate(0.0, 90.0, 0.0, input2);
            }

            input2 = new ScaleBias(1.0, -1.0, input2);
            input2 = new Clamp(-1.0, 2.5, input2);

            // bigger offset = coastline takes up more of the map
            float offset = 0.55f;
            foreach (IntVec3 current in map.AllCells)
            {
                fertility[current] += Math.Min(input2.GetValue(current) - offset, 0);
            }
        }
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;


namespace TerrascapeCore
{
    /// <summary>
    /// prevents the normal beach from spawning
    /// </summary>
    [HarmonyPatch(typeof(BeachMaker), "Init")]
    static class NoBeachPatch
    {
        static bool Prefix(Map map)
        {
            if (map.Biome.HasModExtension<BiomeExtension>())
            {
                if (map.Biome.GetModExtension<BiomeExtension>().customBeach)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

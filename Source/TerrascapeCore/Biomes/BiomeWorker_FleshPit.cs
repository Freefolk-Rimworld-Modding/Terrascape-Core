using RimWorld;
using RimWorld.Planet;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrascapeCore
{
    public class BiomeWorker_FleshPit : BiomeWorker
    {
		/// <summary>
		/// placeholder biomeworker, mostly copied from Temperate Forest
		/// </summary>
		/// <param name="tile"></param>
		/// <param name="tileID"></param>
		/// <returns></returns>
        public override float GetScore(Tile tile, int tileID)
        {
			if (!Terrascape_Settings.spawnFleshPit)
			{
				return -100f;
			}
			if (tile.WaterCovered)
			{
				return -100f;
			}
			if (Rand.Value < 0.997f)
			{
				return 0f;
			}
			if (Rand.Value < 0.997f)
			{
				return 0f;
			}
			return 50f;
		}
    }
}
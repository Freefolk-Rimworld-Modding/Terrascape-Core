using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrascapeCore
{
    public class BiomeWorker_XericShrubland : BiomeWorker
    {
		/// <summary>
		/// placeholder biomeworker, mostly copied from Temperate Forest
		/// </summary>
		/// <param name="tile"></param>
		/// <param name="tileID"></param>
		/// <returns></returns>
        public override float GetScore(Tile tile, int tileID)
        {
			if (!Terrascape_Settings.spawnXericShrubland)
            {
				return -100f;
            }
			if (tile.WaterCovered)
			{
				return -100f;
			}
			if (tile.temperature < 4f || tile.temperature > 12f)
			{
				return 0f;
			}
			if (tile.rainfall < 1400)
			{
				return 0f;
			}
			if (tile.swampiness > 0.5f)
            {
				return 0f;
            }
			return 11f + (tile.temperature - 6f) + (tile.rainfall - 600f) / 170f;
		}
    }
}
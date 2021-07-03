using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrascapeCore
{
    public class BiomeWorker_MangroveSwamp : BiomeWorker
    {
		/// <summary>
		/// placeholder biomeworker, mostly copied from Temperate Forest
		/// </summary>
		/// <param name="tile"></param>
		/// <param name="tileID"></param>
		/// <returns></returns>
        public override float GetScore(Tile tile, int tileID)
        {
			if (!Terrascape_Settings.spawnMangroveSwamp)
            {
				return -100f;
            }
			if (tile.WaterCovered)
			{
				return -100f;
			}
			if (tile.temperature < 15f)
			{
				return 0f;
			}
			if (tile.rainfall < 600f)
			{
				return 0f;
			}
			if (tile.elevation > 45f)
            {
				return 0f;
            }
			if (tile.swampiness < 0.5f)
            {
				return 0f;
            }
			return 40f + (tile.temperature - 20f) * 1.5f + (tile.rainfall - 600f) / 170f + tile.swampiness * 3f;
		}
    }
}
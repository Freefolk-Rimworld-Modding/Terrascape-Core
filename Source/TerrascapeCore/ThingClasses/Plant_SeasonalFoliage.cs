using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace TerrascapeCore
{
    [StaticConstructorOnStartup]
    public class Plant_SeasonalFoliage : Plant
    {
		private static Graphic GraphicSowing = GraphicDatabase.Get<Graphic_Single>("Things/Plant/Plant_Sowing", ShaderDatabase.Cutout, Vector2.one, Color.white);

		public bool IsDrySeason(BiomeExtension thisExt, Season thisSeason)
        {
			if (thisExt.drySeasons == null)
            {
				return false;
            }
			int seasonCount = thisExt.drySeasons.Count();
			for (int i = 0; i < (seasonCount-1); i++)
            {
				if (thisSeason.ToString() == thisExt.drySeasons[i])
                {
					return true;
                }
            }
			return false;
		}

		public override Graphic Graphic
        {
			get
			{
				if (!def.HasModExtension<PlantExtension>())
					return base.Graphic;
				if (LifeStage == PlantLifeStage.Sowing)
					return GraphicSowing;
				Vector2 vector = Find.WorldGrid.LongLatOf(this.Map.Tile);
				Season season = GenDate.Season((long)Find.TickManager.TicksAbs, vector);
				PlantExtension ext = def.GetModExtension<PlantExtension>();
				BiomeExtension ext2 = Map.Biome.GetModExtension<BiomeExtension>();
				Graphic graphic = def.graphic;
				if (def.plant.immatureGraphic != null && Growth < ext.matureAt)
                {
					if (ext.immatureLeaflessPath != null && LeaflessNow && (!sown || !HarvestableNow))
                    {
						graphic = GraphicDatabase.Get(def.graphicData.graphicClass, ext.immatureLeaflessPath, def.graphic.Shader, def.graphicData.drawSize, def.graphicData.color, base.Graphic.colorTwo);
						return graphic;
					}
					if (ext.immatureLeaflessPath == null && LeaflessNow && (!sown || !HarvestableNow))
                    {
						return def.plant.leaflessGraphic;
                    }
                    if ((season == Season.Summer || season == Season.PermanentSummer) && !HarvestableNow)
					{
						return def.plant.immatureGraphic;
					}
                }
                if (season != Season.Summer || season != Season.PermanentSummer)
                {
					return def.plant.leaflessGraphic;
                }

				return base.Graphic;
			}
        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace TerrascapeCore
{
    [StaticConstructorOnStartup]
    public class Plant_SeasonalGrass : Plant
    {
		private static Graphic GraphicSowing = GraphicDatabase.Get<Graphic_Single>("Things/Plant/Plant_Sowing", ShaderDatabase.Cutout, Vector2.one, Color.white);
		
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
				Graphic graphic = def.graphic;
				if (def.plant.leaflessGraphic != null && LeaflessNow && (!sown || !HarvestableNow))
                {					
					return def.plant.leaflessGraphic;
				}
                if (ext.alternateGraphicPath != null && (season == Season.Summer || season == Season.PermanentSummer))
                {
					graphic = GraphicDatabase.Get(def.graphicData.graphicClass, ext.alternateGraphicPath, def.graphic.Shader, def.graphicData.drawSize, def.graphicData.color, base.Graphic.colorTwo);
					return graphic;
				}

				return base.Graphic;
			}
        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;
using HarmonyLib;

namespace TerrascapeCore
{
	public class Terrascape_Mod : Mod
	{
		public static Terrascape_Settings settings;

		public Terrascape_Mod(ModContentPack content)
			: base(content)
		{
			settings = GetSettings<Terrascape_Settings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			inRect.width = 450f;
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.Begin(inRect);
			listing_Standard.CheckboxLabeled("TS_CheckboxMangroveSwamp".Translate(), ref Terrascape_Settings.spawnMangroveSwamp, "TS_CheckboxMangroveSwampDesc".Translate());
			listing_Standard.CheckboxLabeled("TS_CheckboxSavanna".Translate(), ref Terrascape_Settings.spawnSavanna, "TS_CheckboxSavannaDesc".Translate());
			listing_Standard.CheckboxLabeled("TS_CheckboxTemperateRainforest".Translate(), ref Terrascape_Settings.spawnTemperateRainforest, "TS_CheckboxTemperateRainforestDesc".Translate());
			listing_Standard.CheckboxLabeled("TS_CheckboxXericShrubland".Translate(), ref Terrascape_Settings.spawnXericShrubland, "TS_CheckboxXericShrublandDesc".Translate());
			listing_Standard.GapLine();
			listing_Standard.CheckboxLabeled("TS_CheckboxPlantRoots".Translate(), ref Terrascape_Settings.spawnPlantRoots, "TS_CheckboxPlantRootsDesc".Translate());
			listing_Standard.End();
			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "TS_ModName".Translate();
		}
	}	
}

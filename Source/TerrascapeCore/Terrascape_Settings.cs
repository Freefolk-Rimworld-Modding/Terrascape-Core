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
	public class Terrascape_Settings : ModSettings
	{
		// Biomes

		public static bool spawnGrassland = true;

		public static bool spawnMangroveSwamp = true;

		public static bool spawnMarsh = true;

		public static bool spawnMudflat = true;

		public static bool spawnTemperateRainforest = true;

		public static bool spawnSaltPan = true;

		public static bool spawnSavannah = true;

		public static bool spawnXericShrubland = true;

		// Exotic Biomes

		public static bool spawnFleshPit = true;

		public static bool spawnOutback = true;

		// Natural Objects

		//public static bool spawnInsectNests = true;

		public static bool spawnPlantRoots = true;

		//public static bool spawnBoulders = true;

		//public static bool spawnLogs = true;

		//public static bool spawnTidepools = true;

		// Features

		//public static bool treeCanopy = true;

		//public static bool beachDebris = true;

		// Weather

		//public static bool morningJungleFog = true;

		//public static bool ashDuringVolcanicWinter = true;

		// Events

		//public static bool eventFireflies = true;

		//public static bool eventHurricane = true;

		//public static bool eventRedTide = true;

		//public static bool eventFishMigration = true;

		//public static bool eventGeothermalActivity = true;

		//public static bool eventBeaching = true;

		// Tweaks

		public static bool enableAnimalForaging = true;

		public override void ExposeData()
		{
			// Biomes
			Scribe_Values.Look(ref spawnGrassland, "spawnGrassland", defaultValue: true);
			Scribe_Values.Look(ref spawnMangroveSwamp, "spawnMangroveSwamp", defaultValue: true);
			Scribe_Values.Look(ref spawnMarsh, "spawnMarsh", defaultValue: true);
			Scribe_Values.Look(ref spawnMudflat, "spawnMudflat", defaultValue: true);
			Scribe_Values.Look(ref spawnTemperateRainforest, "spawnTemperateRainforest", defaultValue: true);
			Scribe_Values.Look(ref spawnSaltPan, "spawnSaltPan", defaultValue: true);
			Scribe_Values.Look(ref spawnSavannah, "spawnSavannah", defaultValue: true);
			Scribe_Values.Look(ref spawnXericShrubland, "spawnXericShrubland", defaultValue: true);

			// Exotic Biomes
			Scribe_Values.Look(ref spawnFleshPit, "spawnFleshPit", defaultValue: true);
			Scribe_Values.Look(ref spawnPlantRoots, "spawnPlantRoots", defaultValue: true);

			// Tweaks
			Scribe_Values.Look(ref enableAnimalForaging, "enableAnimalForaging", defaultValue: true);
		}
	}	
}

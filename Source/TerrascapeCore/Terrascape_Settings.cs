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
		// Biomes and Mapgen

		public static bool spawnMangroveSwamp = true;

		public static bool spawnTemperateRainforest = true;

		public static bool spawnXericShrubland = true;

		public static bool spawnFleshPit = true;

		public static bool geothermalVariation = true;

		// Natural Objects

		public static bool spawnInsectNests = true;

		public static bool spawnPlantRoots = true;

		public static bool spawnBoulders = true;

		public static bool spawnLogs = true;

		public static bool spawnTidepools = true;

		public static bool treeCanopy = true;

		public static bool beachDebris = true;

		// Weather

		public static bool morningJungleFog = true;

		public static bool ashDuringVolcanicWinter = true;

		// Incidents

		public static bool eventFireflies = true;

		public static bool eventHurricane = true;

		public static bool eventRedTide = true;

		public static bool eventFishMigration = true;

		public static bool eventGeothermalActivity = true;

		public static bool eventBeaching = true;

		// Animal Tweaks

		public static bool enableAnimalForaging = true;

		public static bool enablePredatorHealing = true;

		public override void ExposeData()
		{
			Scribe_Values.Look(ref spawnMangroveSwamp, "spawnMangroveSwamp", defaultValue: true);
			Scribe_Values.Look(ref spawnTemperateRainforest, "spawnTemperateRainforest", defaultValue: true);
			Scribe_Values.Look(ref spawnXericShrubland, "spawnXericShrubland", defaultValue: true);
			Scribe_Values.Look(ref spawnFleshPit, "spawnFleshPit", defaultValue: true);
			Scribe_Values.Look(ref spawnPlantRoots, "spawnPlantRoots", defaultValue: true);
			Scribe_Values.Look(ref enablePredatorHealing, "enablePredatorHealing", defaultValue: true);
			Scribe_Values.Look(ref enableAnimalForaging, "enableAnimalForaging", defaultValue: true);
		}
	}	
}

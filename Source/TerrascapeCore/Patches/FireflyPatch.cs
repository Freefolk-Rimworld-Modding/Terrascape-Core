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
	//[HarmonyPatch(typeof(SteadyEnvironmentEffects))]
	//[HarmonyPatch("DoCellSteadyEffects")]
	//[HarmonyPatch(new Type[]
	//{
	//typeof(IntVec3)
	//})]
	//internal class DoCellSteadyEffects
	//{
	//	// Token: 0x06000002 RID: 2 RVA: 0x0000224C File Offset: 0x0000044C
	//	private static void Postfix(IntVec3 c, SteadyEnvironmentEffects __instance)
	//	{
	//		Map map = HarmonyPatches.MapFieldInfo.GetValue(__instance) as Map;
	//		if (map == null)
	//		{
	//			return;
	//		}
	//		Room room = c.GetRoom(map, RegionType.Set_Passable);
	//		if (Terrascape_Settings.Fireflies)
	//		{
	//			Thing thing = (from t in c.GetThingList(map)
	//							where t.def.defName == "IceOverlay"
	//							select t).FirstOrDefault<Thing>();
	//			if (room == null && thing != null && Terrascape_Settings.IceLayer)
	//			{
	//				thing.Destroy(DestroyMode.Vanish);
	//				if (Rand.Range(1, 100) <= 20)
	//				{
	//					FilthMaker.TryMakeFilth(c, map, ThingDef.Named("FilthWater"), 1);
	//				}
	//			}
	//			if (room != null && !room.UsesOutdoorTemperature && !room.Fogged && !room.IsDoorway)
	//			{
	//				float num = 0.8f;
	//				if (room.Temperature < (float)Terrascape_Settings.FogTemp)
	//				{
	//					if (thing == null && Terrascape_Settings.IceLayer)
	//					{
	//						GenSpawn.Spawn(ThingMaker.MakeThing(ThingDef.Named("IceOverlay"), null), c, map);
	//					}
	//					if (Terrascape_Settings.ColdFog)
	//					{
	//						Vector3 vector = c.ToVector3Shifted();
	//						bool flag = true;
	//						if (!GenView.ShouldSpawnMotesAt(vector, map) || map.moteCounter.SaturatedLowPriority)
	//						{
	//							flag = false;
	//						}
	//						vector += num * new Vector3(Rand.Value - 0.5f, 0f, Rand.Value - 0.5f);
	//						if (!GenGrid.InBounds(vector, map))
	//						{
	//							flag = false;
	//						}
	//						if (flag)
	//						{
	//							MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(ThingDef.Named("Mote_FrostGlow"), null);
	//							moteThrown.Scale = Rand.Range(4f, 6f) * num;
	//							moteThrown.rotationRate = Rand.Range(-3f, 3f);
	//							moteThrown.exactPosition = vector;
	//							moteThrown.SetVelocity((float)(Rand.Bool ? -90 : 90), (float)((double)Terrascape_Settings.FogVelocity * 0.01));
	//							GenSpawn.Spawn(moteThrown, IntVec3Utility.ToIntVec3(vector), map);
	//						}
	//					}
	//				}
	//				else if (thing != null)
	//				{
	//					thing.Destroy(DestroyMode.Vanish);
	//					if (Rand.Range(1, 100) <= 20)
	//					{
	//						FilthMaker.TryMakeFilth(c, map, ThingDef.Named("FilthWater"), 1);
	//					}
	//				}
	//			}
	//		}
	//		if (map.roofGrid != null && !map.roofGrid.Roofed(c) && (float)map.weatherManager.curWeatherAge >= 7500f && (map.weatherManager.curWeather.rainRate <= 0f || map.weatherManager.curWeather.snowRate > 0f))
	//		{
	//			Thing thing3 = (from t in c.GetThingList(map)
	//							where t.def.defName == "FilthWater" || t.def.defName == "FilthWaterSpatter"
	//							select t).FirstOrDefault<Thing>();
	//			if (thing3 != null && Rand.Value <= 0.2f)
	//			{
	//				((Filth)thing3).ThinFilth();
	//			}
	//		}
	//	}
	//}
}

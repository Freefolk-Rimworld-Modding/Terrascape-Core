using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
using System.Reflection;
using HarmonyLib;

namespace TerrascapeCore
{
	[StaticConstructorOnStartup]
	public static class PatchAll
	{
		static PatchAll()
		{
			new Harmony("tidal.terrascape").PatchAll();
		}
	}
}
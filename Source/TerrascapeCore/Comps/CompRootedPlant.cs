using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using Verse.AI;
using UnityEngine;

namespace TerrascapeCore
{
	public class CompRootedPlant : ThingComp
	{
		public CompProperties_RootedPlant Props => (CompProperties_RootedPlant)props;

		private List<Thing> roots = new List<Thing>();

		private float progressToNewRoot;

		private bool isGenStep = false;

		// Returns true if the plant has reached the max amount of roots, else returns false.
		public bool HasMaxRoots()
		{
			if (!roots.NullOrEmpty())
            {
				return roots.Count >= Props.maxRoots;
			}
			return false;
		}

		// Toggled during the GenStep to randomize generated growth.
		public bool IsGenStep
        {
            get
            {
				return isGenStep;
            }
            set
            {
				isGenStep = value;
            }
        }

		// Returns amount of progress added per long tick.
		public float ProgressPerTickLong()
		{		
			Plant p = (Plant)parent;
			if (p != null)
            {
				return 1f / (30f * Props.growthCycleDays) * p.GrowthRate;
			}
			return 0f;
		}

		// Adds progress, and tries to grow a root.
		public void AddProgress(float progress)
		{
			progressToNewRoot += progress;
			TryGrowRoot();
		}

		// Adds progress if the rooted plant is growing and doesn't yet have the max number of roots.
		public override void CompTickLong()
		{
			if (!Terrascape_Settings.spawnPlantRoots)
			{
				return;
			}
			Plant p = (Plant)parent;
			if (p != null && p.LifeStage == PlantLifeStage.Growing && !HasMaxRoots())
			{
				AddProgress(ProgressPerTickLong());
			}
		}

		// Removes roots on despawn if set in properties, else tells the roots that their parent is dead. :(
		public override void PostDeSpawn(Map map)
		{
			if (Props.removeOnDespawn)
			{
				roots.RemoveAll((Thing p) => !p.Spawned);
			}
			else
			{
				foreach (Thing i in roots)
				{
					Plant_Root p = (Plant_Root)i;
					if (p != null)
					{
						p.LivingParent = false;
					}
				}
			}
		}

		// Tries to grow a new root if there's enough progress.
		private void TryGrowRoot()
		{
			while (progressToNewRoot >= 1f)
			{
				GrowRoot();
				progressToNewRoot -= 1f;
			}
		}

		// Returns true if the chosen type of root can grow in the chosen terrain.
		public bool IsRootableTerrain(IntVec3 c)
        {
			TerrainDef terrainDef = parent.Map.terrainGrid.TerrainAt(c);
			foreach (RootTerrainDef allDef in DefDatabase<RootTerrainDef>.AllDefs)
			{
				if (!(allDef.rootType == Props.rootType))
                {
					continue;
                }
				foreach (string allowedTerrain in allDef.allowedTerrains)
                {
					if (allowedTerrain == terrainDef.defName)
                    {
						return true;
                    }
                }
			}
			return false;
		}

		// Grows a new root within a defined radius, with a choice between Wet or Dry terrain affordance.
		public void GrowRoot()
		{
			int num = GenRadial.NumCellsInRadius(Props.rootGrowthRadius);
			List<IntVec3> positions = new List<IntVec3>();
			for (int i = 0; i < num; i++)
			{
				IntVec3 c = parent.Position + GenRadial.RadialPattern[i];
				if (c.InBounds(parent.Map) || WanderUtility.InSameRoom(parent.Position, c, parent.Map))
				{
					bool flag = false;
					if (IsRootableTerrain(c))
					{
                        List<Thing> list = parent.Map.thingGrid.ThingsListAt(c);
                        foreach (Thing item in list)
                        {
                            if (item.def == Props.root || (item.def.selectable && (item.def.category == ThingCategory.Plant || item.def.category == ThingCategory.Building)))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            positions.Add(c);
                        }
                    }
					//  // Original Code
					//               switch (Props.rootType)
					//               {
					//	// Wet roots can spawn in mud and water, or otherwise fertile terrain.
					//	case "Wet":
					//		if (terrain != null && (terrain.IsWater || terrain == TSDefOf.Mud || parent.Map.fertilityGrid.FertilityAt(c) >= Props.root.plant?.fertilityMin))
					//		{
					//			List<Thing> list = parent.Map.thingGrid.ThingsListAt(c);
					//			foreach (Thing item in list)
					//			{
					//				if (item.def == Props.root || (item.def.selectable && (item.def.category == ThingCategory.Plant || item.def.category == ThingCategory.Building)))
					//				{
					//					flag = true; // (Props.rootType == "Dry" && parent.Map.fertilityGrid.FertilityAt(c) >= Props.root.plant?.fertilityMin)
					//					break;
					//				}
					//			}
					//			if (!flag)
					//			{
					//				positions.Add(c);
					//			}
					//		}
					//		break;

					//	// Dry roots grow as normal in fertile terrain.
					//	case "Dry":
					//		if (terrain != null && parent.Map.fertilityGrid.FertilityAt(c) >= Props.root.plant?.fertilityMin)
					//		{
					//			List<Thing> list = parent.Map.thingGrid.ThingsListAt(c);
					//			foreach (Thing item in list)
					//			{
					//				if (item.def == Props.root || (item.def.selectable && (item.def.category == ThingCategory.Plant || item.def.category == ThingCategory.Building)))
					//				{
					//					flag = true;
					//					break;
					//				}
					//			}
					//			if (!flag)
					//			{
					//				positions.Add(c);
					//			}
					//		}
					//		break;

					//	// Log an error if the root is missing a type.
					//	default:
					//		Log.Error(string.Concat(parent.def, " has a rootType that is missing or incorrect in Terrascape.CompProperties_RootedPlant; rootType must be either \"Wet\" or \"Dry\"."));
					//		break;
					//}
				}
			}
			if (!positions.NullOrEmpty())
            {
				roots.Add(GenSpawn.Spawn(Props.root, positions.RandomElement<IntVec3>(), parent.Map));
				Plant_Root recentRoot = (Plant_Root)roots[roots.Count - 1];
				recentRoot.LivingParent = true;
				// Randomizes the root grown during map generation.
                if (IsGenStep)
                {
					recentRoot.Growth = Rand.Range(0.15f, 1f);
                }
                else
                {
					recentRoot.Growth = 0.15f;
                }
            }
		}

		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			if (Prefs.DevMode && Terrascape_Settings.spawnPlantRoots)
			{
				// Adds 100% progress if the number of roots is less than max roots
				Command_Action command_Action = new Command_Action();
				command_Action.defaultLabel = "DEV: Try to add a new root";
				command_Action.action = delegate
				{
					if (!HasMaxRoots())
                    {
						AddProgress(1f);
					}		
				};
				yield return command_Action;

				// Adds a single long tick of progress if the number of roots is less than max roots
				Command_Action command_Action2 = new Command_Action();
				command_Action2.defaultLabel = "DEV: Try to add a long tick of root progress";
				command_Action2.action = delegate
				{
					if (!HasMaxRoots())
					{
						AddProgress(ProgressPerTickLong());
					}
				};
				yield return command_Action2;
			}
		}

		// Save root progress and root list.
		public override void PostExposeData()
		{
			Scribe_Values.Look(ref progressToNewRoot, "progressToNewRoot", 0f);
			Scribe_Collections.Look(ref roots, "roots", LookMode.Reference);
			if (Scribe.mode == LoadSaveMode.PostLoadInit)
			{
				roots.RemoveAll((Thing x) => x == null);
			}
		}
	}

	public class CompProperties_RootedPlant : CompProperties
	{
		// The type of root to spawn. Must be a Terrascape.Plant_Root thingclass.
		public ThingDef root;

		// The max number of roots a rooted plant can produce.
		public int maxRoots;

		// The radius the roots will grow in.
		public float rootGrowthRadius;

		// The number of days it takes a new root to grow (with continuous growth)
		public float growthCycleDays = 5f;

		// If true, will remove all roots when the parent despawns.
		public bool removeOnDespawn = false;

		// By default, can be wet, dry, submerged, or stony. New root types can be added with a RootTerrainDef.
		public string rootType;

		public CompProperties_RootedPlant()
		{
			compClass = typeof(CompRootedPlant);
		}
	}

}


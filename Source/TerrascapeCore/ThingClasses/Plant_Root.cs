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
    public class Plant_Root : Plant
    {

		public bool growsWithoutParent = false;

        public bool diesWithoutParent = true;

        public float parentlessDamagePerTick = 0.005f;

		private bool livingParent = true;

		public bool LivingParent
        {
            get
            {
				return livingParent;
            }
            set
            {
				livingParent = value;
            }
        }

		// If growsWithoutParent is false, roots will not continue to grow if their parent tree has despawned.
		public override float GrowthRate
		{
			get
			{
				if (Blighted)
				{
					return 0f;
				}
				if (base.Spawned && !PlantUtility.GrowthSeasonNow(base.Position, base.Map))
				{
					return 0f;
				}
				if (!LivingParent && !growsWithoutParent)
                {
					return 0f;
                }
				return GrowthRateFactor_Fertility * GrowthRateFactor_Temperature * GrowthRateFactor_Light;
			}
		}

        // If the root dies without its parent plant and the parent plant is dead, the root will rot away.
        public override void TickLong()
        {
            base.TickLong();
            if (diesWithoutParent && !livingParent)
            {
                int num = Mathf.CeilToInt(parentlessDamagePerTick * 2000f);
                TakeDamage(new DamageInfo(DamageDefOf.Rotting, num));
            }
        }

        public override void ExposeData()
		{
			Scribe_Values.Look(ref livingParent, "livingParent", true);
		}
	}
}

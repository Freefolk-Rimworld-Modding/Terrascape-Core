﻿using System;
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
    [DefOf]
    public class TSDefOf
    {
        public static TerrainDef Mud;

        static TSDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TSDefOf));
        }
    }
}

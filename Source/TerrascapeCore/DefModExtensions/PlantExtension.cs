using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace TerrascapeCore
{
    // xml hook
    public class PlantExtension : DefModExtension
    {
        public string immatureLeaflessPath;
        public string semiMaturePath;
        public string alternateGraphicPath;
        public float semiMatureAt = 0.33f;
        public float matureAt = 0.65f;
        public bool needsRest = true;
        public FloatRange growingHours = new FloatRange(0.25f, 0.8f);
        public float? harvestMaxGrowth;
    }
}


using System;

namespace CTmapAPI.Serializables;

[Serializable]
    public class EffectSubContainerSerializable
    {
        public Exiled.API.Enums.EffectType Effect;
        public  byte Intensity { get; init; }
        public float Duration { get; init; }

       
    }

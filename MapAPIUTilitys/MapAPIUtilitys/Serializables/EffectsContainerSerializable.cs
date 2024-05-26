// -----------------------------------------------------------------------
// <copyright file="EffectsContainerSerializable.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------



using MapAPIUTilitys.MapAPIUtilitys.Enums;
namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;
[Serializable]
    public class EffectSubContainerSerializable
    {
        public EffectType Effect;
        public  byte Intensity { get; set; }
        public float Duration { get; set; }
       
    }

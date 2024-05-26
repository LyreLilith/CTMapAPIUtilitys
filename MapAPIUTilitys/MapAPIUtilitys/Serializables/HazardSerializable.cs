// -----------------------------------------------------------------------
// <copyright file="MyClass.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------

using System.Numerics;

namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;

/// <summary>
/// Container for the Enviermental Hazards
/// </summary>
[Serializable]
public class HazardSerialzable
{

    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; }
    public float EnableAfter { get; set; }
    public List<EffectSubContainerSerializable> EffectsList { get; set; }
    



}
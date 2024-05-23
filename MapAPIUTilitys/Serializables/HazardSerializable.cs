
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTmapAPI.Serializables;
/// <summary>
/// Container for the Enviermental Hazards
/// </summary>
[Serializable]
public class HazardSerialzable
{

    public Vector3 Position { get; init; }
    public Vector3 Rotation { get; init; }
    public Vector3 Scale { get; init; }
    public float EnableAfter { get; init; }
    public List<EffectSubContainerSerializable> EffectsList { get; init; }
    



}
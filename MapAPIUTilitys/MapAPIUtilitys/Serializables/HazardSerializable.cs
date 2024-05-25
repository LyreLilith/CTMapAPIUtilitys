
using System;
using System.Collections.Generic;
using CTmapAPI.Serializables;
using UnityEngine;

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
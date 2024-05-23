
using System;
using UnityEngine;

namespace CTmapAPI.Serializables;

[Serializable]
public class PrefabSerialzable
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; }
    
    public PrefabSerialzable() { }
}
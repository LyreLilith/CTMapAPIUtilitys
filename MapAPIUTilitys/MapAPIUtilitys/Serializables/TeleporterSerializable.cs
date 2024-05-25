
using System;
using UnityEngine;



[Serializable]
public class TeleporterSerialzable
{
    public Vector3 Scale { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 TargetPosition { get; set; }
    public Vector3 TargetRotation { get; set; }

    // Parameterless constructor for deserialization
    public TeleporterSerialzable() { }
}
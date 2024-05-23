
using System;
using UnityEngine;

namespace CTmapAPI.Serializables;

[Serializable]
public class TeleporterSerialzable
{
    public Vector3 Scale { get; init; }
    public Vector3 Position { get; init; }
    public Vector3 Rotation { get; init; }
    public Vector3 TargetPosition { get; init; }
    public Vector3 TargetRotation { get; init; }

    // Parameterless constructor for deserialization
    public TeleporterSerialzable() { }
}
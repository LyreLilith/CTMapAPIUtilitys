
// -----------------------------------------------------------------------
// <copyright file="TeleporterSerializable.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------

using System.Numerics;



namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;
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
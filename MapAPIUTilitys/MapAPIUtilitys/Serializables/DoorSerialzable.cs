// -----------------------------------------------------------------------
// <copyright file="DoorSerializablee.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// Modifications made by LyreLilith
// Licensed under the CC BY-SA 3.0 license
// -----------------------------------------------------------------------


using System.Numerics;
using MapAPIUTilitys.MapAPIUtilitys.Enums;

namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;



[Serializable]
public class DoorSerializable
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; } = new Vector3(1f, 1f, 1f);
    public DoorType Door { get; set; } = DoorType.LczCafe;
    
    
    
    public KeycardPermissions Permissions { get; set; } =
       KeycardPermissions.None;
    public DoorDamageType DoorDamage { get; set; } = DoorDamageType.Weapon;
    public float Health { get; set; } = 200;
    public string PairTag { get; set; } = "";
    public DoorDelaySerializable LockUntil { get; set; }

    
    public DoorSerializable() { }
}
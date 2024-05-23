
using System;
using CTmapAPI.Serializables;
using Exiled.API.Enums;
using Interactables.Interobjects.DoorUtils;
using Newtonsoft.Json;
using UnityEngine;
using KeycardPermissions = Exiled.API.Enums.KeycardPermissions;

namespace CTmapAPI.Serializables;

[Serializable]
public class DoorSerializable
{
    public Vector3 Position { get; init; }
    public Vector3 Rotation { get; init; }
    public Vector3 Scale { get; init; } = new Vector3(1f, 1f, 1f);
    public DoorType Door { get; init; } = DoorType.LczCafe;
    
    
    [JsonConverter(typeof(KeycardPermissionsConverter))]
    public Interactables.Interobjects.DoorUtils.KeycardPermissions Permissions { get; init; } =
        Interactables.Interobjects.DoorUtils.KeycardPermissions.None;
    [JsonConverter(typeof(DoorDamageTypeConverter))]
    public DoorDamageType DoorDamage { get; init; } = DoorDamageType.Weapon;
    public float Health { get; init; } = 200;
    public string PairTag { get; init; } = "";
    public DoorDelaySerializable LockUntil { get; init; }

    
    public DoorSerializable() { }
}
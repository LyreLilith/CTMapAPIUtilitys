
using System;
using CTmapAPI;
using CTmapAPI.Serializables;
using Exiled.API.Enums;
using Interactables.Interobjects.DoorUtils;
using Newtonsoft.Json;
using UnityEngine;
using KeycardPermissions = Exiled.API.Enums.KeycardPermissions;



[Serializable]
public class DoorSerializable
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; } = new Vector3(1f, 1f, 1f);
    public DoorType Door { get; set; } = DoorType.LczCafe;
    
    
    [JsonConverter(typeof(KeycardPermissionsConverter))]
    public Interactables.Interobjects.DoorUtils.KeycardPermissions Permissions { get; set; } =
        Interactables.Interobjects.DoorUtils.KeycardPermissions.None;
    [JsonConverter(typeof(DoorDamageTypeConverter))]
    public DoorDamageType DoorDamage { get; set; } = DoorDamageType.Weapon;
    public float Health { get; set; } = 200;
    public string PairTag { get; set; } = "";
    public DoorDelaySerializable LockUntil { get; set; }

    
    public DoorSerializable() { }
}
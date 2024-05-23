
using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using UnityEngine;

namespace CTmapAPI.Serializables
{
    [Serializable]
    public class RoomSerialzable
    {
        public RoomType TypeOfRoom { get; set; }
        public float Chance { get; set; }
        public string SchematicName { get; set; }
        public List<TeleporterContainer> TeleporterList { get; set; }
        public List<DoorSerializable> DoorList { get; set; }
        public List<HazardSerialzable> HazardList { get; set; }
        public Vector3 PositionOverride { get; set; }
        public bool OverridesColor { get; set; }
        public Color ColorOverrider { get; set; }
        public Vector3 RotationOverride { get; set; }
        public List<PrefabSerialzable> WorkStationDatas { get; set; }
        public List<PrefabSerialzable> GeneratorData { get; set; }
        public List<ItemSpawnSerialzable> ItemSpawnLocation { get; set; }
        public List<MiscLockerSerializble> Lockers { get; set; }



    }
}

    



  

      

   
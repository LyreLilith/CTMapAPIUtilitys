// -----------------------------------------------------------------------
// <copyright file="RoomSerialzable.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------
using System.Numerics;
using MapAPIUTilitys.MapAPIUtilitys.Enums;



namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;

    [Serializable]
    public class RoomSerialzable
    {
        public RoomType TypeOfRoom { get; set; }
        public float Chance { get; set; }
        public string SchematicName { get; set; }
        public List<TeleporterSerialzable> TeleporterList { get; set; }
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


    



  

      

   

using System;
using System.Collections.Generic;
using Exiled.API.Enums;

namespace CTmapAPI.Serializables;

[Serializable]
public class ZonesContainerSerializable
{
   
    public uint MaxCustomRoomsSurface { get; set; }
    public uint MaxCustomRoomsLight { get; set; }
    public uint MaxCustomRoomsEntrance { get; set; }
    
    
        public  Dictionary<RoomType, List<RoomSerialzable>> HeavyDictionary { get; init; } = new();

        public  Dictionary<RoomType, List<RoomSerialzable>> SurfaceDictionary { get; init; } = new();

        public  Dictionary<RoomType, List<RoomSerialzable>> LightDictionary { get; init; } = new();

        public  Dictionary<RoomType, List<RoomSerialzable>> EntranceDictionary { get; init; } = new();

      public  ZonesContainerSerializable()
        {
        }
}
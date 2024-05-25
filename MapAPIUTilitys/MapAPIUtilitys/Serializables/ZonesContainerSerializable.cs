
using System;
using System.Collections.Generic;
using CTmapAPI.Serializables;
using Exiled.API.Enums;



[Serializable]
public class ZonesContainerSerializable
{
   
    public uint MaxCustomRoomsSurface { get; set; }
    public uint MaxCustomRoomsLight { get; set; }
    public uint MaxCustomRoomsEntrance { get; set; }
    
    
        public  Dictionary<RoomType, List<RoomSerialzable>> HeavyDictionary { get; set; } = new  Dictionary<RoomType, List<RoomSerialzable>>();

        public  Dictionary<RoomType, List<RoomSerialzable>> SurfaceDictionary { get; set; } = new  Dictionary<RoomType, List<RoomSerialzable>>();

        public  Dictionary<RoomType, List<RoomSerialzable>> LightDictionary { get; set ; } = new  Dictionary<RoomType, List<RoomSerialzable>>();

        public  Dictionary<RoomType, List<RoomSerialzable>> EntranceDictionary { get; set; } =  new  Dictionary<RoomType, List<RoomSerialzable>>();

      public  ZonesContainerSerializable()
        {
        }
}
// -----------------------------------------------------------------------
// <copyright file="ZonesContainerSerializable.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------

using MapAPIUTilitys.MapAPIUtilitys.Enums;

namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;
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
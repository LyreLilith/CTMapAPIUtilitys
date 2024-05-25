using CTmapAPI.Serializables;
using Interactables.Interobjects.DoorUtils;
using MapAPIUTilitys.Enums;


public class MiscLockerSerializble : PrefabSerialzable
{
    public LockerTypes LockerType { get; set; }

    public Dictionary<int, List<ItemSpawnSerialzable>> Chambers { get; set; } = new Dictionary<int, List<ItemSpawnSerialzable>> ()
    {
        { 0, new List<ItemSpawnSerialzable> () { new ItemSpawnSerialzable() } },
    };
    
    public KeycardPermissions KeycardPermissions { get; set; } = KeycardPermissions.None;

 

   
}
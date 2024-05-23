using CTmapAPI.Serializables;
using Interactables.Interobjects.DoorUtils;
using MapAPIUTilitys.Enums;
using MapEditorReborn.API.Enums;


public class MiscLockerSerializble : PrefabSerialzable
{
    public LockerTypes LockerType { get; set; }

    public Dictionary<int, List<ItemSpawnSerialzable>> Chambers { get; set; } = new ()
    {
        { 0, new () { new () } },
    };
    
    public KeycardPermissions KeycardPermissions { get; set; } = KeycardPermissions.None;

 

   
}
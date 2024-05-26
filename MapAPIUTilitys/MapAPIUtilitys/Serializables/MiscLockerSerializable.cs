// -----------------------------------------------------------------------
// <copyright file="LockerSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// Modifications made by LyreLilith
// Licensed under the CC BY-SA 3.0 license
// -----------------------------------------------------------------------


using MapAPIUTilitys.MapAPIUtilitys.Enums;

namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;
public class MiscLockerSerializble : PrefabSerialzable
{
    public LockerTypes LockerType { get; set; }

    public Dictionary<int, List<ItemSpawnSerialzable>> Chambers { get; set; } = new Dictionary<int, List<ItemSpawnSerialzable>> ()
    {
        { 0, new List<ItemSpawnSerialzable> () { new ItemSpawnSerialzable() } },
    };
    
    public KeycardPermissions KeycardPermissions { get; set; } = KeycardPermissions.None;

 

   
}
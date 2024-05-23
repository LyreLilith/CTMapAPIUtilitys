using System.Diagnostics;
using CTmapAPI.Enums;
using CTmapAPI.Serializables;
using Exiled.API.Enums;
using Interactables.Interobjects.DoorUtils;
using MapAPIUTilitys.Enums;
using MapEditorReborn.Commands.ModifyingCommands.Scale;
using MapGeneration;
using UnityEngine;
using KeycardPermissions = Exiled.API.Enums.KeycardPermissions;

namespace MapAPIUTilitys;

public class RoomConfigMaker
{


    public static RoomSerialzable RoomConfig()
    {
        var room = new RoomSerialzable();

        room.TypeOfRoom = ReadEnum<Exiled.API.Enums.RoomType>("Please enter room type");
        
        // Prompt for Chance
        room.Chance = PromptFloat("Enter Vaule .001 - 1",.001f,1f);

        Console.WriteLine("Enter the schematic name:");
        room.SchematicName = Console.ReadLine();

        // Prompt for TeleporterList
        room.TeleporterList = PromptTeleporterList();

        // Prompt for DoorList
        room.DoorList = PromptDoorList();

        // Prompt for HazardList
        room.HazardList = PromptHazardList();

        // Prompt for PositionOverride
        room.PositionOverride = PromptVector3("Please enter the Positions over");

        // Prompt for OverridesColor
        room.OverridesColor = PromptBool("Overrides color");

        // Prompt for ColorOverrider
        if (room.OverridesColor)
        {
            room.ColorOverrider = PromptColor("color overrider");
        }

        // Prompt for RotationOverride
        room.RotationOverride = PromptVector3("rotation override");

        // Prompt for WorkStationDatas
        room.WorkStationDatas = PromptPrefabs("workstation");

        // Prompt for GeneratorData
        room.GeneratorData = PromptPrefabs("Generators");

        // Prompt for ItemSpawnLocation
        room.ItemSpawnLocation = PromptItemSpawnerList();


        room.Lockers = PromptLocker();

        return room;
    }



    private static List<ItemSpawnSerialzable> PromptItemSpawnerList()
    {
        var itemSpawnerList = new List<ItemSpawnSerialzable>();
        if (int.TryParse(Console.ReadLine(), out int count))
        {
            for (int i = 0; i < count; i++)
            {
                itemSpawnerList.Add(PromptItemSpawnSerialzable());
            }
        }
        return itemSpawnerList;
    }


    private static List<MiscLockerSerializble> PromptLocker()
    {
        List<MiscLockerSerializble> list = new();
        while (true)
        {
            string input = PromptString($"Add a effect? (yes/done): ");
            if (input.ToLower() == "done") break;
            var locker = new MiscLockerSerializble
            {
                Position = PromptVector3("locker position"),
                Rotation = PromptVector3("locker rotation"),
                Scale = PromptVector3("locker scale"),
                LockerType = ReadEnum<LockerTypes>("locker type"),
                Chambers = PromptDictinary<int, List<ItemSpawnSerialzable>>("chambers", PromptItemSpawnerList),
                KeycardPermissions =
                    ReadEnum<Interactables.Interobjects.DoorUtils.KeycardPermissions>("keycard permissions")
            };
            list.Add(locker);
        }

        return list;
    }






    private static ItemSpawnSerialzable PromptItemSpawnSerialzable()
    {
        var itemSpawner = new ItemSpawnSerialzable
        {
            Position = PromptVector3("item spawner position"),
            Rotation =PromptVector3("item spawner rotation"),
            Scale = PromptVector3("item spawner scale"),
            Item = PromptString("item"),
            CanBePickedUp = PromptBool("can be picked up"),
            SpawnChance = (int)PromptFloat("spawn chance (0-100):", 0, 100),
            NumberOfItems = (uint)PromptFloat("number of items",0,null),
            AttachmentsCode = PromptString("attachments code"),
            UseGravity = PromptBool("use gravity")
        };
        return itemSpawner;
    }
    
    
    private static Dictionary<TKey, TValue> PromptDictinary<TKey, TValue>(string prompt, Func<TValue> readValueFunc)
    {
        var dictionary = new Dictionary<TKey, TValue>();
        Console.WriteLine("Enter number of " + prompt + ":");
        if (int.TryParse(Console.ReadLine(), out var count))
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter key for " + prompt + " " + (i + 1) + ":");
                TKey key = (TKey)Convert.ChangeType(Console.ReadLine(), typeof(TKey));
                TValue value = readValueFunc();
                dictionary.Add(key, value);
            }
        }
        return dictionary;
    }
    
    private static List<HazardSerialzable> PromptHazardList(){
        List<HazardSerialzable> list = new();

        while (true)
        {
            string input = PromptString($"Add a Hazard? (yes/done/?): ");
            switch (input)
            {
                case "yes":
                    HazardSerialzable hazard = new()
                    {
                        Position = PromptVector3("Position"),
                        Rotation = PromptVector3("Rotation"),
                        Scale = PromptVector3("Scale"),
                        EnableAfter = PromptFloat("Enable After",0,null),
                        EffectsList = PromptEffectsSub()
                    };
                        list.Add(hazard);
                        break;
                case "done":
                    break;
                case "?":
                    Console.Clear();
                    Console.WriteLine("Avalible Effects");
                    PrintEnumValues<EffectType>();
                    break;

            }
        }
    }


    public static void PrintEnumValues<T>() where T : Enum
    {
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            Console.WriteLine(value);
        }
    }



    private static List<EffectSubContainerSerializable> PromptEffectsSub()
    {
        var list = new List<EffectSubContainerSerializable>();

        while (true)
        {
            string input = PromptString($"Add a effect? (yes/done): ");
            if (input.ToLower() == "done") break;

            var effect = new EffectSubContainerSerializable()
            {

                Effect = ReadEnum<Exiled.API.Enums.EffectType>("EffectType"),
                Intensity = PromptByte("intesity"),
                Duration = PromptFloat("duration",0,null)

            };
            list.Add(effect);
        }

        return list;

    }

    private static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
    {
        Console.WriteLine("Enter " + prompt + " (" + string.Join(", ", Enum.GetNames(typeof(TEnum))) + "):");
        while (true)
        {
            var input = Console.ReadLine();
            if (Enum.TryParse(input, true, out TEnum result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Enter " + prompt + " (" + string.Join(", ", Enum.GetNames(typeof(TEnum))) + "):");
        }
    }




private static byte PromptByte(string prompt)
{
    byte result;
    Console.WriteLine(prompt);
    while (!byte.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Invalid input. " + prompt);
    }
    return result;
}


    private static List<PrefabSerialzable> PromptPrefabs(string messaage)
    {
        List<PrefabSerialzable> list = new List<PrefabSerialzable>();
        Console.WriteLine($"Enter {messaage} data. Type 'done' to finish.");
        while (true)
        {
            string input = PromptString($"Add a {messaage}? (yes/done): ");
            if (input.ToLower() == "done") break;

            PrefabSerialzable prefab = new()
            {
                Position = PromptVector3($"Enter {messaage} position: "),
                Rotation = PromptVector3($"Enter {messaage} rotation: "),
                Scale = PromptVector3($"Enter {messaage} scale: "),
               
            };
            list.Add(prefab);
        }
        return list;
        
    }
    
    private static float PromptFloat(string message, float? min, float? max)
    {
        float result;
        Console.Write(message);
        while (!float.TryParse(Console.ReadLine(), out result) || 
               (min.HasValue && result < min.Value) || 
               (max.HasValue && result > max.Value))
        {
            string rangeMessage = "";
            if (min.HasValue && max.HasValue)
            {
                rangeMessage = $" (between {min.Value} and {max.Value})";
            }
            else if (min.HasValue)
            {
                rangeMessage = $" (greater than or equal to {min.Value})";
            }
            else if (max.HasValue)
            {
                rangeMessage = $" (less than or equal to {max.Value})";
            }

            Console.Write($"Invalid input. {message}{rangeMessage}: ");
        }
        return result;
    }


    private static string PromptString(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    private static Vector3 PromptVector3(string message)
    {
        float x = PromptFloat(message + " (x): ",null,null);
        float y = PromptFloat(message + " (y): ",null,null);
        float z = PromptFloat(message + " (z): ",null,null);
        return new Vector3(x, y, z);
    }

    private static bool PromptBool(string message)
    {
        bool result;
        Console.Write(message);
        while (!bool.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Invalid input. " + message);
        }
        return result;
    }

    private static Color PromptColor(string message)
    {
        float r = PromptFloat(message + " (r): ",0,null);
        float g = PromptFloat(message + " (g): ",0,null);
        float b = PromptFloat(message + " (b): ",0,null);
        float a = PromptFloat(message + " (a): ",0,null);
        return new Color(r, g, b, a);
    }

    private static List<TeleporterContainer> PromptTeleporterList()
    {
        List<TeleporterContainer> list = new List<TeleporterContainer>();
        Console.WriteLine("Enter teleporter data. Type 'done' to finish.");
        while (true)
        {
            string input = PromptString("Add a teleporter? (yes/done): ");
            if (input.ToLower() == "done") break;

            TeleporterContainer teleporter = new TeleporterContainer
            {
                Position = PromptVector3("Enter teleporter position: "),
                Rotation = PromptVector3("Enter teleporter rotation: "),
                Scale = PromptVector3("Enter teleporter scale: "),
                TargetPosition = PromptVector3("Enter teleporter target position: "),
                TargetRotation = PromptVector3("Enter teleporter target rotation: ")
            };
            list.Add(teleporter);
        }
        return list;
    }


    private static DoorType PromptDoorType(string message)
    {
        Console.WriteLine($"Please enter the door type, option {DoorType.EntranceDoor}, {DoorType.LczCafe}, {DoorType.HeavyContainmentDoor}");
        while (true)
        {
            string input = Console.ReadLine();
        if (Enum.TryParse(input, true, out DoorType doorType)&& (doorType==DoorType.LczCafe || doorType==DoorType.HeavyContainmentDoor || doorType == DoorType.EntranceDoor))
        {
            return doorType;
        }
        Console.WriteLine($"Invalid Vaule: {input}");
        }
    }
    
    public static DoorDamageType PromptDoorDamagaeTypes()
    {
        
        Console.WriteLine("Please enter the door damage types sepreateed by a comma each");
        string input = Console.ReadLine();

        // Split the input into individual damage types
        var damageList = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(d => d.Trim())
            .ToList();

        DoorDamageType damageType = DoorDamageType.None;
        
        foreach (string damage in damageList)
        {
            if (Enum.TryParse(damage, true, out DoorDamageType result))
            {
                damageType |= result;
            }
            else
            {
                Console.WriteLine($"Invalid damage type: {damage}");
            }
        }

        return damageType;
    }
    
    public static Interactables.Interobjects.DoorUtils.KeycardPermissions PromptUserForKeycardPermissions()
    {
        Console.WriteLine("Enter keycard permissions separated by commas (e.g., ContainmentLevelOne, ArmoryLevelOne, ScpOverride):");
        string input = Console.ReadLine();

        // Split the input into individual permissions
        var permissionsList = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        Interactables.Interobjects.DoorUtils.KeycardPermissions permissions = Interactables.Interobjects.DoorUtils.KeycardPermissions.None;

        // Convert each string to an enum value and combine them
        foreach (string permission in permissionsList)
        {
            if (Enum.TryParse(permission.Trim(), true, out Interactables.Interobjects.DoorUtils.KeycardPermissions result))
            {
                permissions |= result;
            }
            else
            {
                Console.WriteLine($"Invalid permission: {permission}");
            }
        }

        return permissions;
    }

        public static DoorDelaySerializable PromptUserDoorDamage()
        {
            Console.WriteLine("Enter the lock event (e.g., None, Time):");
            string eventInput = Console.ReadLine();

            LockEvents lockEvent;
            while (!Enum.TryParse(eventInput, true, out lockEvent))
            {
                Console.WriteLine("Invalid lock event. Please enter a valid lock event (e.g., None, Time):");
                eventInput = Console.ReadLine();
            }

            Console.WriteLine("Enter the lock time (e.g., 0, 10.5):");
            string timeInput = Console.ReadLine();

            float lockTime;
            while (!float.TryParse(timeInput, out lockTime))
            {
                Console.WriteLine("Invalid lock time. Please enter a valid float number (e.g., 0, 10.5):");
                timeInput = Console.ReadLine();
            }

            return new DoorDelaySerializable
            {
                LockUntilEvent = lockEvent,
                LockTime = lockTime
            };
        }


       


        private static List<DoorSerializable> PromptDoorList()
        {
            List<DoorSerializable> list = new List<DoorSerializable>();
            Console.WriteLine("Enter door data. Type 'done' to finish.");
            while (true)
            {
                string input = PromptString("Add a door? (yes/done): ");
                if (input.ToLower() == "done") break;

                DoorSerializable door = new DoorSerializable()
                {
                    Position = PromptVector3("Enter door position: "),
                    Rotation = PromptVector3("Enter door rotation: "),
                    Scale = PromptVector3("Enter door rotation: "),
                    Door = PromptDoorType("Enter door type: "),
                    Health = PromptFloat("Enter Door Health",0,null),
                    DoorDamage = PromptDoorDamagaeTypes(),
                    LockUntil = PromptUserDoorDamage(),
                    Permissions = PromptUserForKeycardPermissions()
                };

                list.Add(door);
            }

            return list;
        }
}
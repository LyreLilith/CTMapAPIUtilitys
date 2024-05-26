// -----------------------------------------------------------------------
// <copyright file="RoomConfigMaker.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------
using MapAPIUTilitys;
using MapAPIUTilitys.MapAPIUtilitys.Enums;
using MapAPIUTilitys.MapAPIUtilitys.Serializables;


public class RoomConfigMaker
{


    public static RoomSerialzable RoomConfig()
    {
        var room = new RoomSerialzable();

        room.TypeOfRoom = ReadEnum<RoomType>("Please enter room type");
        
        // Prompt for Chance
        room.Chance = PromptFloat("Enter Vaule .001 - 1: ",.001f,1f);

        Console.WriteLine("Enter the schematic name:");
        room.SchematicName = Console.ReadLine();

        // Prompt for TeleporterList
        room.TeleporterList = PromptTeleporterList();

        // Prompt for DoorList
        room.DoorList = PromptDoorList();

        // Prompt for HazardList
        room.HazardList = PromptHazardList();

      
        room.PositionOverride = PromptVector3("Please enter the Positions over");
        
        room.OverridesColor = PromptBool("Overrides color");
        
        if (room.OverridesColor)
        {
            room.ColorOverrider = PromptColor("color overrider");
        }
        
        room.RotationOverride = PromptVector3("rotation override");
        
        room.WorkStationDatas = PromptPrefabs("workstation");

        
        room.GeneratorData = PromptPrefabs("Generators");
        
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
        List<MiscLockerSerializble> list = new  List<MiscLockerSerializble>();
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
                    ReadEnum<KeycardPermissions>("keycard permissions")
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
        List<HazardSerialzable> list = new  List<HazardSerialzable>();
        bool loop = true;
        while (loop)
        {
            string input = PromptString($"Add a Hazard? (yes/done/?): ");
            switch (input)
            {
                case "yes":
                    HazardSerialzable hazard = new HazardSerialzable()
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
                    loop = false;
                    return list;
                    break;
                case "?":
                    Console.Clear();
                    Console.WriteLine("Avalible Effects");
                    PrintEnumValues<EffectType>();
                    break;

            }
        }

        return list;
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

                Effect = ReadEnum<EffectType>("EffectType"),
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

            PrefabSerialzable prefab = new  PrefabSerialzable()
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

    private static System.Numerics.Vector3 PromptVector3(string message)
    {
        float x = PromptFloat(message + " (x): ",null,null);
        float y = PromptFloat(message + " (y): ",null,null);
        float z = PromptFloat(message + " (z): ",null,null);
        return new System.Numerics.Vector3(x, y, z);
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

    private static MapAPIUTilitys.Color PromptColor(string message)
    {
        float r = PromptFloat(message + " (r): ",0,null);
        float g = PromptFloat(message + " (g): ",0,null);
        float b = PromptFloat(message + " (b): ",0,null);
        float a = PromptFloat(message + " (a): ",0,null);
        return new Color(r, g, b, a);
    }

    private static List<TeleporterSerialzable> PromptTeleporterList()
    {
        List<TeleporterSerialzable> list = new List<TeleporterSerialzable>();
        Console.WriteLine("Enter teleporter data. Type 'done' to finish.");
        while (true)
        {
            string input = PromptString("Add a teleporter? (yes/done): ");
            if (input.ToLower() == "done") break;

            TeleporterSerialzable teleporter = new TeleporterSerialzable()
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
    
    public static KeycardPermissions PromptUserForKeycardPermissions()
    {
        Console.WriteLine("Enter keycard permissions separated by commas (e.g., ContainmentLevelOne, ArmoryLevelOne, ScpOverride):");
        string input = Console.ReadLine();

        // Split the input into individual permissions
        var permissionsList = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
       KeycardPermissions permissions = KeycardPermissions.None;

  
        foreach (string permission in permissionsList)
        {
            if (Enum.TryParse(permission.Trim(), true, out KeycardPermissions result))
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
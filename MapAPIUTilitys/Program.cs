
namespace MapAPIUTilitys;

using CTmapAPI.Serializables;
using Exiled.API.Enums;
using MapAPIUTilitys;
using Newtonsoft.Json;
using UnityEngine;


class Program
{
    private static string UtilityDirectory => Path.Combine(Environment.CurrentDirectory, "MapUtilitys");
    private static  string InputDirectory => Path.Combine(UtilityDirectory, "Input");
    private static string OutputDirectory => Path.Combine(UtilityDirectory, "Output");
    private static string DataFilePath => Path.Combine(UtilityDirectory, "zones_data.json");
    private static ZonesContainerSerializable zonesData = new();
    private static RoomSerialzable roomData = new();
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MapAPIUltilitys");
        bool loop = true;

    
        bool jsonImported;
        while (loop)
        {
            Console.WriteLine("Please select an option");
            Console.WriteLine("1) Create New Room Json");
            Console.WriteLine("2) Import Room json to main json");
            Console.WriteLine("3) Exit");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            switch (option)
            {
                case 1:
                    RoomSerialzable room = RoomConfigMaker.RoomConfig();
                    Console.WriteLine("Room Json Saved");
                    break;
                case 2:
                    if (LoadFromFile(DataFilePath) && LoadRoomsFromDirectory(InputDirectory))
                    {
                        AddRooms();
                        SaveToZoneDataFile(DataFilePath);
                    }
                    else
                    {
                        Console.WriteLine("File non existant");
                    }

                    break;
                case 3:
                    loop = false;
                    break;
                default:
                    break;
            }
        }
    }



    public static void AddRooms()
    {
        foreach (var room in LoadedRooms)
        {
            
            string roomTypeString = room.TypeOfRoom.ToString();

           
            if (roomTypeString.Contains("Hcz"))
            {
                AddRoomToDictionary(zonesData.HeavyDictionary, room);
            }
            else if (roomTypeString.Contains("Lcz"))
            {
                AddRoomToDictionary(zonesData.LightDictionary, room);
            }
            else if (roomTypeString.Contains("Ez"))
            {
                AddRoomToDictionary(zonesData.EntranceDictionary, room);
            }
            else if (roomTypeString.Contains("Surface"))
            {
                AddRoomToDictionary(zonesData.SurfaceDictionary, room);
            }
            else
            {
                Debug.LogWarning($"Unknown prefix in RoomType: {roomTypeString}");
            }
        }
    }

    
    private static void AddRoomToDictionary(Dictionary<RoomType, List<RoomSerialzable>> dictionary, RoomSerialzable room)
    {
        if (dictionary.ContainsKey(room.TypeOfRoom))
        {
            dictionary[room.TypeOfRoom].Add(room);
        }
        else
        {
            dictionary[room.TypeOfRoom] = new List<RoomSerialzable> { room };
        }
    }
    
    
    public static List<RoomSerialzable> LoadedRooms { get; private set; } = new List<RoomSerialzable>();

    public static bool LoadRoomsFromDirectory(string directoryPath)
    {
        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory not found: {directoryPath}. Creating a default directory.");
                Directory.CreateDirectory(directoryPath);
                return false;
            }

            string[] files = Directory.GetFiles(directoryPath, "*.json");
            if (files.Length == 0)
            {
                return false;
            }

            foreach (string file in files)
            {
                Console.WriteLine($"Loading data from {file}");
                string json = File.ReadAllText(file);
                var roomData = JsonConvert.DeserializeObject<RoomSerialzable>(json);

                if (roomData != null)
                {
                    LoadedRooms.Add(roomData);
                    Console.WriteLine($"Data loaded successfully from {file}.");
                }
                else
                {
                    Console.WriteLine($"Deserialized container is null for file: {file}");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from directory: {ex.Message}");
            return false;
        }

        return true;
    }


        
       private static void EnsureDirectoryAndFile(string directory, string filepath)
    {
        if (!Directory.Exists(directory))
        {
            Console.WriteLine($" directory {directory} does not exist. Creating: {directory}");
            Directory.CreateDirectory($"{directory}");
        }

        if (!File.Exists(filepath))
        {
            Console.WriteLine($"Data file does not exist. Creating: {filepath}");
            if (filepath.ToLower().Contains("zone"))
                SaveToZoneDataFile(filepath);
        }
    }
       
    private static bool LoadFromFile(string filePath)
    {
        try
        {
            Console.WriteLine($"Loading data from {filePath}");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var container = Newtonsoft.Json.JsonConvert.DeserializeObject<ZonesContainerSerializable>(json);

                if (container != null)
                {
                    zonesData.MaxCustomRoomsSurface = container.MaxCustomRoomsSurface;
                    zonesData.MaxCustomRoomsLight = container.MaxCustomRoomsLight;
                    zonesData.MaxCustomRoomsEntrance = container.MaxCustomRoomsEntrance;

                    zonesData.HeavyDictionary.Clear();
                    foreach (var entry in container.HeavyDictionary)
                    {
                        zonesData.HeavyDictionary[entry.Key] = entry.Value;
                    }

                    zonesData.SurfaceDictionary.Clear();
                    foreach (var entry in container.SurfaceDictionary)
                    {
                        zonesData.SurfaceDictionary[entry.Key] = entry.Value;
                    }

                    zonesData.LightDictionary.Clear();
                    foreach (var entry in container.LightDictionary)
                    {
                        zonesData.LightDictionary[entry.Key] = entry.Value;
                    }

                    zonesData.EntranceDictionary.Clear();
                    foreach (var entry in container.EntranceDictionary)
                    {
                        zonesData.EntranceDictionary[entry.Key] = entry.Value;
                    }

                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Deserialized container is null.");
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from file: {ex.Message}");
            return false;
        }

        return true;
    }








    private static void SaveToZoneDataFile(string filePath)
    {
        try
        {
           
            var container = new ZonesContainerSerializable()
            {
                HeavyDictionary = zonesData.HeavyDictionary,
                SurfaceDictionary = zonesData.SurfaceDictionary,
                LightDictionary = zonesData.LightDictionary,
                EntranceDictionary = zonesData.EntranceDictionary,
                MaxCustomRoomsLight = zonesData.MaxCustomRoomsLight,
                MaxCustomRoomsEntrance = zonesData.MaxCustomRoomsEntrance,
                MaxCustomRoomsSurface = zonesData.MaxCustomRoomsSurface
                
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(container, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
          
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");
        }
    }

    private static void SaveRoomFile(RoomSerialzable room, string filePath)
    {
        {
            try
            {
           
                var container = new RoomSerialzable()
                {
                    SchematicName = room.SchematicName,
                    Chance = room.Chance,
                    ColorOverrider = room.ColorOverrider,
                    DoorList = room.DoorList,
                    GeneratorData = room.GeneratorData,
                    HazardList = room.HazardList,
                    ItemSpawnLocation = room.ItemSpawnLocation,
                    OverridesColor = room.OverridesColor,
                    Lockers = room.Lockers,
                    PositionOverride = room.PositionOverride,
                    TeleporterList = room.TeleporterList,
                    WorkStationDatas = room.WorkStationDatas
                };

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(container, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
          
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

    }}








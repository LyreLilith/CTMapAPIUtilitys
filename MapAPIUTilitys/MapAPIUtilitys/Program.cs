// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------

using MapAPIUTilitys.MapAPIUtilitys.Enums;
using MapAPIUTilitys.MapAPIUtilitys.Serializables;
using Newtonsoft.Json;


namespace MapAPIUtilitys
{
    public class Program
    {
        private static readonly string UtilityDirectory = Path.Combine(Environment.CurrentDirectory, "MapUtilitys");
        private static readonly string InputDirectory = Path.Combine(UtilityDirectory, "Input");
        private static readonly string OutputDirectory = Path.Combine(UtilityDirectory, "Output");
        private static readonly string DataFilePath = Path.Combine(UtilityDirectory, "zones_data.json");
        private static ZonesContainerSerializable zonesData = new ZonesContainerSerializable();
        private static List<RoomSerialzable> loadedRooms = new List<RoomSerialzable> ();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MapAPIUtilities");
            bool loop = true;

            EnsureDirectoryExists(UtilityDirectory);
            EnsureDirectoryExists(InputDirectory);
            EnsureDirectoryExists(OutputDirectory);

            while (loop)
            {
                DisplayMenu();
                int option = GetMenuOption();

                switch (option)
                {
                    case 1:
                        CreateNewRoom();
                        break;
                    case 2:
                        ImportRoomsToMainJson();
                        break;
                    case 3:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1) Create New Room Json");
            Console.WriteLine("2) Import Room json to main json");
            Console.WriteLine("3) Exit");
        }

        private static int GetMenuOption()
        {
            string input = Console.ReadLine();
            return int.TryParse(input, out int option) ? option : -1;
        }

        private static void CreateNewRoom()
        {
            try
            {
                RoomSerialzable room = RoomConfigMaker.RoomConfig();
                SaveRoomToFile(room);
                Console.WriteLine("Room Json Saved");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void ImportRoomsToMainJson()
        {
            if (LoadFromFile(DataFilePath) && LoadRoomsFromDirectory(InputDirectory))
            {
                AddRoomsToZonesData();
                SaveToZoneDataFile(DataFilePath);
            }
            else
            {
                Console.WriteLine("Failed to load files.");
            }
        }

        private static void AddRoomsToZonesData()
        {
            foreach (var room in loadedRooms)
            {
                AddRoomToDictionary(GetTargetDictionary(room.TypeOfRoom), room);
            }
        }

        private static Dictionary<RoomType, List<RoomSerialzable>> GetTargetDictionary(RoomType roomType)
        {
            if (roomType.ToString().Contains("Hcz"))
            {
                return zonesData.HeavyDictionary;
            }
            else if (roomType.ToString().Contains("Lcz"))
            {
                return zonesData.LightDictionary;
            }
            else if (roomType.ToString().Contains("Ez"))
            {
                return zonesData.EntranceDictionary;
            }
            else if (roomType.ToString().Contains("Surface"))
            {
                return zonesData.SurfaceDictionary;
            }
            else
            {
                throw new ArgumentException($"Unknown RoomType prefix: {roomType}");
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

        private static bool LoadRoomsFromDirectory(string directoryPath)
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
                   

                    if (JsonValidator.ValidateRoom(json))
                    {
                        var roomData = JsonConvert.DeserializeObject<RoomSerialzable>(json);
                        loadedRooms.Add(roomData);
                      
                    }
                    else
                    {
                        Console.WriteLine($"Deserialized container is null for file: {file}");
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

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory not found: {directoryPath}. Creating...");
                Directory.CreateDirectory(directoryPath);
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
            if (JsonValidator.ValidateZonesContainer(json))
            {
                var container = JsonConvert.DeserializeObject<ZonesContainerSerializable>(json);

                if (container != null)
                {
                    zonesData = container;
                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Deserialized container is null.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Validation failed for the JSON data.");
                return false;
            }
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}. Creating a default file.");
            WriteDefaultFile(filePath);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data from file: {ex.Message}");
        return false;
    }

    return true;
}

private static void WriteDefaultFile(string filePath)
{
    try
    {
        var defaultContainer = new ZonesContainerSerializable
        {
            MaxCustomRoomsSurface = 0,
            MaxCustomRoomsLight = 0,
            MaxCustomRoomsEntrance = 0,
            HeavyDictionary = new Dictionary<RoomType, List<RoomSerialzable>>(),
            SurfaceDictionary = new Dictionary<RoomType, List<RoomSerialzable>>(),
            LightDictionary = new Dictionary<RoomType, List<RoomSerialzable>>(),
            EntranceDictionary = new Dictionary<RoomType, List<RoomSerialzable>>()
        };

        string json = JsonConvert.SerializeObject(defaultContainer, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Default data file created successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error writing default data file: {ex.Message}");
    }
}

        private static void SaveToZoneDataFile(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(zonesData, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to file: {ex.Message}");
            }
        }

        private static void SaveRoomToFile(RoomSerialzable room)
        {
            try
            {
                string json = JsonConvert.SerializeObject(room, Formatting.Indented);
                string fileName = Path.Combine(OutputDirectory, $"{room.SchematicName}.json");
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving room to file: {ex.Message}");
            }
        }
    }
}

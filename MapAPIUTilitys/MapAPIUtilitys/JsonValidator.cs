
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;




    public class JsonValidator
    {
         private static readonly string RoomSchemaJson = @"
    {
        ""type"": ""object"",
        ""properties"": {
            ""Chance"": { ""type"": ""number"" },
            ""SchematicName"": { ""type"": ""string"" },
            ""TeleporterList"": { ""type"": ""array"" },
            ""DoorList"": { ""type"": ""array"" },
            ""HazardList"": { ""type"": ""array"" },
            ""PositionOverride"": { ""type"": ""object"", ""properties"": { ""x"": { ""type"": ""number"" }, ""y"": { ""type"": ""number"" }, ""z"": { ""type"": ""number"" } } },
            ""OverridesColor"": { ""type"": ""boolean"" },
            ""ColorOverrider"": { ""type"": ""object"", ""properties"": { ""r"": { ""type"": ""number"" }, ""g"": { ""type"": ""number"" }, ""b"": { ""type"": ""number"" }, ""a"": { ""type"": ""number"" } } },
            ""RotationOverride"": { ""type"": ""object"", ""properties"": { ""x"": { ""type"": ""number"" }, ""y"": { ""type"": ""number"" }, ""z"": { ""type"": ""number"" } } },
            ""WorkStationDatas"": { ""type"": ""array"" },
            ""GeneratorData"": { ""type"": ""array"" },
            ""ItemSpawnLocation"": { ""type"": ""array"" },
            ""Lockers"": { ""type"": ""array"" }
        },
        ""required"": [ ""Chance"", ""SchematicName"", ""TeleporterList"", ""DoorList"", ""HazardList"", ""PositionOverride"", ""OverridesColor"", ""ColorOverrider"", ""RotationOverride"", ""WorkStationDatas"", ""GeneratorData"", ""ItemSpawnLocation"", ""Lockers"" ]
    }";

    // JSON Schema to validate ZonesContainerSerializable
    private static readonly string ZonesSchemaJson = @"
    {
        ""type"": ""object"",
        ""properties"": {
            ""MaxCustomRoomsSurface"": { ""type"": ""number"" },
            ""MaxCustomRoomsLight"": { ""type"": ""number"" },
            ""MaxCustomRoomsEntrance"": { ""type"": ""number"" },
            ""HeavyDictionary"": { ""type"": ""object"" },
            ""SurfaceDictionary"": { ""type"": ""object"" },
            ""LightDictionary"": { ""type"": ""object"" },
            ""EntranceDictionary"": { ""type"": ""object"" }
        },
        ""required"": [ ""MaxCustomRoomsSurface"", ""MaxCustomRoomsLight"", ""MaxCustomRoomsEntrance"", ""HeavyDictionary"", ""SurfaceDictionary"", ""LightDictionary"", ""EntranceDictionary"" ]
    }";

    public static bool ValidateJson(string json, string schemaJson, out IList<string> errorMessages)
    {
        JSchema schema = JSchema.Parse(schemaJson);
        JObject jsonObject = JObject.Parse(json);
        bool isValid = jsonObject.IsValid(schema, out errorMessages);
        return isValid;
    }
    
    
    public static bool ValidateZonesContainer(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            if (ValidateJson(json, ZonesSchemaJson, out IList<string> errorMessages))
            {
                Console.WriteLine("ZonesContainer JSON is valid.");
                return true;
            }
            else
            {
                Console.WriteLine("ZonesContainer JSON is invalid. Errors:");
                foreach (var error in errorMessages)
                {
                    Console.WriteLine($"  - {error}");
                }

                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from file: {ex.Message}");
            return false;
        }
    }
    
    public static bool ValidateRoom(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            if (ValidateJson(json, RoomSchemaJson, out IList<string> errorMessages))
            {
                Console.WriteLine("Room JSON is valid.");
                return true;
            }
            else
            {
                Console.WriteLine("Room JSON is invalid. Errors:");
                foreach (var error in errorMessages)
                {
                    Console.WriteLine($"  - {error}");
                }

                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from file: {ex.Message}");
            return false;
        }
    }
    }


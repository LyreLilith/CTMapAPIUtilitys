namespace CTmapAPI;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Interactables.Interobjects.DoorUtils;

public class DoorDamageTypeConverter : JsonConverter<DoorDamageType>
{
    public override void WriteJson(JsonWriter writer, DoorDamageType value, JsonSerializer serializer)
    {
        var damageList = new List<string>();

        foreach (DoorDamageType damageType in Enum.GetValues(typeof(DoorDamageType)))
        {
            if (value.HasFlag(damageType) && damageType != DoorDamageType.None)
            {
                damageList.Add(damageType.ToString());
            }
        }

        serializer.Serialize(writer, damageList);
    }

    public override DoorDamageType ReadJson(JsonReader reader, Type objectType, DoorDamageType existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var damageList = serializer.Deserialize<List<string>>(reader);
        DoorDamageType damageType = DoorDamageType.None;

        foreach (string damage in damageList)
        {
            if (Enum.TryParse(damage, out DoorDamageType result))
            {
                damageType |= result;
            }
        }

        return damageType;
    }
}
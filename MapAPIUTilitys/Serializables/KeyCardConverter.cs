namespace CTmapAPI;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Interactables.Interobjects.DoorUtils;

public class KeycardPermissionsConverter : JsonConverter<KeycardPermissions>
{
    public override void WriteJson(JsonWriter writer, KeycardPermissions value, JsonSerializer serializer)
    {
        var permissionsList = new List<string>();

        foreach (KeycardPermissions permission in Enum.GetValues(typeof(KeycardPermissions)))
        {
            if (value.HasFlag(permission) && permission != KeycardPermissions.None)
            {
                permissionsList.Add(permission.ToString());
            }
        }

        serializer.Serialize(writer, permissionsList);
    }

    public override KeycardPermissions ReadJson(JsonReader reader, Type objectType, KeycardPermissions existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var permissionsList = serializer.Deserialize<List<string>>(reader);
        KeycardPermissions permissions = KeycardPermissions.None;

        foreach (string permission in permissionsList)
        {
            if (Enum.TryParse(permission, out KeycardPermissions result))
            {
                permissions |= result;
            }
        }

        return permissions;
    }
}

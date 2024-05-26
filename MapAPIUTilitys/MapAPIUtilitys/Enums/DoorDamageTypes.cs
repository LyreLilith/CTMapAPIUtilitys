// -----------------------------------------------------------------------
// <copyright file="doorDamageTYpe" company="SCP: Secret Laboratory">
// Portions of this code are based on work by SCP: Secret Laboratory.
// Licensed under the CC BY-SA 3.0 license.
// 
// Modifications made by LyreLilith
// Licensed under the CC BY-SA 3.0 license
// -----------------------------------------------------------------------


namespace MapAPIUTilitys.MapAPIUtilitys.Enums;

[Flags]
public enum DoorDamageType : byte
{
 
    None = 1,
  
    ServerCommand = 2,
    
    Grenade = 4,
    
    Weapon = 8,
   
    Scp096 = 16
}
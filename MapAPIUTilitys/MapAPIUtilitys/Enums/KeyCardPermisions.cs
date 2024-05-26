// -----------------------------------------------------------------------
// <copyright file="RoomType.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// Modifications made by LyreLilith
// Licensed under the CC BY-SA 3.0 license
// -----------------------------------------------------------------------
namespace MapAPIUTilitys.MapAPIUtilitys.Enums;

[Flags]
public enum KeycardPermissions : ushort
{
    
    None = 0,
 
    Checkpoints = 1,
    
    ExitGates = 2,
   
    Intercom = 4,
    
    AlphaWarhead = 8,
   
    ContainmentLevelOne = 16,
  
    ContainmentLevelTwo = 32,
  
    ContainmentLevelThree = 64,
   
    ArmoryLevelOne = 128,
  
    ArmoryLevelTwo = 256,
   
    ArmoryLevelThree = 512,
    
    ScpOverride = 1024
}


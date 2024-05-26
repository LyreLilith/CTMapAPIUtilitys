// -----------------------------------------------------------------------
// <copyright file="LockEvents.cs" company="LyreLilith">
// © 2024 LyreLilith. All rights reserved.
// Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
// To view a copy of this license, visit https://creativecommons.org/licenses/by-sa/3.0/legalcode
// -----------------------------------------------------------------------

namespace MapAPIUTilitys.MapAPIUtilitys.Enums;

    [Flags]
    public enum LockEvents
    {
        None = 0,
        Time = 1,
        Detonation = 2,
        Decontamination = 4,
        LockDown = 8,
        Contain939 = 16,
        Contain3115 = 32,
        Contain096 = 64,
        Contain049 = 128,
        Contain106 = 256,
        Contain079 = 512,
        OnChaosSpawn = 1024,
        OnMtfSpawn = 2048,
        ExcapedPlayer = 4096,
        Contain173 = 8192
    }

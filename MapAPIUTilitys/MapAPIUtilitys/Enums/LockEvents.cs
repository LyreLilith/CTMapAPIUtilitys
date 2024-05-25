
using System;

namespace CTmapAPI.Enums
{

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
}
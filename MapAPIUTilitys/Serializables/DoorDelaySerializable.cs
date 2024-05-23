
using System;
using CTmapAPI.Enums;

namespace CTmapAPI.Serializables;

    [Serializable]
    public class DoorDelaySerializable
    {
        public LockEvents LockUntilEvent { get; init; }
        public float LockTime { get; init; } = 0;
        
        public DoorDelaySerializable() { }
    }


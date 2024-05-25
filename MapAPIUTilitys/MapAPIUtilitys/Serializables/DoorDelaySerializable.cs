
using System;
using CTmapAPI.Enums;



    [Serializable]
    public class DoorDelaySerializable
    {
        public LockEvents LockUntilEvent { get; set; }
        public float LockTime { get; set; } = 0;
        
        public DoorDelaySerializable() { }
    }


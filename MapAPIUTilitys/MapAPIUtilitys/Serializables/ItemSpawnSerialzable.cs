// -----------------------------------------------------------------------
// <copyright file="ItemSpawnPointSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// Modifications made by LyreLilith
// Licensed under the CC BY-SA 3.0 license
// -----------------------------------------------------------------------



 namespace MapAPIUTilitys.MapAPIUtilitys.Serializables;
    [Serializable]
    public class ItemSpawnSerialzable : PrefabSerialzable
    {
        /// <summary>
        /// Gets or sets the name of the item that will be spawned.
        /// </summary>
        public string Item { get; set; } = "KeycardJanitor";

        /// <summary>
        /// Gets or sets the attachments of the item.
        /// </summary>
        public string AttachmentsCode { get; set; } = "-1";

        /// <summary>
        /// Gets or sets the spawn chance of the item
        /// </summary>
        public int SpawnChance { get; set; } = 100;

        /// <summary>
        /// Gets or sets the number of the spawned items, if the chance succeds
        /// </summary>
        public uint NumberOfItems { get; set; } = 1;

        public int NumberOfUses { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether the spawned item  should be affected by gravity.
        /// </summary>
        public bool UseGravity { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the spawned item can be picked up.
        /// </summary>
        public bool CanBePickedUp { get; set; } = true;
        
    }

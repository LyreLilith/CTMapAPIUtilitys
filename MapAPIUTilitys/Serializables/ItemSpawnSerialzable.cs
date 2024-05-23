
using System;
using CTmapAPI.Serializables;



    [Serializable]
    public class ItemSpawnSerialzable : PrefabSerialzable
    {
        /// <summary>
        /// Gets or sets the name of the item that will be spawned.
        /// <para><see cref="Exiled.CustomItems.API.Features.CustomItem"/> is supported.</para>
        /// </summary>
        public string Item { get; init; } = "KeycardJanitor";

        /// <summary>
        /// Gets or sets the attachments of the item.
        /// <para>This works for <see cref="Exiled.API.Features.Items.Firearm"/> only.</para>
        /// </summary>
        public string AttachmentsCode { get; set; } = "-1";

        /// <summary>
        /// Gets or sets the spawn chance of the <see cref="Exiled.API.Features.Items.Item"/>.
        /// </summary>
        public int SpawnChance { get; set; } = 100;

        /// <summary>
        /// Gets or sets the number of the spawned items, if the <see cref="SpawnChance"/> succeeds.
        /// </summary>
        public uint NumberOfItems { get; set; } = 1;

        public int NumberOfUses { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether the spawned <see cref="Exiled.API.Features.Items.Item"/> should be affected by gravity.
        /// </summary>
        public bool UseGravity { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the spawned <see cref="Exiled.API.Features.Items.Item"/> can be picked up.
        /// </summary>
        public bool CanBePickedUp { get; set; } = true;
        
    }

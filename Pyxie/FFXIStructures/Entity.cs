﻿using Pyxie.Memory;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pyxie.FFXIStructures;

namespace Pyxie.FFXIStructures

{
    public class Entity : FFXIObject<EntityStruct>
    {
        public Entity(MemHandler memHandler, IntPtr baseAddress)
            : base(memHandler, baseAddress)
        {

        }

            /// <summary>
            /// Player index, also their position in the mob array.
            /// </summary>
            public ushort Index { get; set; }
    
            /// <summary>
            /// Player ID, unique across server.
            /// </summary>
            public uint ID { get; set; }
    
            /// <summary>
            /// Boolean indicating whether the entity is a player.
            /// </summary>
            public bool IsNPC { get; set; }

            /// <summary>
            /// Boolean for JaZero.
            /// </summary>
            public bool Freeze { get; set; }

            /// <summary>
            /// Player name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Pointer to the player's display structure.
            /// </summary>
            public IntPtr Display { get; set; }

            /// <summary>
            /// Current distance from this player.
            /// </summary>
            public float Distance { get; set; }

            /// <summary>
            /// Bit flag indicating what sort of entity this is.
            /// </summary>
            public byte MobType { get; set; }

            /// <summary>
            /// Bit flagged Int32: 
            /// Spawned, Enemy, Hidden, Dead
            /// </summary>
            public EntityEnum.Flags3 Flags1 { get; set; }
    
            /// <summary>
            /// Bit flagged Int32: 
            /// Invisible, Seeking, Autogroup, Away, Anonymous,
            /// Help, TempLogged, Linkshell ,ConnectionLost, 
            /// Sound, Object         
            /// </summary>
            public EntityEnum.Flags3 Flags2 { get; set; }

            /// <summary>
            /// Bit flagged Int32:
            /// Bazaar, Promotion, Promotion2,TempLogged2 
            /// GM, Maintenance, NameDeletion</summary>
            public EntityEnum.Flags3 Flags3 { get; set; }


            /// <summary>
            /// Player's movement speed.
            /// </summary>
            public float Speed { get; set; }

            /// <summary>
            /// Player's current status:
            /// Idle, Dead, Engaged, Chocobo, etc.
            /// </summary>
            public EntityEnum.Status Status { get; set; }

            /// <summary>
            /// Player's spawn type:
            /// Party member, alliance member, etc.
            /// </summary>
            public byte SpawnType { get; set; }
    }


    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct EntityStruct
    {
      [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x74)] public ushort Index;
      [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x78)] public uint ID; 
      [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x7B)] public bool IsNPC;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] [FieldOffset(0x7C)] public string Name;
      [FieldOffset(0xA0)] public IntPtr Display;
      [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xD8)] public float Distance;
      [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x11C)] public bool Freeze;
      [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x11E)] public byte MobType;
      [MarshalAs(UnmanagedType.U4)] [FieldOffset(0x120)] public EntityEnum.Flags1 Flags1;
      [MarshalAs(UnmanagedType.U4)] [FieldOffset(0x124)] public EntityEnum.Flags2 Flags2;
      [MarshalAs(UnmanagedType.U4)] [FieldOffset(0x128)] public EntityEnum.Flags3 Flags3;
      [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x158)] public float Speed;
      [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x168)] public EntityEnum.Status Status;
      [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1C4)] public byte SpawnType;
    }


}

namespace EntityEnum
{
      public enum Status {
        Idle                    = 0x00,
        Engaged                 = 0x01,
        Dead                    = 0x02,
        EngagedDead             = 0x03,
        Event                   = 0x04,
        Chocobo                 = 0x05,
        Debug                   = 0x1C,
        Resting                 = 0x21,
        Locked                  = 0x22,
        FishingFighting         = 0x26,
        FishingCaught           = 0x27,
        FishingBrokeRod         = 0x28,
        FishingBrokeLine        = 0x29,
        FishingCaughtMonster    = 0x2A,
        FishingLostCatch        = 0x2B,
        Crafting                = 0x2C,
        Sitting                 = 0x2F,
        Kneeling                = 0x30,
        Fishing                 = 0x32,
        FishingFightingCenter   = 0x33,
        FishingFightingRight    = 0x34,
        FishingFightingLeft     = 0x35,
    };

   [Flags]
    public enum Flags1 : uint
    {
        Spawned         = 0x00000004,
        Enemy           = 0x00000020,
        Dead            = 0x00000400,
        Hidden          = 0x00004000,
    };
    
    [Flags]
    public enum Flags2 : uint
    {
        Despawned       = 0x00000010,
        Seeking         = 0x00001000,
        Autogroup       = 0x00002000,
        Away            = 0x00004000,
        Anonymous       = 0x00008000,
        Help            = 0x00010000,
        TempLogged      = 0x00040000,
        Linkshell       = 0x00080000,
        ConnectionLost  = 0x00100000,
        Sound           = 0x01000000,
        Object          = 0x08000000,
        Invisible       = 0x40000000,
        Invisible2      = 0x80000000,
    };
    
    [Flags]
    public enum Flags3 : uint
    {
        Bazaar          = 0x00000020,
        Promotion       = 0x00000800, 
        Promotion2      = 0x00001000, 
        TempLogged2     = 0x00001800,
        GM              = 0x00002000,
        Maintenance     = 0x00004000,
        NameDeletion    = 0x80000000,
    };
    
    //[Flags]
    //public enum Field4 : uint
    //{
    //    bytemed         = 0x00000020,
    //};
    
    //[Flags]
    //public enum Field5 : uint
    //{
    //    NameHidden      = 0x00000001,
    //    Mentor          = 0x00000020,
    //    NewPlayer       = 0x00000040,
    //    TrialAccount    = 0x00000080,
    //    VisibleDistance = 0x00000100,
    //    Transparent     = 0x00000800,
    //    HPCloak         = 0x00002000,
    //    LevelSync       = 0x00010000
    //};
    
    //[Flags]
    //public enum Field6 : uint
    //{
    //};
}
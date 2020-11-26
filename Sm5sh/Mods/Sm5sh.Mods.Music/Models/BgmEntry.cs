﻿using Sm5sh.Mods.Music.Helpers;
using Sm5sh.Mods.Music.Interfaces;
using System;
using System.Collections.Generic;

namespace Sm5sh.Mods.Music.Models
{
    public class BgmEntry
    {
        //ID - Some fields within the children objects are derivated from it
        public string ToneId { get; }
        public string ModId { get { return MusicMod?.Mod.Id; } }
        public string GameTitleId { get { return GameTitle != null ? GameTitle.UiGameTitleId : Constants.InternalIds.GAME_TITLE_ID_DEFAULT; } }
        public string Filename { get; set; }

        public IMusicMod MusicMod { get; set; }
        public GameTitleEntry GameTitle { get; set; }

        public BgmEntryModels.NUS3BankConfigEntry NUS3BankConfig { get; }
        public BgmEntryModels.MSBTLabelsEntry MSBTLabels { get; }
        public BgmEntryModels.BgmPropertyEntry BgmProperties { get; }
        public BgmEntryModels.BgmDbRootEntry DbRoot { get; }
        public BgmEntryModels.BgmAssignedInfoEntry AssignedInfo { get; }
        public BgmEntryModels.BgmStreamSetEntry StreamSet { get; }
        public BgmEntryModels.BgmStreamPropertyEntry StreamingProperty { get; }
        public Dictionary<string, List<BgmEntryModels.BgmPlaylistEntry>> Playlists { get; }


        //Helper objects for common properties
        public string RecordType { get { return DbRoot.RecordType; } }
        public short SoundTestIndex { get { return DbRoot.TestDispOrder; } }
        public bool IsDlcOrPatch { get { return DbRoot.IsDlc || DbRoot.IsPatch; } }
        public BgmEntryModels.EntrySource Source { get { return MusicMod == null ? BgmEntryModels.EntrySource.Core : BgmEntryModels.EntrySource.Mod; } }


        //KeyHelper
        public string DbRootKey { get { return DbRoot.UiBgmId; } }
        public string StreamSetKey { get { return StreamSet.StreamSetId; } }
        public string AssignedInfoKey { get { return AssignedInfo.InfoId; } }
        public string StreamPropertyKey { get { return StreamingProperty.StreamId; } }

        public BgmEntryModels.SpecialCategoryEntry SpecialCategory { get { return GetSpecialCategory(); } }

        public bool HiddenInSoundTest { get { return DbRoot.SaveNo == -1 || DbRoot.TestDispOrder == -1; } }

        public BgmEntry(string toneId, IMusicMod musicMod = null)
        {
            ToneId = toneId;
            MusicMod = musicMod;
            MSBTLabels = new BgmEntryModels.MSBTLabelsEntry(this)
            {
                Title = new Dictionary<string, string>(),
                Author = new Dictionary<string, string>(),
                Copyright = new Dictionary<string, string>()
            };
            BgmProperties = new BgmEntryModels.BgmPropertyEntry(this);
            NUS3BankConfig = new BgmEntryModels.NUS3BankConfigEntry(this);
            DbRoot = new BgmEntryModels.BgmDbRootEntry(this)
            {
                Rarity = Constants.InternalIds.RARITY_DEFAULT,
                RecordType = Constants.InternalIds.RECORD_TYPE_DEFAULT,
                UiGameTitleId1 = Constants.InternalIds.GAME_TITLE_ID_DEFAULT,
                UiGameTitleId2 = Constants.InternalIds.GAME_TITLE_ID_DEFAULT,
                UiGameTitleId3 = Constants.InternalIds.GAME_TITLE_ID_DEFAULT,
                UiGameTitleId4 = Constants.InternalIds.GAME_TITLE_ID_DEFAULT,
                SaveNo = -1,
                TestDispOrder = -1,
                JpRegion = true,
                OtherRegion = true,
                Possessed = true,
                PrizeLottery = false,
                ShopPrice = 0,
                CountTarget = true,
                MenuLoop = 1,
                IsSelectableStageMake = true,
                Unk1 = true,
                Unk2 = true,
                IsDlc = false,
                IsPatch = false
            };
            AssignedInfo = new BgmEntryModels.BgmAssignedInfoEntry(this)
            {
                Condition = Constants.InternalIds.SOUND_CONDITION,
                ConditionProcess = "0x1b9fe75d3f",
                ChangeFadoutFrame = 55,
                MenuChangeFadeOutFrame = 55
            };
            StreamSet = new BgmEntryModels.BgmStreamSetEntry(this);
            StreamingProperty = new BgmEntryModels.BgmStreamPropertyEntry(this)
            {
                Loop = 1,
                EndPoint = "00:00:15.000",
                FadeOutFrame = 400,
                StartPointTransition = "00:00:04.000"
            };
            Playlists = new Dictionary<string, List<BgmEntryModels.BgmPlaylistEntry>>();
        }

        public override string ToString()
        {
            return ToneId;
        }

        private BgmEntryModels.SpecialCategoryEntry GetSpecialCategory()
        {
            var specialCategory = new BgmEntryModels.SpecialCategoryEntry()
            {
                Id = StreamSet.SpecialCategory,
                Parameters = new List<string>()
            };
            if (!string.IsNullOrEmpty(StreamSet.Info1))
                specialCategory.Parameters.Add(StreamSet.Info1);
            if (!string.IsNullOrEmpty(StreamSet.Info2))
                specialCategory.Parameters.Add(StreamSet.Info2);
            if (!string.IsNullOrEmpty(StreamSet.Info3))
                specialCategory.Parameters.Add(StreamSet.Info3);
            if (!string.IsNullOrEmpty(StreamSet.Info4))
                specialCategory.Parameters.Add(StreamSet.Info4);
            if (!string.IsNullOrEmpty(StreamSet.Info5))
                specialCategory.Parameters.Add(StreamSet.Info5);
            if (!string.IsNullOrEmpty(StreamSet.Info6))
                specialCategory.Parameters.Add(StreamSet.Info6);
            if (!string.IsNullOrEmpty(StreamSet.Info7))
                specialCategory.Parameters.Add(StreamSet.Info7);
            if (!string.IsNullOrEmpty(StreamSet.Info8))
                specialCategory.Parameters.Add(StreamSet.Info8);
            if (!string.IsNullOrEmpty(StreamSet.Info9))
                specialCategory.Parameters.Add(StreamSet.Info9);
            if (!string.IsNullOrEmpty(StreamSet.Info10))
                specialCategory.Parameters.Add(StreamSet.Info10);
            if (!string.IsNullOrEmpty(StreamSet.Info11))
                specialCategory.Parameters.Add(StreamSet.Info11);
            if (!string.IsNullOrEmpty(StreamSet.Info12))
                specialCategory.Parameters.Add(StreamSet.Info12);
            if (!string.IsNullOrEmpty(StreamSet.Info13))
                specialCategory.Parameters.Add(StreamSet.Info13);
            if (!string.IsNullOrEmpty(StreamSet.Info14))
                specialCategory.Parameters.Add(StreamSet.Info14);
            if (!string.IsNullOrEmpty(StreamSet.Info15))
                specialCategory.Parameters.Add(StreamSet.Info15);
            return specialCategory;
        }
    }

    namespace BgmEntryModels
    {
        public class BgmPropertyEntry
        {
            public BgmEntry Parent { get; }
            public string NameId { get { return Parent.ToneId; } }
            public ulong LoopStartMs { get; set; }
            public ulong LoopStartSample { get; set; }
            public ulong LoopEndMs { get; set; }
            public ulong LoopEndSample { get; set; }
            public ulong TotalTimeMs { get; set; }
            public ulong TotalSamples { get; set; }
            public ulong Frequency { get { return TotalTimeMs / 1000 * TotalSamples; } }

            public BgmPropertyEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class NUS3BankConfigEntry
        {
            public BgmEntry Parent { get; }
            public float AudioVolume { get; set; }

            public NUS3BankConfigEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class MSBTLabelsEntry
        {
            public BgmEntry Parent { get; }

            public Dictionary<string, string> Title { get; set; }
            public Dictionary<string, string> Copyright { get; set; }
            public Dictionary<string, string> Author { get; set; }
            public string TitleKey { get { return !string.IsNullOrEmpty(Parent.DbRoot.NameId) ? string.Format(Constants.InternalIds.MSBT_BGM_TITLE, Parent.DbRoot.NameId) : null; } }
            public string AuthorKey { get { return !string.IsNullOrEmpty(Parent.DbRoot.NameId) ? string.Format(Constants.InternalIds.MSBT_BGM_AUTHOR, Parent.DbRoot.NameId) : null; } }
            public string CopyrightKey { get { return !string.IsNullOrEmpty(Parent.DbRoot.NameId) ? string.Format(Constants.InternalIds.MSBT_BGM_COPYRIGHT, Parent.DbRoot.NameId) : null; } }

            public MSBTLabelsEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class BgmDbRootEntry
        {
            public BgmEntry Parent { get; }

            public string UiBgmId { get { return $"{Constants.InternalIds.UI_BGM_ID_PREFIX}{Parent.ToneId}"; } }
            public string StreamSetId { get { return $"{Constants.InternalIds.STREAM_SET_PREFIX}{Parent.ToneId}"; } }
            public string Rarity { get; set; }
            public string RecordType { get; set; }
            public string UiGameTitleId { get { return Parent.GameTitleId; } }
            public string UiGameTitleId1 { get; set; }
            public string UiGameTitleId2 { get; set; }
            public string UiGameTitleId3 { get; set; }
            public string UiGameTitleId4 { get; set; }
            public string NameId { get; set; }
            public short SaveNo { get; set; }
            public short TestDispOrder { get; set; }
            public int MenuValue { get; set; }
            public bool JpRegion { get; set; }
            public bool OtherRegion { get; set; }
            public bool Possessed { get; set; }
            public bool PrizeLottery { get; set; }
            public uint ShopPrice { get; set; }
            public bool CountTarget { get; set; }
            public byte MenuLoop { get; set; }
            public bool IsSelectableStageMake { get; set; }
            public bool Unk1 { get; set; }
            public bool Unk2 { get; set; }
            public bool IsDlc { get; set; }
            public bool IsPatch { get; set; }
            public string Unk3 { get; set; }
            public string Unk4 { get; set; }
            public string Unk5 { get; set; }

            public BgmDbRootEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class BgmStreamSetEntry
        {
            public BgmEntry Parent { get; }

            public string StreamSetId { get { return $"{Constants.InternalIds.STREAM_SET_PREFIX}{Parent.ToneId}"; } }
            public string SpecialCategory { get; set; }
            public string Info0 { get { return $"{Constants.InternalIds.INFO_ID_PREFIX}{Parent.ToneId}"; } }
            public string Info1 { get; set; }
            public string Info2 { get; set; }
            public string Info3 { get; set; }
            public string Info4 { get; set; }
            public string Info5 { get; set; }
            public string Info6 { get; set; }
            public string Info7 { get; set; }
            public string Info8 { get; set; }
            public string Info9 { get; set; }
            public string Info10 { get; set; }
            public string Info11 { get; set; }
            public string Info12 { get; set; }
            public string Info13 { get; set; }
            public string Info14 { get; set; }
            public string Info15 { get; set; }

            public BgmStreamSetEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class BgmAssignedInfoEntry
        {
            public BgmEntry Parent { get; }

            public string InfoId { get { return $"{Constants.InternalIds.INFO_ID_PREFIX}{Parent.ToneId}"; } }
            public string StreamId { get { return $"{Constants.InternalIds.STREAM_PREFIX}{Parent.ToneId}"; } }
            public string Condition { get; set; }
            public string ConditionProcess { get; set; }
            public int StartFrame { get; set; }
            public int ChangeFadeInFrame { get; set; }
            public int ChangeStartDelayFrame { get; set; }
            public int ChangeFadoutFrame { get; set; }
            public int ChangeStopDelayFrame { get; set; }
            public int MenuChangeFadeInFrame { get; set; }
            public int MenuChangeStartDelayFrame { get; set; }
            public int MenuChangeFadeOutFrame { get; set; }
            public int Unk1 { get; set; }

            public BgmAssignedInfoEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class BgmStreamPropertyEntry
        {
            public BgmEntry Parent { get; }

            public string StreamId { get { return $"{Constants.InternalIds.STREAM_PREFIX}{Parent.ToneId}"; } }
            public string DateName0 { get { return Parent.ToneId; } }
            public string DateName1 { get; set; }
            public string DateName2 { get; set; }
            public string DateName3 { get; set; }
            public string DateName4 { get; set; }
            public byte Loop { get; set; }
            public string EndPoint { get; set; }
            public ushort FadeOutFrame { get; set; }
            public string StartPointSuddenDeath { get; set; }
            public string StartPointTransition { get; set; }
            public string StartPoint0 { get; set; }
            public string StartPoint1 { get; set; }
            public string StartPoint2 { get; set; }
            public string StartPoint3 { get; set; }
            public string StartPoint4 { get; set; }

            public BgmStreamPropertyEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        public class BgmPlaylistEntry
        {
            public BgmEntry Parent { get; }

            public string UiBgmId { get { return $"{Constants.InternalIds.UI_BGM_ID_PREFIX}{Parent.ToneId}"; } }
            public short Order0 { get; set; }
            public ushort Incidence0 { get; set; }
            public short Order1 { get; set; }
            public ushort Incidence1 { get; set; }
            public short Order2 { get; set; }
            public ushort Incidence2 { get; set; }
            public short Order3 { get; set; }
            public ushort Incidence3 { get; set; }
            public short Order4 { get; set; }
            public ushort Incidence4 { get; set; }
            public short Order5 { get; set; }
            public ushort Incidence5 { get; set; }
            public short Order6 { get; set; }
            public ushort Incidence6 { get; set; }
            public short Order7 { get; set; }
            public ushort Incidence7 { get; set; }
            public short Order8 { get; set; }
            public ushort Incidence8 { get; set; }
            public short Order9 { get; set; }
            public ushort Incidence9 { get; set; }
            public short Order10 { get; set; }
            public ushort Incidence10 { get; set; }
            public short Order11 { get; set; }
            public ushort Incidence11 { get; set; }
            public short Order12 { get; set; }
            public ushort Incidence12 { get; set; }
            public short Order13 { get; set; }
            public ushort Incidence13 { get; set; }
            public short Order14 { get; set; }
            public ushort Incidence14 { get; set; }
            public short Order15 { get; set; }
            public ushort Incidence15 { get; set; }

            public BgmPlaylistEntry(BgmEntry parent)
            {
                Parent = parent;
            }
        }

        //Facilitators
        public enum EntrySource
        {
            Unknown = 0,
            Core = 1,
            Mod = 2
        }

        public class SpecialCategoryEntry
        {
            public string Id { get; set; }

            public List<string> Parameters { get; set; }
        }
    }
}

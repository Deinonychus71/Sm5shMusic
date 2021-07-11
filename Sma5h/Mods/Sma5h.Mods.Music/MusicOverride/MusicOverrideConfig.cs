﻿using Newtonsoft.Json;
using Sma5h.Mods.Music.MusicMods.MusicModModels;
using Sma5h.Mods.Music.MusicOverride.MusicOverrideConfigModels;
using System.Collections.Generic;

namespace Sma5h.Mods.Music.MusicOverride
{
    public class MusicOverrideConfig
    {
        public SoundTestOrder SoundTestOrder { get; set; }
        public Dictionary<string, PlaylistConfig> PlaylistsOverrides { get; set; }
        public Dictionary<string, StageConfig> StageOverrides { get; set; }
        public Dictionary<string, GameConfig> CoreGameOverrides { get; set; }
        public CoreBgmOverrides CoreBgmOverrides { get; set; }

        public MusicOverrideConfig()
        {
            SoundTestOrder = new SoundTestOrder();
            PlaylistsOverrides = new Dictionary<string, PlaylistConfig>();
            StageOverrides = new Dictionary<string, StageConfig>();
            CoreGameOverrides = new Dictionary<string, GameConfig>();
            CoreBgmOverrides = new CoreBgmOverrides();
        }
    }

    namespace MusicOverrideConfigModels
    {
        public class CoreBgmOverrides
        {
            public Dictionary<string, BgmDbRootConfig> CoreBgmDbRootOverrides { get; set; }
            public Dictionary<string, BgmStreamSetConfig> CoreBgmStreamSetOverrides { get; set; }
            public Dictionary<string, BgmAssignedInfoConfig> CoreBgmAssignedInfoOverrides { get; set; }
            public Dictionary<string, BgmStreamPropertyConfig> CoreBgmStreamPropertyOverrides { get; set; }
            public Dictionary<string, BgmPropertyEntryConfig> CoreBgmPropertyOverrides { get; set; }

            public CoreBgmOverrides()
            {
                CoreBgmDbRootOverrides = new Dictionary<string, BgmDbRootConfig>();
                CoreBgmStreamSetOverrides = new Dictionary<string, BgmStreamSetConfig>();
                CoreBgmAssignedInfoOverrides = new Dictionary<string, BgmAssignedInfoConfig>();
                CoreBgmStreamPropertyOverrides = new Dictionary<string, BgmStreamPropertyConfig>();
                CoreBgmPropertyOverrides = new Dictionary<string, BgmPropertyEntryConfig>();
            }
        }

        public class SoundTestOrder
        {
            [JsonProperty("version")]
            public int Version { get; set; }

            [JsonProperty("entries")]
            public List<SoundTestOrderEntry> Entries { get; set; }
        }

        public class SoundTestOrderEntry
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class SoundTestOrderFolder: SoundTestOrderEntry
        {
            [JsonProperty("entries")]
            public List<SoundTestOrderEntry> Entries { get; set; }

            [JsonProperty("default_ui_series")]
            public List<string> DefaultUiSeries { get; set; }

            [JsonProperty("default_ui_gametitle")]
            public List<string> DefaultUiGameTitle { get; set; }

            [JsonProperty("default_mod")]
            public List<string> DefaultUiMod { get; set; }
        }

        public class SoundTestOrderBgm : SoundTestOrderEntry
        {
        }

        public class PlaylistConfig
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("tracks")]
            public List<PlaylistValueConfig> Tracks { get; set; }
        }

        public class PlaylistValueConfig
        {
            [JsonProperty("ui_bgm_id")]
            public string UiBgmId { get; set; }

            [JsonProperty("o0")]
            public short Order0 { get; set; }

            [JsonProperty("i0")]
            public ushort Incidence0 { get; set; }

            [JsonProperty("o1")]
            public short Order1 { get; set; }

            [JsonProperty("i1")]
            public ushort Incidence1 { get; set; }

            [JsonProperty("o2")]
            public short Order2 { get; set; }

            [JsonProperty("i2")]
            public ushort Incidence2 { get; set; }

            [JsonProperty("o3")]
            public short Order3 { get; set; }

            [JsonProperty("i3")]
            public ushort Incidence3 { get; set; }

            [JsonProperty("o4")]
            public short Order4 { get; set; }

            [JsonProperty("i4")]
            public ushort Incidence4 { get; set; }

            [JsonProperty("o5")]
            public short Order5 { get; set; }

            [JsonProperty("i5")]
            public ushort Incidence5 { get; set; }

            [JsonProperty("o6")]
            public short Order6 { get; set; }

            [JsonProperty("i6")]
            public ushort Incidence6 { get; set; }

            [JsonProperty("o7")]
            public short Order7 { get; set; }

            [JsonProperty("i7")]
            public ushort Incidence7 { get; set; }

            [JsonProperty("o8")]
            public short Order8 { get; set; }

            [JsonProperty("i8")]
            public ushort Incidence8 { get; set; }

            [JsonProperty("o9")]
            public short Order9 { get; set; }

            [JsonProperty("i9")]
            public ushort Incidence9 { get; set; }

            [JsonProperty("o10")]
            public short Order10 { get; set; }

            [JsonProperty("i10")]
            public ushort Incidence10 { get; set; }

            [JsonProperty("o11")]
            public short Order11 { get; set; }

            [JsonProperty("i11")]
            public ushort Incidence11 { get; set; }

            [JsonProperty("o12")]
            public short Order12 { get; set; }

            [JsonProperty("i12")]
            public ushort Incidence12 { get; set; }

            [JsonProperty("o13")]
            public short Order13 { get; set; }

            [JsonProperty("i13")]
            public ushort Incidence13 { get; set; }

            [JsonProperty("o14")]
            public short Order14 { get; set; }

            [JsonProperty("i14")]
            public ushort Incidence14 { get; set; }

            [JsonProperty("o15")]
            public short Order15 { get; set; }

            [JsonProperty("i15")]
            public ushort Incidence15 { get; set; }
        }

        public class StageConfig
        {
            [JsonProperty("ui_stage_id")]
            public string UiStageId { get; set; }

            [JsonProperty("name_id")]
            public string NameId { get; set; }

            [JsonProperty("save_no")]
            public short SaveNo { get; set; }

            [JsonProperty("ui_series_id")]
            public string UiSeriesId { get; set; }

            [JsonProperty("can_select")]
            public bool CanSelect { get; set; }

            [JsonProperty("disp_order")]
            public sbyte DispOrder { get; set; }

            [JsonProperty("stage_place_id")]
            public string StagePlaceId { get; set; }

            [JsonProperty("secret_stage_place_id")]
            public string SecretStagePlaceId { get; set; }

            [JsonProperty("can_demo")]
            public bool CanDemo { get; set; }

            [JsonProperty("0x10359e17b0")]
            public bool Unk1 { get; set; }

            [JsonProperty("is_usable_flag")]
            public bool IsUsableFlag { get; set; }

            [JsonProperty("is_usable_amiibo")]
            public bool IsUsableAmiibo { get; set; }

            [JsonProperty("secret_command_id")]
            public string SecretCommandId { get; set; }

            [JsonProperty("secret_command_id_joycon")]
            public string SecretCommandIdJoycon { get; set; }

            [JsonProperty("bgm_set_id")]
            public string BgmSetId { get; set; }

            [JsonProperty("bgm_setting_no")]
            public byte BgmSettingNo { get; set; }

            [JsonProperty("bgm_selector")]
            public bool BgmSelector { get; set; }

            [JsonProperty("is_dlc")]
            public bool IsDlc { get; set; }

            [JsonProperty("is_patch")]
            public bool IsPatch { get; set; }

            [JsonProperty("dlc_chara_id")]
            public string DlcCharaId { get; set; }

            //Field here to handle older json version that did not have the discovered name
            [JsonProperty("0x0eafe0fa76")]
            public bool? Unk2 { get; set; }

            [JsonProperty("0x10005d116c")]
            public bool? Unk3 { get; set; }

            [JsonProperty("0x0cbc118b10")]
            public bool? Unk4 { get; set; }

            public bool ShouldSerializeUnk2()
            {
                return false;
            }

            public bool ShouldSerializeUnk3()
            {
                return false;
            }

            public bool ShouldSerializeUnk4()
            {
                return false;
            }
        }
    }
}

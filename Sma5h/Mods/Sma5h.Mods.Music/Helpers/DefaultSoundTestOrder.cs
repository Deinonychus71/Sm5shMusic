using Sma5h.Mods.Music.MusicOverride.MusicOverrideConfigModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sma5h.Mods.Music.Helpers
{
    public static class DefaultSoundTestOrder
    {
        public static SoundTestOrder GetNewDefaultSoundTestOrder()
        {
            return new SoundTestOrder()
            {
                Version = 2,
                Entries = new List<SoundTestOrderEntry>()
                {
                    GetSmashBrosIntro(),
                    new SoundTestOrderFolder() { Id = "mario", DefaultUiSeries = new List<string>(){ "ui_series_mario" }, Entries = new List<SoundTestOrderEntry>()
                        {
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00a_maintheme_jp" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00b_maintheme_en" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_01_menu" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_02_senjyou" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_03_shuuten" },
                        }
                    },
                }
            };
        }

        private static SoundTestOrderFolder GetSmashBrosIntro()
        {
            return new SoundTestOrderFolder()
            {
                Id = "smash_bros_intro",
                Entries = new List<SoundTestOrderEntry>()
                {
                    new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00a_maintheme_jp" },
                    new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00b_maintheme_en" },
                    new SoundTestOrderBgm() { Id = "ui_bgm_crs2_01_menu" },
                    new SoundTestOrderBgm() { Id = "ui_bgm_crs2_02_senjyou" },
                    new SoundTestOrderBgm() { Id = "ui_bgm_crs2_03_shuuten" },
                }
            };
        }

        private static SoundTestOrderFolder GetMarioSeries()
        {
            return new SoundTestOrderFolder()
            {
                Id = "mario",
                DefaultUiSeries = new List<string>() { 
                    "ui_series_mario"
                },
                Entries = new List<SoundTestOrderEntry>()
                {
                    new SoundTestOrderFolder()
                    {
                        Id = "mario",
                        DefaultUiGameTitle = new List<string>() { 
                            "ui_gametitle_mariobros",
                            "ui_gametitle_super_mario_bros_lost_levels"

                        },
                        Entries = new List<SoundTestOrderEntry>()
                        {
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00a_maintheme_jp" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_00b_maintheme_en" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_01_menu" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_02_senjyou" },
                            new SoundTestOrderBgm() { Id = "ui_bgm_crs2_03_shuuten" },
                        }
                    }
                }
            };
        }
    }
}

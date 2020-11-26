﻿using ReactiveUI.Fody.Helpers;
using Sm5sh.GUI.Helpers;
using Sm5sh.Mods.Music.Models;
using VGMMusic;
using System.Linq;
using System;
using System.IO;
using ReactiveUI;
using System.Reactive;
using System.Collections.Generic;
using Sm5sh.Mods.Music.Interfaces;

namespace Sm5sh.GUI.ViewModels
{
    public class BgmEntryViewModel : ViewModelBase
    {
        private readonly BgmEntry _refBgmEntry;

        public bool AllFlag { get; set; }

        public string ToneId { get; private set; }
        public string SeriesId { get; set; }
        public string GameId { get; set; }
        public string SeriesTitle { get; set; }
        [Reactive]
        public string GameTitle { get; set; }
        [Reactive]
        public string Title { get; private set; }
        [Reactive]
        public string Copyright { get; set; }
        [Reactive]
        public string Author { get; set; }
        public string Filename { get; private set; }
        public string RecordTypeId { get; private set; }
        public string RecordTypeLabel { get; private set; }
        public bool HiddenInSoundTest { get; private set; }
        [Reactive]
        public short SoundTestIndex { get; set; }
        public string ModName { get; set; }
        public string ModAuthor { get; set; }
        public string ModWebsite { get; set; }
        public string ModPath { get; set; }
        public Mods.Music.Models.BgmEntryModels.EntrySource Source { get; private set; }
        public string PlaylistIds { get; private set; }
        public string SpecialCategoryLabel { get; private set; }
        public string SpecialParam1Label { get; private set; }
        public string SpecialParam2Label { get; private set; }
        public string SpecialParam3Label { get; private set; }
        public string SpecialParam4Label { get; private set; }

        public MusicPlayerViewModel MusicPlayer { get; set; }
        public bool IsMod { get; private set; }
        public bool DoesFileExist { get; private set; }

        public BgmEntryViewModel(IVGMMusicPlayer musicPlayer, BgmEntry bgmEntry)
        {
            _refBgmEntry = bgmEntry;

            //1:1 Mapping with BgmEntry
            Source = bgmEntry.Source;
            ToneId = bgmEntry.ToneId;
            RecordTypeId = bgmEntry.RecordType;
            SoundTestIndex = bgmEntry.SoundTestIndex;
            HiddenInSoundTest = bgmEntry.HiddenInSoundTest;
            SeriesId = bgmEntry.GameTitle?.UiSeriesId;
            GameId = bgmEntry.GameTitle?.UiGameTitleId;
            Filename = bgmEntry.Filename;
            ModName = bgmEntry.MusicMod?.Mod.Name;
            ModAuthor = bgmEntry.MusicMod?.Mod.Author;
            ModWebsite = bgmEntry.MusicMod?.Mod.Website;
            ModPath = bgmEntry.MusicMod?.ModPath;

            //Music Player
            DoesFileExist = File.Exists(bgmEntry.Filename);
            if (DoesFileExist)
                MusicPlayer = new MusicPlayerViewModel(musicPlayer, bgmEntry.Filename);

            //Calculated Fields
            IsMod = Source == Mods.Music.Models.BgmEntryModels.EntrySource.Mod;
            SeriesTitle = Constants.GetSeriesDisplayName(SeriesId);
            RecordTypeLabel = Constants.GetRecordTypeDisplayName(bgmEntry.RecordType);
            PlaylistIds = string.Join(Environment.NewLine, bgmEntry.Playlists.Select(p => p.Key));
            if (bgmEntry.SpecialCategory != null)
            {
                SpecialCategoryLabel = Constants.GetSpecialCategoryDisplayName(bgmEntry.SpecialCategory.Id);
                if (bgmEntry.SpecialCategory.Parameters.Count >= 1)
                    SpecialParam1Label = bgmEntry.SpecialCategory.Parameters[0];
                if (bgmEntry.SpecialCategory.Parameters.Count >= 2)
                    SpecialParam2Label = bgmEntry.SpecialCategory.Parameters[1];
                if (bgmEntry.SpecialCategory.Parameters.Count >= 3)
                    SpecialParam3Label = bgmEntry.SpecialCategory.Parameters[2];
                if (bgmEntry.SpecialCategory.Parameters.Count >= 4)
                    SpecialParam4Label = bgmEntry.SpecialCategory.Parameters[3];
            }
        }

        public BgmEntryViewModel() { }

        public void LoadLocalized(string locale)
        {
            if (_refBgmEntry.GameTitle.MSBTTitle != null && _refBgmEntry.GameTitle.MSBTTitle.ContainsKey(locale))
                GameTitle = _refBgmEntry.GameTitle.MSBTTitle[locale];
            else
                GameTitle = GameId;

            if (_refBgmEntry.MSBTLabels.Title != null && _refBgmEntry.MSBTLabels.Title.ContainsKey(locale))
                Title = _refBgmEntry.MSBTLabels.Title[locale];
            else
                Title = ToneId;

            if (_refBgmEntry.MSBTLabels.Copyright != null && _refBgmEntry.MSBTLabels.Copyright.ContainsKey(locale))
                Copyright = _refBgmEntry.MSBTLabels.Copyright[locale];
            else
                Copyright = string.Empty;

            if (_refBgmEntry.MSBTLabels.Author != null && _refBgmEntry.MSBTLabels.Author.ContainsKey(locale))
                Author = _refBgmEntry.MSBTLabels.Author[locale];
            else
                Author = string.Empty;
        }
    }
}

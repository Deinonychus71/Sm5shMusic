﻿using AutoMapper;
using ReactiveUI.Fody.Helpers;
using Sm5sh.Mods.Music.Models;
using Sm5shMusic.GUI.Interfaces;

namespace Sm5shMusic.GUI.ViewModels
{
    public class BgmStreamSetEntryViewModel : BgmBaseViewModel<BgmStreamSetEntry>
    {
        public string StreamSetId { get; }
        [Reactive]
        public string SpecialCategory { get; set; }
        public string Info0 { get; set; }
        [Reactive]
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
        

        //Getter Helpers
        public BgmAssignedInfoEntryViewModel Info0ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info0); } }
        public BgmAssignedInfoEntryViewModel Info1ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info1); } }
        public BgmAssignedInfoEntryViewModel Info2ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info2); } }
        public BgmAssignedInfoEntryViewModel Info3ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info3); } }
        public BgmAssignedInfoEntryViewModel Info4ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info4); } }
        public BgmAssignedInfoEntryViewModel Info5ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info5); } }
        public BgmAssignedInfoEntryViewModel Info6ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info6); } }
        public BgmAssignedInfoEntryViewModel Info7ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info7); } }
        public BgmAssignedInfoEntryViewModel Info8ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info8); } }
        public BgmAssignedInfoEntryViewModel Info9ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info9); } }
        public BgmAssignedInfoEntryViewModel Info10ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info10); } }
        public BgmAssignedInfoEntryViewModel Info11ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info11); } }
        public BgmAssignedInfoEntryViewModel Info12ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info12); } }
        public BgmAssignedInfoEntryViewModel Info13ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info13); } }
        public BgmAssignedInfoEntryViewModel Info14ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info14); } }
        public BgmAssignedInfoEntryViewModel Info15ViewModel { get { return _audioStateManager.GetBgmAssignedInfoViewModel(Info15); } }


        public BgmStreamSetEntryViewModel(IAudioStateViewModelManager audioStateManager, IMapper mapper, BgmStreamSetEntry bgmStreamSetEntry)
            : base(audioStateManager, mapper, bgmStreamSetEntry)
        {
            StreamSetId = bgmStreamSetEntry.StreamSetId;
        }

        public override BgmBaseViewModel<BgmStreamSetEntry> GetCopy()
        {
            return _mapper.Map(this, new BgmStreamSetEntryViewModel(_audioStateManager, _mapper, new BgmStreamSetEntry(StreamSetId, MusicMod)));
        }
    }
}

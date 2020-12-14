﻿using Sm5sh.Mods.Music.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sm5sh.Mods.Music.Interfaces
{
    public interface IMusicModManagerService
    {
        IEnumerable<IMusicMod> MusicMods { get; }
        IEnumerable<IMusicMod> RefreshMusicMods();
        IMusicMod AddMusicMod(MusicModInformation configBase, string modPath);
        Task<bool> UpdateGameEntry(GameTitleEntry gameTitleEntry);
    }
}

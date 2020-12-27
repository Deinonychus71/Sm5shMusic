﻿using ReactiveUI;
using Sm5shMusic.GUI.Helpers;

namespace Sm5shMusic.GUI.ViewModels
{
    public class SeriesEntryViewModel : ReactiveObject
    {
        public bool AllFlag { get; set; }
        public string SeriesId { get; }
        public string Title { get; set; }

        public SeriesEntryViewModel() { }

        public SeriesEntryViewModel(string seriesId)
        {
            SeriesId = seriesId;

            //Calculated Fields
            Title = Constants.GetSeriesDisplayName(SeriesId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is SeriesEntryViewModel p))
                return false;

            return p.SeriesId == this.SeriesId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

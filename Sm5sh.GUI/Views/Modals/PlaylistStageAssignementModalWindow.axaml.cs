﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Sm5sh.GUI.Views
{
    public class PlaylistStageAssignementModalWindow : Window
    {
        public PlaylistStageAssignementModalWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
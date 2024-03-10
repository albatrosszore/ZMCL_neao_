// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Wpf.Ui.Controls;
using ZMCL_neao.ViewModels.Pages;
using MinecraftLaunch;
using Natsurainko.FluentCore.Extension.Windows.Model;
using Natsurainko.FluentCore.Extension.Windows.Service;
using MinecraftLaunch.Classes.Interfaces;
using MinecraftLaunch.Components.Resolver;
using MinecraftLaunch.Components.Fetcher;
using MinecraftLaunch.Classes.Models.Game;

namespace ZMCL_neao.Views.Pages
{
    public partial class SettingsPage : INavigableView<SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; }
        public static string javalist_ = new(javalist_);
        public static string gamelist_ = new(gamelist_);
        public SettingsPage(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            JavaFetcher javaFetcher = new JavaFetcher();
            InitializeComponent();
            IGameResolver gameResolver = new GameResolver(".minecraft");
            gamelist.ItemsSource = gameResolver.GetGameEntitys();
            javalist.ItemsSource = javaFetcher.Fetch().ToList();

            javalist.SelectionChanged += (_, _) =>
            {
                var java = javalist.SelectedItem as JavaEntry;
                javalist_ = java.JavaPath;
            };

            gamelist.SelectionChanged += (_, _) =>
            {
                var game = gamelist.SelectedItem as GameEntry;
                gamelist_ = game.Id;
            };
        }
    }
}

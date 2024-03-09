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

            InitializeComponent();
            IGameResolver gameResolver = new GameResolver(".minecraft");
            gamelist.ItemsSource = gameResolver.GetGameEntitys();
            javalist.ItemsSource = JavaHelper.SearchJavaRuntime();
            javalist_ = javalist.Text;
            gamelist_ = gamelist.Text;
        }
    }
}

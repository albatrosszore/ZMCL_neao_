// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Components.Launcher;
using MinecraftLaunch.Components.Resolver;
using Wpf.Ui.Controls;
using ZMCL_neao.ViewModels.Pages;
using static ZMCL_neao.Views.Pages.SettingsPage;

namespace ZMCL_neao.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var account = new OfflineAuthenticator("Yang114").Authenticate();
            var resolver = new GameResolver(".minecraft");

            var config = new LaunchConfig
            {
                Account = account,
                IsEnableIndependencyCore = true,
                JvmConfig = new(javalist_)
               
            };

            Launcher launcher = new(resolver, config);
            var gameProcessWatcher = await launcher.LaunchAsync(gamelist_);

            //获取输出日志
            gameProcessWatcher.OutputLogReceived += (sender, args) => {
                Console.WriteLine(args.Text);
            };

            //检测游戏退出
            gameProcessWatcher.Exited += (sender, args) => {
                Console.WriteLine("exit");
            };
        }
    }
}

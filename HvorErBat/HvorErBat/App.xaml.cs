﻿using HvorErBat.Services;
using HvorErBat.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HvorErBat
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MapPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
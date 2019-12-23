﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using LocalizationSample.Domain;
using LocalizationSample.Presentation;
using LocalizationSample.Properties;

namespace LocalizationSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeCultures();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Person person = new Person() 
            { 
                Name = "Luke", 
                Birthday = new DateTime(2080, 2, 6)
            };

            ShellWindow mainWindow = new ShellWindow() { DataContext = person };
            mainWindow.Show();
        }

        private static void InitializeCultures()
        {
            if (!string.IsNullOrEmpty(Settings.Default.Culture))
            {
                CultureInfo.CurrentCulture = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(Settings.Default.Culture);
            }
            if (!string.IsNullOrEmpty(Settings.Default.UICulture))
            {
                CultureInfo.CurrentUICulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(Settings.Default.UICulture);
            }

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}

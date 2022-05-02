﻿using PeopleViewer.Presentation;
using PersonDataReader.Service;
using System.Windows;
using PersonDataReader.Decorators;
using PersonDataReader.SQL;

namespace PeopleViewer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			ComposeObjects();
			Application.Current.MainWindow.Title = "With Dependency Injection";
			Application.Current.MainWindow.Show();

		}

		private static void ComposeObjects()
		{
			var wrappedReader = new ServiceReader();
			var reader = new CachingReader(wrappedReader);
			var viewModel = new PeopleViewModel(reader);
			Application.Current.MainWindow = new MainWindow(viewModel);
		}
	}
}

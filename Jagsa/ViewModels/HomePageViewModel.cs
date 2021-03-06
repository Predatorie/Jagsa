﻿// HomePageViewModel.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.ViewModels
{
    using System;
    using System.Threading.Tasks;

    using Jagsa.Models;
    using Jagsa.Services;

    using Microsoft.MobCAT;

    using TinyMvvm;

    using Xamarin.Forms;

    public class HomePageViewModel : ViewModelBase
    {
        #region Private Fields

        private readonly ISteamService _steamService;

        private string _profileAvatar;

        private string _personna;

        private string _steamId;

        private string _totalPlayTime;

        //private GamesLibrary _gamesLibrary;

        //private ObservableCollection<Profile> _friendsList;

        //private Game _selectedItem;

        #endregion

        #region Construction

        /// <summary>
        /// Constructor
        /// </summary>
        public HomePageViewModel()
        {
            _steamService = ServiceContainer.Resolve<ISteamService>();

            this.SelectedGameCommand = new Microsoft.MobCAT.MVVM.Command<Game>(this.OnSelectedGame);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the selected game command.
        /// </summary>
        public Microsoft.MobCAT.MVVM.Command SelectedGameCommand { get; }

        #endregion

        #region Public Properties

        //public GamesLibrary GamesLibrary
        //{
        //    get => _gamesLibrary;
        //    set => RaiseAndUpdate(ref _gamesLibrary, value);
        //}

        public string ProfileAvatar
        {
            get => _profileAvatar;
            set => Set(ref _profileAvatar, Uri.UnescapeDataString(value));
        }

        public string Personna
        {
            get => _personna;
            set => Set(ref _personna, Uri.UnescapeDataString(value));
        }

        public string SteamId
        {
            get => _steamId;
            set => Set(ref _steamId, Uri.UnescapeDataString(value));
        }

        public string TotalPlayTime
        {
            get => _totalPlayTime;
            set => Set(ref _totalPlayTime, value);
        }

        //public ObservableCollection<Profile> Friendslist
        //{
        //    get => _friendsList;
        //    set => RaiseAndUpdate(ref _friendsList, value);
        //}

        //public Game SelectedItem
        //{
        //    get => _selectedItem;
        //    set => RaiseAndUpdate(ref _selectedItem, value);
        //}

        #endregion

        #region Public Methods

        public override async Task Initialize()
        {
            await base.Initialize();

            try
            {
                this.IsBusy = true;

                var user = NavigationParameter as User;

                this.SteamId = QueryParameters["id"];
                this.Personna = user.Persona;
                this.ProfileAvatar = user.Avatar.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.IsBusy = false;
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the selected game on tap command
        /// </summary>
        /// <param name="game">The Game that was selected</param>
        private async void OnSelectedGame(Game game)
        {
            //var args = $"game={game.Name}";

            //// navigate to the live streams page
            //await Shell.Current.GoToAsync($"//LiveStreams?{args}");

        }

        #endregion
    }
}

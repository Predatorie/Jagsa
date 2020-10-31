// LoginPageViewModel.cs
//
// Author:
//       <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.ViewModels
{
    using System.Linq;

    using Jagsa.Services;

    using Microsoft.MobCAT;
    using Microsoft.MobCAT.MVVM;
    using Microsoft.MobCAT.Services;

    using Xamarin.Forms;

    public class LoginPageViewModel : BaseNavigationViewModel
    {
        #region Private Fields

        /// <summary>
        /// Backing field for the Steam Service property
        /// </summary>
        private readonly ISteamService steamService;

        /// <summary>
        /// Backing field for the personna property
        /// </summary>
        private string personna;

        /// <summary>
        /// Backing field for the SteamId property
        /// </summary>
        private string steamId;

        /// <summary>
        /// Backing field for the profileAvatar property
        /// </summary>
        private string profileAvatar;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginPageViewModel()
        {
            this.steamService = ServiceContainer.Resolve<ISteamService>();

            // wire up our commands
            this.LoginCommand = new Microsoft.MobCAT.MVVM.Command<string>(OnLoginCommand, (i)
                => !string.IsNullOrWhiteSpace(i));
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the Login command.
        /// </summary>
        public Microsoft.MobCAT.MVVM.Command LoginCommand { get; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the SteamId property
        /// </summary>
        public string SteamId
        {
            get => this.steamId;
            set => this.RaiseAndUpdate(ref steamId, value);
        }

        /// <summary>
        /// Gets or sets the personna property
        /// </summary>
        public string Personna
        {
            get => this.personna;
            set => this.RaiseAndUpdate(ref personna, value);
        }

        /// <summary>
        /// Gets or sets the ProfileAvatar property
        /// </summary>
        public string ProfileAvatar
        {
            get => this.profileAvatar;
            set => this.RaiseAndUpdate(ref profileAvatar, value);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The login command.
        /// </summary>
        /// <param name="id">The steam id to use for login</param>
        private async void OnLoginCommand(string id)
        {
            var player = await this.steamService.FetchProfileAsync(id).ConfigureAwait(true);
            if (player.IsSuccess)
            {
                var profile = player.Value.Response.Players.First();
                var args =
                    $"personna={profile.Personaname}" +
                    $"&profileAvatar={profile.Avatarfull}" +
                    $"&steamId={profile.Steamid}";

                // Store for next session
                Preferences.SetString("personna", profile.Personaname);
                Preferences.SetString("profileAvatar", profile.Avatarfull.ToString());
                Preferences.SetString("steamId", profile.Steamid);

                await Shell.Current.GoToAsync($"//home?{args}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Steam Login", player.Error, "OK");
            }
        }

        #endregion
    }
}

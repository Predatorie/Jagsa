// LoginPageViewModel.cs
//
// Author:
//       <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.ViewModels
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Jagsa.Models;
    using Jagsa.Services;

    using Microsoft.MobCAT;

    using TinyMvvm;

    using Xamarin.Forms;

    public class LoginPageViewModel : ViewModelBase
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
        public ICommand LoginCommand { get; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the SteamId property
        /// </summary>
        public string SteamId
        {
            get => this.steamId;
            set => this.Set(ref steamId, value);
        }

        /// <summary>
        /// Gets or sets the personna property
        /// </summary>
        public string Personna
        {
            get => this.personna;
            set => this.Set(ref personna, value);
        }

        /// <summary>
        /// Gets or sets the ProfileAvatar property
        /// </summary>
        public string ProfileAvatar
        {
            get => this.profileAvatar;
            set => this.Set(ref profileAvatar, value);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The login command.
        /// </summary>
        /// <param name="id">The steam id to use for login</param>
        private async void OnLoginCommand(string id)
        {
            var cancellationToken = new CancellationTokenSource();

            try
            {
                this.IsBusy = true;

                var token = cancellationToken.Token;

                var player = await this.steamService.FetchProfileAsync(id, token).ConfigureAwait(true);
                if (player.IsSuccess)
                {
                    var profile = player.Value.Response.Players.First();
                    var args =
                        $"personna={profile.Personaname}" +
                        $"&profileAvatar={profile.Avatarfull}" +
                        $"&steamId={profile.Steamid}";

                    // Store for next session
                    Xamarin.Essentials.Preferences.Set("personna", profile.Personaname);
                    Xamarin.Essentials.Preferences.Set("profileAvatar", profile.Avatarfull.ToString());
                    Xamarin.Essentials.Preferences.Set("steamId", profile.Steamid);

                    var user = new User
                    {
                        Persona = profile.Personaname,
                        Avatar = profile.Avatarfull
                    };

                    await Navigation.NavigateToAsync($"{nameof(HomePageViewModel)}?id={profile.Steamid}", user);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Steam Login", player.Error, "OK");
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                this.IsBusy = false;
                cancellationToken?.Dispose();
            }

        }

        #endregion

        public override Task Initialize()
        {
            return base.Initialize();
        }

        //var id = Xamarin.Essentials.Preferences.Get("steamId", string.Empty);
        //if (!string.IsNullOrEmpty(id))
        //{
        //    var args =
        //        $"personna={Xamarin.Essentials.Preferences.Get("personna", string.Empty)}" +
        //        $"&profileAvatar={Xamarin.Essentials.Preferences.Get("profileAvatar", string.Empty)}" +
        //        $"&steamId={Xamarin.Essentials.Preferences.Get("steamId", string.Empty)}";

        //    await Shell.Current.GoToAsync($"//home?{args}");
        //}

    }
}

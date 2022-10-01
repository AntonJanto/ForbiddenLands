using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForbiddenLands.App.Models;
using ForbiddenLands.App.Services.Navigation;
using JsonFlatFileDataStore;
using System.Collections.ObjectModel;

namespace ForbiddenLands.App.ViewModels
{
    [INotifyPropertyChanged]
    public partial class TalentsViewModel
    {
        private IDataStore dataStore;
        private INavigationService navigationService;

        public TalentsViewModel(IDataStore dataStore, INavigationService navigationService)
        {
            this.dataStore = dataStore;
            this.navigationService = navigationService;
        }

        private ObservableCollection<Talent> talents;

        public ObservableCollection<Talent> Talents
        {
            get { return talents; }
            set { SetProperty(ref talents, value); }
        }



        [RelayCommand]
        public async Task NavigateToTalent(Talent talent)
        {
            await navigationService.NavigateToAsync("/talent", new Dictionary<string, object>() { { "TalentId", talent.Id } });
        }

        [RelayCommand]
        public async Task AddTalent()
        {
            await navigationService.NavigateToAsync("/talent");
        }

        public void OnLoad()
        {
            var talents = dataStore.GetCollection<Talent>().AsQueryable();
            Talents = new ObservableCollection<Talent>(talents);
        }
    }
}

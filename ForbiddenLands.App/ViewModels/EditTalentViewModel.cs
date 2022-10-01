using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForbiddenLands.App.Models;
using ForbiddenLands.App.Services.Navigation;
using JsonFlatFileDataStore;

namespace ForbiddenLands.App.ViewModels;

[INotifyPropertyChanged]
[QueryProperty(nameof(TalentId), nameof(TalentId))]
public partial class EditTalentViewModel
{
    private IDataStore dataStore;
    private INavigationService navigationService;

    private bool edit;

    [ObservableProperty]
    private int talentId;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private int myLevel;

    [ObservableProperty]
    private string fullDescription;

    public EditTalentViewModel(IDataStore dataStore, INavigationService navigationService)
    {
        this.dataStore = dataStore;
        this.navigationService = navigationService;
    }

    public void OnLoad()
    {
        edit = TalentId != 0;

        if (edit)
        {
            Talent talent = dataStore.GetCollection<Talent>(nameof(Talent)).AsQueryable().FirstOrDefault(t => t.Id == TalentId);
            if (talent is not null)
            {
                Title = talent.Title;
                FullDescription = talent.FullDescription;
                MyLevel = talent.MyLevel;
            }
        }
    }

    [RelayCommand]
    public async Task DeleteCancel()
    {
        if (edit)
        {
            bool del = await dataStore.GetCollection<Talent>(nameof(Talent)).DeleteOneAsync(TalentId);
        }
        await navigationService.NavigateToAsync("../");
    }

    [RelayCommand]
    public async Task Save()
    {
        bool success;
        if (edit)
        {
            success = await dataStore.GetCollection<Talent>(nameof(Talent)).ReplaceOneAsync(TalentId, new Talent() { Id = TalentId, Title = this.Title, MyLevel = this.MyLevel, FullDescription = this.FullDescription });

        }
        else
        {
            success = await dataStore.GetCollection<Talent>(nameof(Talent)).InsertOneAsync(new Talent() { Id = 1, Title = this.Title, MyLevel = this.MyLevel, FullDescription = this.FullDescription });
        }

        if (success)
        {
            await navigationService.NavigateToAsync("../");
        }
    }
}

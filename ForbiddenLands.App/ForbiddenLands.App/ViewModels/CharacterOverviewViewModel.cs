using ForbiddenLands.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForbiddenLands.App.ViewModels
{
    public class CharacterOverviewViewModel : BaseViewModel
    {
        private CharacterSheet character;

        public CharacterSheet Character
        {
            get => character;
            set => SetProperty(ref character, value);
        }

        public CharacterOverviewViewModel()
        {
        }

        public async Task OnAppearing()
        {
            Character = await DataStore.GetCharacterSheetAsync("name");
            Title = character.Name;
        }
    }
}

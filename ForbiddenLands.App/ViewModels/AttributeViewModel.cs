using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForbiddenLands.App.Models;
using ForbiddenLands.App.Options;
using JsonFlatFileDataStore;

namespace ForbiddenLands.App.ViewModels
{
    public partial class AttributeViewModel : ObservableObject
    {
        private IDataStore dataStore;

        public AttributeViewModel(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        #region view props

        private int? strength;

        public int? Strength
        {
            get { return strength; }
            set 
            {
                if (SetProperty(ref strength, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { Strength = value.Value });
                }
            }
        }

        private int? agility;

        public int? Agility
        {
            get { return agility; }
            set
            {
                if (SetProperty(ref agility, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { Agility = value.Value });
                }
            }
        }

        private int? wits;

        public int? Wits
        {
            get { return wits; }
            set
            {
                if (SetProperty(ref wits, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { Wits = value.Value });
                }
            }
        }


        private int? empathy;

        public int? Empathy
        {
            get { return empathy; }
            set
            {
                if (SetProperty(ref empathy, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { Empathy = value.Value });
                }
            }
        }

        private int? experience;

        public int? Experience
        {
            get { return experience; }
            set
            {
                if (SetProperty(ref experience, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { Experience = value.Value });
                }
            }
        }

        private int? willPoints;

        public int? WillPoints
        {
            get { return willPoints; }
            set 
            { 
                if (SetProperty(ref willPoints, value) && value is not null)
                {
                    dataStore.UpdateItem(nameof(Attributes), new { WillPoints = value.Value });
                }
            }
        }

        [RelayCommand]
        public void DecrementStrength() => Strength--;
        [RelayCommand]
        public void DecrementAgility() => Agility--;
        [RelayCommand]
        public void DecrementWits() => Wits--;
        [RelayCommand]
        public void DecrementEmpathy() => Empathy--;
        [RelayCommand]
        public void DecrementExperience() => Experience--;
        [RelayCommand]
        public void DecrementWillPoints() => WillPoints--;

        [RelayCommand]
        public void IncrementStrength() => Strength++;
        [RelayCommand]
        public void IncrementAgility() => Agility++;
        [RelayCommand]
        public void IncrementWits() => Wits++;
        [RelayCommand]
        public void IncrementEmpathy() => Empathy++;
        [RelayCommand]
        public void IncrementExperience() => Experience++;
        [RelayCommand]
        public void IncrementWillPoints() => WillPoints++;

        #endregion

        public void OnLoad()
        {
            Attributes attr = dataStore.GetItem<Attributes>(nameof(Attributes));
            Strength = attr.Strength;
            Agility = attr.Agility;
            Wits = attr.Wits;
            Empathy = attr.Empathy;
            Experience = attr.Experience;
            WillPoints = attr.WillPoints;
        }

    }
}

using ForbiddenLands.Core.Managers;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ForbiddenLands.App.ViewModels
{
    [QueryProperty(nameof(CharacterId), nameof(CharacterId))]
    public class CharacterSheetViewModel : BaseViewModel
    {
        private readonly CharacterSheetManager characterSheetManager;

        #region props
        private int characterId = 1;

        public int CharacterId
        {
            get { return characterId; }
            set { SetProperty(ref characterId, value); }
        }

        #region attributes
        private int strenghtCurrent;

        public int StrengthCurrent
        {
            get { return strenghtCurrent; }
            set { SetProperty(ref strenghtCurrent, value); }
        }

        private int strengthTotal;

        public int StrengthTotal
        {
            get { return strengthTotal; }
            set { SetProperty(ref strengthTotal, value); }
        }

        private int agilityCurrent;

        public int AgilityCurrent
        {
            get { return agilityCurrent; }
            set { SetProperty(ref agilityCurrent, value); }
        }

        private int agilityTotal;

        public int AgilityTotal
        {
            get { return agilityTotal; }
            set { SetProperty(ref agilityTotal, value); }
        }

        private int witsCurrent;

        public int WitsCurrent
        {
            get { return witsCurrent; }
            set { SetProperty(ref witsCurrent, value); }
        }
        private int witsTotal;

        public int WitsTotal
        {
            get { return witsTotal; }
            set { SetProperty(ref witsTotal, value); }
        }

        private int empathyCurrent;

        public int EmpathyCurrent
        {
            get { return empathyCurrent; }
            set { SetProperty(ref empathyCurrent, value); }
        }

        private int empathyTotal;

        public int EmpathyTotal
        {
            get { return empathyTotal; }
            set { SetProperty(ref empathyTotal, value); }
        }

        #endregion

        #region skills

        private int mightLevel;

        public int MightLevel
        {
            get { return mightLevel; }
            set { SetProperty(ref mightLevel, value); }
        }

        private int enduranceLevel;

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            set { SetProperty(ref enduranceLevel, value); }
        }
        private int meleeLevel;

        public int MeleeLevel
        {
            get { return meleeLevel; }
            set { SetProperty(ref meleeLevel, value); }
        }

        private int craftingLevel;

        public int CraftingLevel
        {
            get { return craftingLevel; }
            set { SetProperty(ref craftingLevel, value); }
        }

        private int stealthLevel;

        public int StealthLevel
        {
            get { return stealthLevel; }
            set { SetProperty(ref stealthLevel, value); }
        }

        private int sleightOfHandLevel;

        public int SleightOfHandLevel
        {
            get { return sleightOfHandLevel; }
            set { SetProperty(ref sleightOfHandLevel, value); }
        }

        private int moveLevel;

        public int MoveLevel
        {
            get { return moveLevel; }
            set { SetProperty(ref moveLevel, value); }
        }

        private int marksmanshipLevel;

        public int MarksmanshipLevel
        {
            get { return marksmanshipLevel; }
            set { SetProperty(ref marksmanshipLevel, value); }
        }

        private int scoutingLevel;

        public int ScoutingLevel
        {
            get { return scoutingLevel; }
            set { SetProperty(ref scoutingLevel, value); }
        }

        private int loreLevel;

        public int LoreLevel
        {
            get { return loreLevel; }
            set { SetProperty(ref loreLevel, value); }
        }

        private int survivalLevel;

        public int SurvivalLevel
        {
            get { return survivalLevel; }
            set { SetProperty(ref survivalLevel, value); }
        }

        private int insightLevel;

        public int InsightLevel
        {
            get { return insightLevel; }
            set { SetProperty(ref insightLevel, value); }
        }

        private int manipulationLevel;

        public int ManipulationLevel
        {
            get { return manipulationLevel; }
            set { SetProperty(ref manipulationLevel, value); }
        }

        private int performanceLevel;

        public int PerformanceLevel
        {
            get { return performanceLevel; }
            set { SetProperty(ref performanceLevel, value); }
        }

        private int healingLevel;

        public int HealingLevel
        {
            get { return healingLevel; }
            set { SetProperty(ref healingLevel, value); }
        }

        private int animalHandlingLevel;

        public int AnimalHandlingLevel
        {
            get { return animalHandlingLevel; }
            set { SetProperty(ref animalHandlingLevel, value); }
        }
        #endregion

        #endregion

        #region commands
        public ICommand SaveCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand IncrementStrengthCommand { get; private set; }
        public ICommand IncrementAgilityCommand { get; private set; }
        public ICommand IncrementWitsCommand { get; private set; }
        public ICommand IncrementEmpathyCommand { get; private set; }
        public ICommand DecrementStrengthCommand { get; private set; }
        public ICommand DecrementAgilityCommand { get; private set; }
        public ICommand DecrementWitsCommand { get; private set; }
        public ICommand DecrementEmpathyCommand { get; private set; }

        #endregion

        public CharacterSheetViewModel()
        {
            this.characterSheetManager = new CharacterSheetManager(DataStore);
            RegisterCommands();
        }

        public override async Task OnAppearing()
        {
            await LoadCharacter();
        }

        public async Task LoadCharacter()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                try
                {
                    await characterSheetManager.Load(CharacterId);
                    ReloadData();
                    Title = characterSheetManager.Character.Name;
                }
                catch (NotFoundException ex)
                {
                    Shell.Current.SendBackButtonPressed();
                }
                finally
                {
                    IsBusy = false;

                }
            }
        }

        private void RegisterCommands()
        {
            RefreshCommand = new Command(async () => await LoadCharacter());
            SaveCommand = new Command(async () => await characterSheetManager.Save());

            IncrementStrengthCommand = new Command(() =>
            {
                characterSheetManager.IncrementStrength();
                ReloadData();
            }, () => StrengthCurrent < StrengthTotal);

            DecrementStrengthCommand = new Command(() =>
            {
                characterSheetManager.DecrementStrength();
                ReloadData();
            }, () => StrengthCurrent > 0);

            IncrementAgilityCommand = new Command(() =>
            {
                characterSheetManager.IncrementAgility();
                ReloadData();
            }, () => AgilityCurrent < AgilityTotal);

            DecrementAgilityCommand = new Command(() =>
            {
                characterSheetManager.DecrementAgility();
                ReloadData();
            }, () => AgilityCurrent > 0);

            IncrementWitsCommand = new Command(() =>
            {
                characterSheetManager.IncrementWits();
                ReloadData();
            }, () => WitsCurrent < WitsTotal);

            DecrementWitsCommand = new Command(() =>
            {
                characterSheetManager.DecrementWits();
                ReloadData();
            }, () => WitsCurrent > 0);

            IncrementEmpathyCommand = new Command(() =>
            {
                characterSheetManager.IncrementEmpathy();
                ReloadData();
            }, () => EmpathyCurrent < EmpathyTotal);

            DecrementEmpathyCommand = new Command(() =>
            {
                characterSheetManager.DecrementEmpathy();
                ReloadData();
            }, () => EmpathyCurrent > 0);

            this.PropertyChanged += (_, __) => RefreshCanExecute();
        }

        private void ReloadData()
        {
            StrengthCurrent = characterSheetManager.Character.Strength.CurrentDie;
            StrengthTotal = characterSheetManager.Character.Strength.TotalDie;

            AgilityCurrent = characterSheetManager.Character.Agility.CurrentDie;
            AgilityTotal = characterSheetManager.Character.Agility.TotalDie;

            WitsCurrent = characterSheetManager.Character.Wits.CurrentDie;
            WitsTotal = characterSheetManager.Character.Wits.TotalDie;

            EmpathyCurrent = characterSheetManager.Character.Empathy.CurrentDie;
            EmpathyTotal = characterSheetManager.Character.Empathy.TotalDie;

            MightLevel = characterSheetManager.Character.Might.Level;
            EnduranceLevel = characterSheetManager.Character.Endurance.Level;
            MeleeLevel = characterSheetManager.Character.Melee.Level;
            CraftingLevel = characterSheetManager.Character.Crafting.Level;
            StealthLevel = characterSheetManager.Character.Stealth.Level;
            SleightOfHandLevel = characterSheetManager.Character.SleightOfHand.Level;
            MoveLevel = characterSheetManager.Character.Move.Level;
            MarksmanshipLevel = characterSheetManager.Character.Marksmanship.Level; ;
            ScoutingLevel = characterSheetManager.Character.Scouting.Level;
            LoreLevel = characterSheetManager.Character.Lore.Level;
            SurvivalLevel = characterSheetManager.Character.Survival.Level;
            InsightLevel = characterSheetManager.Character.Insight.Level;
            ManipulationLevel = characterSheetManager.Character.Manipulation.Level;
            PerformanceLevel = characterSheetManager.Character.Performance.Level;
            HealingLevel = characterSheetManager.Character.Healing.Level;
            AnimalHandlingLevel = characterSheetManager.Character.AnimalHandling.Level;
        }

        private void RefreshCanExecute()
        {
            (IncrementStrengthCommand as Command).ChangeCanExecute();
            (DecrementStrengthCommand as Command).ChangeCanExecute();
            (IncrementAgilityCommand as Command).ChangeCanExecute();
            (DecrementAgilityCommand as Command).ChangeCanExecute();
            (IncrementWitsCommand as Command).ChangeCanExecute();
            (DecrementWitsCommand as Command).ChangeCanExecute();
            (IncrementEmpathyCommand as Command).ChangeCanExecute();
            (DecrementEmpathyCommand as Command).ChangeCanExecute();
        }
    }
}

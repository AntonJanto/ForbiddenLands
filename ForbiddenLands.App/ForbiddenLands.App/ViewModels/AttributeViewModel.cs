using ForbiddenLands.Core.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForbiddenLands.App.ViewModels
{
    public class AttributeViewModel : BaseViewModel
    {
        Attribute attribute;

        private int current;

        public int Current
        {
            get { return current; }
            set
            {
                SetProperty(ref current, value);
                attribute.CurrentDie = value;
            }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set
            {
                SetProperty(ref total, value);
                attribute.TotalDie = value;
            }
        }

        public Command IncrementCurrent;

        public AttributeViewModel(Attribute attr)
        {
            this.attribute = attr;
            IncrementCurrent = new Command(OnIncrementCurrent);
        }

        private void OnIncrementCurrent()
        {
            if (Current < Total)
            {
                Current++;
            }
        }

        public override async Task OnAppearing()
        {
            await LoadAttribute();
        }

        private async Task LoadAttribute()
        {

        }
    }
}
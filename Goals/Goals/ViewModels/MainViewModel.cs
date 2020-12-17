using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goals.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public void ShortGoals()
        {
            ActivateItem(new ShortGoalsViewModel());
        }
        public void LongGoals()
        {
            ActivateItem(new LongGoalsViewModel());
        }
    }
}

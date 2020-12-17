using Caliburn.Micro;
using Goals.Models;
using Goals.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Goals.ViewModels
{
    public class LongGoalsViewModel : Screen
    {
        private readonly string GoalsPath = $"{Environment.CurrentDirectory}\\LongGoals.json";
        private FileIOService _fileIOService;

        private BindingList<GoalsModel> _longGoals;
        public BindingList<GoalsModel> longGoals
        {
            get { return _longGoals; }
            set
            {
                _longGoals = value;
                NotifyOfPropertyChange(() => longGoals);
            }
        }

        public LongGoalsViewModel()
        {
            _fileIOService = new FileIOService(GoalsPath);
            try
            {
                longGoals = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (longGoals == null)
            {
                longGoals = new BindingList<GoalsModel>();
            }

            longGoals.ListChanged += Goals_ListChanged;
        }

        private void Goals_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(longGoals);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

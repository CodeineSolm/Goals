using Caliburn.Micro;
using Goals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goals.Services;
using System.ComponentModel;
using System.Windows;

namespace Goals.ViewModels
{
    public class ShortGoalsViewModel : Screen
    {
        private readonly string GoalsPath = $"{Environment.CurrentDirectory}\\ShortGoals.json";
        private FileIOService _fileIOService;

        private BindingList<GoalsModel> _shortGoals;
        public BindingList<GoalsModel> shortGoals
        {
            get { return _shortGoals; }
            set
            {
                _shortGoals = value;
                NotifyOfPropertyChange(() => shortGoals);
            }
        }

        public ShortGoalsViewModel()
        {
            _fileIOService = new FileIOService(GoalsPath);
            try
            {
                shortGoals = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (shortGoals == null)
            {
                shortGoals = new BindingList<GoalsModel>();
            }

            shortGoals.ListChanged += Goals_ListChanged;
        }

        private void Goals_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(shortGoals);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

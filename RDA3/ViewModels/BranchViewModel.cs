using RDA3.Models;
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.ViewModels
{
    public class BranchViewModel : ObservableObject
    {
        private Branch _selectedBranch;
        public Branch SelectedBranch
        {
            get { return _selectedBranch; }
            set { OnPropertyChanged(ref _selectedBranch, value); }
        }

        public ObservableCollection<Branch> Branches { get; private set; }
        public List<Branch> branchList { get; set; }

        public BranchViewModel()
        {
            branchList = GetBranches();
            Branches = new ObservableCollection<Branch>(branchList);

        }


        public List<Branch> GetBranches()
        {
            var branchList = new PSWally().GetBranches();
            return branchList;
        }
    }
}

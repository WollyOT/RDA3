/*
* FILE          :   BranchViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the Branch object
*/
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
        // property for the handling of the currently selected Branch object
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

            //stored in ObservableCollection for easy display in WPF
            Branches = new ObservableCollection<Branch>(branchList); 

        }

        /*
        * NAME      :   GetBranches
        * PURPOSE	:   Calls the GetBranches function located in
        *               the PSWally class to populate a list with
        *               contents of SQL server Branch table.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var branchList  : list of branches
        */
        public List<Branch> GetBranches()
        {
            var branchList = new PSWally().GetBranches();
            return branchList;
        }
    }
}

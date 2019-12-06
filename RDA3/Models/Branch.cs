using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class Branch : ObservableObject
    {
        private int branchID;
        public int BranchID
        {
            get { return branchID; }
            set { OnPropertyChanged(ref branchID, value); }
        }

        private string branchName;
        public string BranchName
        {
            get { return branchName; }
            set { OnPropertyChanged(ref branchName, value); }
        }
    }
}

/*
* FILE          :   SalesRecordViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the SalesRecord object
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
    public class SalesRecordViewModel : ObservableObject
    {
        private SalesRecord _selectedSalesRecord;
        public SalesRecord SelectedSalesRecord
        {
            get { return _selectedSalesRecord; }
            set { OnPropertyChanged(ref _selectedSalesRecord, value); }
        }

        public ObservableCollection<SalesRecord> SalesRecords { get; private set; }
        public List<SalesRecord> salesRecordsList { get; set; }

        /*
        * NAME      :   SalesRecordViewModel
        * PURPOSE	:   Contrsuctor for the Sales Record view model class.
        *               Handles the the instantiation of necessary classes 
        *               for the Sales Record view operations.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public SalesRecordViewModel()
        {
        }

        /*
        * NAME      :   GetSalesRecords
        * PURPOSE	:   Calls the GetSalesRecords function located in
        *               the PSWally class to populate a list with
        *               contents of SQL server tables in order to create
        *               sales records.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List salesRecords   : list of Sales Records
        */
        public List<SalesRecord> GetSalesRecords()
        {
            var salesRecords = new PSWally().GetSalesRecords();
            return salesRecords;
        }
    }
}

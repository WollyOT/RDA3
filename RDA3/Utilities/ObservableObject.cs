/*
* FILE          :   ObservableObject.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Model for the ObservableObject object
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Utilities
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /*
        * NAME      :   OnPropertyChanged
        * PURPOSE	:   Handles the getting and setting of properties
        * INPUTS    :   
        *   string property : name of the property to be changed
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        // referenced from https://www.youtube.com/watch?v=CQYvjlDoJ08&t=21s
        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /*
        * NAME      :   OnPropertyChanged
        * PURPOSE	:   Handles the getting and setting of properties
        * INPUTS    :   
        *   ref T backing        : value of the property to be changed
        *   T value              : new property value
        *   string propertyName  : property name to be updated
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   bool False  : if property unchanged
        *   bool True   : if property changed
        */
        // referenced from https://www.youtube.com/watch?v=CQYvjlDoJ08&t=21s
        protected virtual bool OnPropertyChanged<T>(ref T backing, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backing, value))
                return false;

            backing = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

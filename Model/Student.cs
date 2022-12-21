using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : IDomainObject, INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim();
                OnPropertyChanged();
            }
        }

        private string _speciality = string.Empty;
        public string Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value.Trim();
                OnPropertyChanged();
            }
        }

        private string _group = string.Empty;
        public string Group
        {
            get => _group;
            set
            {
                _group = value.Trim();
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

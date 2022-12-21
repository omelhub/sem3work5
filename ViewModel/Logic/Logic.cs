using GalaSoft.MvvmLight.Command;
using Microsoft.SqlServer.Server;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel.Logic
{
    public class Logic : INotifyPropertyChanged
    {
        IRepository<Student> repository { set; get; }
        public Logic(IRepository<Student> repository1)
        {
            repository = repository1;
            Students = new ObservableCollection<Student>(GetAll());
            NewStudent = new Student();

            //GraphBtn = new RelayCommand();
            StudentCreateBtn = new RelayCommand(AddStudent);
            StudentDeleteBtn = new RelayCommand(DeleteStudent);
        }

        public RelayCommand GraphBtn { get; set; }
        public RelayCommand StudentCreateBtn { get; set; }
        public RelayCommand StudentDeleteBtn { get; set; }

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public Student ListViewSelected { get; set; }

        private Student _newStudent;
        public Student NewStudent
        {
            get => _newStudent;
            set
            {
                _newStudent = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Добавить нового студента.
        /// </summary>
        public void AddStudent()
        {
            if ((!string.IsNullOrEmpty(NewStudent.Name) && !string.IsNullOrEmpty(NewStudent.Speciality) && !string.IsNullOrEmpty(NewStudent.Group)))
            {
                repository.Create(NewStudent);
                repository.Save();
                Students.Add(NewStudent);
                NewStudent = new Student();
            }
        }

        /// <summary>
        /// Удалить выбранного студента.
        /// </summary>
        public void DeleteStudent()               
        {
            if (ListViewSelected != null)
            {
                repository.Delete(ListViewSelected.Id);
                repository.Save();
                Students.Remove(ListViewSelected);
            }
        }

        /// <summary>
        /// Вывести весь список студентов.
        /// </summary>
        public List<Student> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Dictionary<string, int> DistributionOfSpecialties()
        {
            Dictionary<string, int> specialtiesDistribution = new Dictionary<string, int>();

            foreach (Student student in (List<Student>)repository.GetAll())
            {
                if (specialtiesDistribution.ContainsKey(student.Speciality))
                    specialtiesDistribution[student.Speciality] += 1;

                else
                    specialtiesDistribution[student.Speciality] = 1;
            }
            return specialtiesDistribution;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

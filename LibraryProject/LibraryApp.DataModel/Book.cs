using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LibraryApp.DataModel.Annotations;

namespace LibraryApp.DataModel
{
    public class Book : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string UniqueCode { get; set; }
        public string Author { get; set; }

        private string editure;

        public string Editure
        {
            get => editure;
            set
            {
                if (editure == value) return;
                editure = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
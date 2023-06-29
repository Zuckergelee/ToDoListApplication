using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDoListApp.DataModel
{
    internal class TasksModel: INotifyPropertyChanged
    {
        public DateTime DateOfCreate { get; set; } = DateTime.Now;

		private bool _isDone;
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void ChangeProperty( string propertyName = " ")
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDone
        {
			get { return _isDone; }
			set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                ChangeProperty("IsDone");
            }
		}

        public string Text
        {
			get { return _text; }
			set
            {
                if (_text == value)
                    return;
                _text = value;
                ChangeProperty("Text");
            }
		}


    }
}

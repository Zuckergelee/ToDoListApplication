using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using ToDoListApp.DataModel;

namespace ToDoListApp.Services
{
    internal class FileManager
    {
        private readonly string Path;
        public FileManager(string path)
        {
            Path = path;
        }

        public BindingList<TasksModel> LoadData()
        {
            bool fileExists = File.Exists(Path);
            if (!fileExists)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<TasksModel>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TasksModel>>(fileText);
            }
        }

        public void SaveData(object _tasksDataList)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(_tasksDataList);
                writer.Write(output);
            }
        }
    }
}

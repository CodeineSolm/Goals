using Goals.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goals.Services
{
    class FileIOService
    {
        private readonly string Path;

        public FileIOService(string path)
        {
            Path = path;
        }

        public BindingList<GoalsModel> LoadData()
        {
            var fileExists = File.Exists(Path);
            if (!fileExists)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<GoalsModel>();
            }

            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<GoalsModel>>(fileText);
            }
        }

        public void SaveData(object saveData)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(saveData);
                writer.Write(output);
            }
        }
    }
}

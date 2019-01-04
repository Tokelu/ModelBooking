using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace ModelBooking.Utilities
{
    public static class Persistence
    {

        // definition af sti til Json filerne som jeg persisterer data i - Filer lægges i 
        private static readonly string _modelPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GUI_ModelsFile.json";
        private static readonly string _assignmentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GUI_AssignmentsFile.json";


        public static void SaveModels<T>(this ObservableCollection<T> data)
        {
            data.SaveFileCommand(_modelPath);
        }

        public static void SaveAssignments<T>(this ObservableCollection<T> data)
        {
            data.SaveFileCommand(_assignmentPath);
        }

        public static void LoadModels<T>(this ObservableCollection<T> data)
        {
            data.LoadFileCommand(_modelPath);
        }

        public static void LoadAssignments<T>(this ObservableCollection<T> data)
        {
            data.LoadFileCommand(_assignmentPath);
        }


        private static void LoadFileCommand<T>(this ObservableCollection<T> data, string path)
        {
            if(!File.Exists(path))
                return;
            var jsonIn = File.ReadAllText(path);
            var output = JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonIn);
            data.Clear();
            foreach (var item in output)
            {
                data.Add(item);
            }
        }

        private static void SaveFileCommand<T>(this ObservableCollection<T> data, string path)
        {
            string output = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings(){PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize,TypeNameHandling = TypeNameHandling.All});
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(output);
                streamWriter.Close();
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Data.LocalFileData
{
    abstract class BaseProvider<T> : IRepository<T> where T : class
    {
        private List<T> _data;
        private void Serialize()
        {
            using (var fileStream = new FileStream(FilePath, FileMode.Open)) {
                var foo = new BinaryFormatter();
                foo.Serialize(fileStream, _data);
            }
        }
        private void Deserialize()
        {
            using (var fileStream = new FileStream(FilePath, FileMode.Open)) {
                if (fileStream.Length > 0) {
                    var bFormatter = new BinaryFormatter();
                    _data = (List<T>)bFormatter.Deserialize(fileStream);
                }
                else {
                    _data = new List<T>();
                }
            }
        }
        public BaseProvider(string dirPath, string fileName)
        {
            if (!Directory.Exists(dirPath)) {
                Directory.CreateDirectory(dirPath);
            }
            FilePath = $"{dirPath}\\{fileName}";
            if (!File.Exists(FilePath)) {

                var stream = File.Create(FilePath);
                stream.Close();
            }
            _data = Select().ToList();
            if (_data.Count == 0) {
                Seed();
            }
        }
        protected string FilePath { get; }
        protected virtual void Seed()
        {
        }
        protected abstract bool Compare(T first, T second);
        public void Create(T model)
        {
            Deserialize();
            _data.Add(model);
            Serialize();
        }
        public void Remove(T model)
        {
            Deserialize();
            var dataObj = _data.FirstOrDefault(i => Compare(i, model));
            if (dataObj != null) {
                _data.Remove(dataObj);
                Serialize();
            }
        }
        public IEnumerable<T> Select()
        {
            Deserialize();
            return _data;
        }
        public void Update(T model)
        {
            Deserialize();
            var dataObj = _data.FirstOrDefault(i => Compare(i, model));
            if(dataObj != null) {
                Remove(dataObj);
                _data.Add(model);
                Serialize();
            }
        }
    }
}

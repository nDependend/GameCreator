using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameCreator.Models
{
    [Serializable]
    public class Game : PropertyChangedBase
    {
        public string Name { get; set; }

        public Game(string Name)
        {
            this.Name = Name;
        }

        public Game Clone()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as Game;
        }

        #region "Properties"
        private ObservableCollection<GC_Class> _Classes = new ObservableCollection<GC_Class>();
        public ObservableCollection<GC_Class> Classes
        {
            get { return _Classes; }
            set { SetProperty(value, ref _Classes); }
        }
        private ObservableCollection<GC_Object> _Objects = new ObservableCollection<GC_Object>();
        public ObservableCollection<GC_Object> Objects
        {
            get { return _Objects; }
            set { SetProperty(value, ref _Objects); }
        }
        private ObservableCollection<GC_Image> _Images = new ObservableCollection<GC_Image>();
        public ObservableCollection<GC_Image> Images
        {
            get { return _Images; }
            set { SetProperty(value, ref _Images); }
        }
        private ObservableCollection<GC_Level> _Levels = new ObservableCollection<GC_Level>();
        public ObservableCollection<GC_Level> Levels
        {
            get { return _Levels; }
            set { SetProperty(value, ref _Levels); }
        }
        #endregion
    }
}

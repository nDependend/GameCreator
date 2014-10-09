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
using System.Windows;

namespace GameCreator
{
    [Serializable]
    public class Game : PropertyChangedBase
    {
        #region "Properties"
        private string _Name;
        public string Name 
        { 
            get { return _Name; }
            set { SetProperty(value, ref _Name); } 
        }

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

        public Game(string Name)
        {
            this.Name = Name;
        }

        public Game Clone()
        {
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream) as Game;
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteLine(this.Name);
                string dir = filename.Substring(0, filename.Length - 4);
                Directory.CreateDirectory(dir);
                string subdir = dir + "\\Classes\\";
                Directory.CreateDirectory(subdir);
                foreach (GC_Class c in Classes)
                    c.Save(subdir+c.Name+".gcc");
                subdir = dir + "\\Images\\";
                Directory.CreateDirectory(subdir);
                foreach (GC_Image i in Images)
                    i.Save(subdir+i.Name+".gci");
                subdir = dir + "\\Objects\\";
                Directory.CreateDirectory(subdir);
                foreach (GC_Object o in Objects)
                    o.Save(subdir+o.Name+".gco");
                subdir = dir + "\\Levels\\";
                Directory.CreateDirectory(subdir);
                foreach (GC_Level l in Levels)
                    l.Save(subdir+l.Name+".gcl");
                writer.Flush();
            } 
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                this.Name = reader.ReadLine();
                string dir = filename.Substring(0, filename.Length - 4);
                if (!Directory.Exists(dir))
                {
                    reader.Close();
                    return;
                }

                string subdir = dir + "\\Classes\\";
                string[] items = Directory.GetFiles(subdir);
                Classes.Clear();
                GC_Class currentClass;
                foreach(string c in items)
                {
                    currentClass = new GC_Class(c.Substring(0,c.Length-4), this);
                    currentClass.Load(c);
                    Classes.Add(currentClass);
                }

                subdir = dir + "\\Images\\";
                items = Directory.GetFiles(subdir);
                Images.Clear();
                GC_Image currentImage;
                foreach(string i in items)
                {
                    currentImage = new GC_Image(i.Substring(0, i.Length - 4), this);
                    currentImage.Load(i);
                    Images.Add(currentImage);
                }

                subdir = dir + "\\Objects\\";
                items = Directory.GetFiles(subdir);
                Objects.Clear();
                GC_Object currentObject;
                foreach (string o in items)
                {
                    currentObject = new GC_Object(o.Substring(0, o.Length - 4), this);
                    currentObject.Load(o);
                    Objects.Add(currentObject);
                }

                subdir = dir + "\\Levels\\";
                items = Directory.GetFiles(subdir);
                Levels.Clear();
                GC_Level currentLevel;
                foreach (string l in items)
                {
                    currentLevel = new GC_Level(l.Substring(0, l.Length - 4), this);
                    currentLevel.Load(l);
                    Levels.Add(currentLevel);
                }

                reader.Close();
            }
            catch
            {
                reader.Close();
                MessageBox.Show(Application.Current.FindResource("FileCorrupt").ToString());
            }
        }

    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Windows;

namespace GameCreator
{
    [Serializable]
    public class GC_Object : PropertyChangedBase, IGC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }
        private GC_Class _Class;
        public GC_Class Class
        {
            get { return _Class; }
            set { SetProperty(value, ref _Class); }
        }
        private GC_Image _Image;
        public GC_Image Image
        {
            get { return _Image; }
            set { SetProperty(value, ref _Image); }
        }

        private Game _Game;
        #endregion
        public GC_Object(string Name, Game game)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            _Game = game;
            _Name = Name;
        }

        public GC_Object Clone()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as GC_Object;
        }
    
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteLine(this.Name);
                if (this.Class != null)
                    writer.WriteLine(this.Class.Name);
                else
                    writer.WriteLine("PropertyNotSet");
                if (this.Image != null)
                    writer.WriteLine(this.Image.Name);
                else
                    writer.WriteLine("PropertyNotSet");
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
                string s = reader.ReadLine();
                //Class
                if(s != "PropertyNotSet")
                {
                    this.Class = _Game.Classes.Where(x => x.Name == s).First();
                }
                s = reader.ReadLine();
                //Image
                if(s != "PropertyNotSet")
                {
                    this.Image = _Game.Images.Where(x => x.Name == s).First();
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
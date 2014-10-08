using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;

namespace GameCreator
{
    [Serializable]
    public class GC_Level : PropertyChangedBase, IGC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }

        private Game _Game;
        public Game Game
        {
            get
            {
                return _Game;
            }
        }
        #endregion

        public GC_Level(string Name, Game game)
        {
            _Game = game;
            this.Name = Name;
        }

        public GC_Level Clone()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as GC_Level;
        }
    
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteLine(this.Name);
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
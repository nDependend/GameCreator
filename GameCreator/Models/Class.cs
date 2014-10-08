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
    public class GC_Class : PropertyChangedBase, IGC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }

        private Game _Game;
        #endregion

        public GC_Class(string Name, Game game)
        {
            //Was rechanged to this.Name due to JBou's ordinance.
            if (game == null)
                throw new ArgumentNullException("game");
            _Game = game;
            this.Name = Name;
        }

        public GC_Class Clone()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream,this);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as GC_Class;
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

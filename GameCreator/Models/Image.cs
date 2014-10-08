using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace GameCreator
{
    [Serializable]
    public class GC_Image : PropertyChangedBase, IDisposable, IGC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }

        private Bitmap _Image;
        public Bitmap Image
        {
            get { return _Image; }
            set { SetProperty(value, ref _Image);  }
        }

        private Game _Game;
        #endregion

        public GC_Image(string Name, Game game)
        {
            _Game = game;
            this.Name = Name;
        }

        public GC_Image Clone()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as GC_Image;
        }

        public void Dispose()
        {
            if(_Image != null)
                _Image.Dispose();
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteLine(this.Name);
                if (Image == null)
                    writer.WriteLine("PropertyNotSet");
                else
                    Image.Save(writer.BaseStream, ImageFormat.Bmp);
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
                long streampos = reader.BaseStream.Position;
                string s = reader.ReadLine();
                if (s != "PropertyNotSet")
                {
                    reader.BaseStream.Seek(streampos, SeekOrigin.Begin);
                    this.Image = new Bitmap(reader.BaseStream);
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
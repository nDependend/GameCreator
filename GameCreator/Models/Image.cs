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
using System.Windows.Media.Imaging;

namespace GameCreator
{
    [Serializable]
    public class GC_Image : PropertyChangedBase, IGC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }

        private BitmapImage _Image;
        public BitmapImage Image
        {
            get { return _Image; }
            set { SetProperty(value, ref _Image);  }
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

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteLine(this.Name);
                if (Image == null)
                    writer.WriteLine(MainViewModel.PROPERTYNOTSET);
                else
                {
                    string dir = filename.Substring(0,filename.Length - ".gci".Length - this.Name.Length - "Images\\".Length) + "\\Assets\\";
                    //dir now is the directory of the assets location
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string newpath = dir + this.Name + Image.UriSource.AbsolutePath.Substring(Image.UriSource.AbsolutePath.Length - 4);
                    if (File.Exists(newpath) && newpath != Image.UriSource.AbsolutePath)
                        File.Delete(newpath);
                    File.Copy(Image.UriSource.AbsolutePath, newpath);
                    Image.UriSource = new Uri(newpath);
                    writer.WriteLine(Image.UriSource.AbsolutePath);
                }
                    
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
                if (s != MainViewModel.PROPERTYNOTSET)
                {
                    this.Image = new BitmapImage(new Uri(s));
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
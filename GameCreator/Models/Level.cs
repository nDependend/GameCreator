using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;
using System.Linq;

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

        private GC_Image _BackgroundImage;
        public GC_Image BackgroundImage
        {
            get
            {
                return _BackgroundImage;
            }
            set
            {
                SetProperty(value, ref _BackgroundImage);
            }
        }

        private string _BackgroundImageLayout;
        public string BackgroundImageLayout
        {
            get
            {
                return _BackgroundImageLayout;
            }
            set
            {
                SetProperty(value, ref _BackgroundImageLayout);
            }
        }

        private int _Width;
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                SetProperty(value, ref _Width);
            }
        }

        private int _Height;
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                SetProperty(value, ref _Height);
            }
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
            this.Width = 500;
            this.Height = 500;
            this.BackgroundImageLayout = "None";
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
                writer.WriteLine(this.Width.ToString());
                writer.WriteLine(this.Height.ToString());
                if (this.BackgroundImage != null)
                    writer.WriteLine(this.BackgroundImage.Name);
                else
                    writer.WriteLine(MainViewModel.PROPERTYNOTSET);
                writer.WriteLine(this.BackgroundImageLayout);
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
                this.Width = Convert.ToInt32(reader.ReadLine());
                this.Height = Convert.ToInt32(reader.ReadLine());
                string s = reader.ReadLine();
                if (s != MainViewModel.PROPERTYNOTSET)
                {
                    this.BackgroundImage = _Game.Images.Where(x => x.Name == s).First();
                }
                this.BackgroundImageLayout = reader.ReadLine();
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
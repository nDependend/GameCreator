using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace GameCreator
{
    [Serializable]
    public class GC_Image : PropertyChangedBase, IDisposable, GC_Item
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
        #endregion

        public GC_Image(string Name)
        {
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
            _Image.Dispose();
        }
    }
}
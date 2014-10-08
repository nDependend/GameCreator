using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GameCreator
{
    [Serializable]
    public class GC_Object : PropertyChangedBase, GC_Item
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

        #endregion
        public GC_Object(string Name)
        {
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
    }
}
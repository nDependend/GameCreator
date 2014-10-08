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
    public class GC_Class : PropertyChangedBase, GC_Item
    {
        #region "Properties"
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(value, ref _Name); }
        }
        #endregion

        public GC_Class(string Name)
        {
            //Was rechanged to this.Name due to JBou's ordinance.
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

    }
}

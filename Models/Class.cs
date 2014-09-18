using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace GameCreator
{
    public class GC_Class : PropertyChangedBase
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
            this.Name = Name;
        }

    }
}

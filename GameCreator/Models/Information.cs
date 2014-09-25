using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.Models
{
    class GC_Information : PropertyChangedBase
    {
        #region Properties
        private string _InformationType;
        public string InformationType
        {
            get { return _InformationType; }
            set { SetProperty(value, ref _InformationType); }
        }
        #endregion
    }
}

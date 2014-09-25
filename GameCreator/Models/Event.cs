using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GameCreator.Models
{
    class GC_Event : PropertyChangedBase
    {
        #region
        private ObservableCollection<GC_Method> _Methods;
        public ObservableCollection<GC_Method> Methods
        {
            get { return _Methods; }
            set { SetProperty(value, ref _Methods); }
        }
        #endregion
    }
}

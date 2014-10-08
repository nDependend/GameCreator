using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GameCreator.Models
{
    class GC_Method : PropertyChangedBase
    {
        #region Properties
        private ObservableCollection<GC_Information> _InputInformations;
        public ObservableCollection<GC_Information> InputInformations
        {
            get { return _InputInformations; }
            set { SetProperty(value, ref _InputInformations); }
        }

        private ObservableCollection<GC_Information> _OutputInformations;
        public ObservableCollection<GC_Information> OutputInformations
        {
            get { return _OutputInformations; }
            set { SetProperty(value, ref _OutputInformations); }
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace GameCreator
{
    public class MainViewModel : PropertyChangedBase
    {

        #region "Singleton & Constructor"
        private static MainViewModel _Instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MainViewModel();
                return _Instance;
            }
        }

        public MainViewModel()
        {
        }

        #endregion

        #region "Properties"
        private Models.Game _CurrentGame;
        public Models.Game CurrentGame
        {
            get
            {
                return _CurrentGame;
            }
            set 
            {
                SetProperty(value, ref _CurrentGame);
            }
        }

        #endregion
    }
}
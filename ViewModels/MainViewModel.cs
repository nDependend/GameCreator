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
        private ObservableCollection<GC_Class> _Classes = new ObservableCollection<GC_Class>();
        public ObservableCollection<GC_Class> Classes
        {
            get { return _Classes; }
            set { SetProperty(value, ref _Classes); }
        }
        private ObservableCollection<GC_Object> _Objects = new ObservableCollection<GC_Object>();
        public ObservableCollection<GC_Object> Objects
        {
            get { return _Objects; }
            set { SetProperty(value, ref _Objects); }
        }
        private ObservableCollection<GC_Image> _Images = new ObservableCollection<GC_Image>();
        public ObservableCollection<GC_Image> Images
        {
            get { return _Images; }
            set { SetProperty(value, ref _Images); }
        }
        private ObservableCollection<GC_Level> _Levels = new ObservableCollection<GC_Level>();
        public ObservableCollection<GC_Level> Levels
        {
            get { return _Levels; }
            set { SetProperty(value, ref _Levels); }
        }

        #endregion
    }
}
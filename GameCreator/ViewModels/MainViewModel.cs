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
        #region Constant values
        public const string CLASS_DATA_FORMAT = "Ndep_GC_Class";
        public const string IMAGE_DATA_FORMAT = "Ndep_GC_Image";
        public const string OBJECT_DATA_FORMAT = "Ndep_GC_Object";
        public const string LEVEL_DATA_FORMAT = "Ndep_GC_Level";
        public const string PROPERTYNOTSET = "PropertyNotSet";
        #endregion

        #region Singleton & Constructor
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

        #region Properties
        private Game _CurrentGame;
        public Game CurrentGame
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

        private string _CurrentGamePath;
        public string CurrentGamePath
        {
            get
            {
                return _CurrentGamePath;
            }
            set
            {
                SetProperty(value, ref _CurrentGamePath);
            }
        }
        #region Tabs
        ObservableCollection<ViewModels.PaneViewModel> openedItems = new ObservableCollection<ViewModels.PaneViewModel>();
        public ObservableCollection<ViewModels.PaneViewModel> OpenedItems
        {
            get
            {
                return openedItems;
            }
            set
            {
                SetProperty(value, ref openedItems);
            }
        }

        ViewModels.PaneViewModel activeItem = new ViewModels.PaneViewModel();
        public ViewModels.PaneViewModel ActiveItem
        {
            get
            {
                return activeItem;
            }
            set
            {
                SetProperty(value, ref activeItem);
            }
        }
        #endregion

        #endregion
    }
}
using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using MahApps.Metro.Controls.Dialogs;

namespace GameCreator
{
    public partial class MainWindow
    {
        private RelayCommand _AddItem;
        public RelayCommand AddItem
        {
            get
            {
                if (_AddItem == null)
                    _AddItem = new RelayCommand(async (object parameter) =>
                    {
                        string name = await this.ShowInputAsync(Application.Current.FindResource("New" + parameter.ToString()).ToString(), Application.Current.FindResource("Name".ToString()) + ":");
                        switch (parameter.ToString())
                        {
                            case "Class":
                                MainViewModel.Instance.CurrentGame.Classes.Add(new GC_Class(name));
                                break;
                            case "Image":
                                MainViewModel.Instance.CurrentGame.Images.Add(new GC_Image(name));
                                break;
                            case "Object":
                                MainViewModel.Instance.CurrentGame.Objects.Add(new GC_Object(name));
                                break;
                            case "Level":
                                MainViewModel.Instance.CurrentGame.Levels.Add(new GC_Level(name));
                                break;
                        }
                    });
                return _AddItem;
            }
        }

        private RelayCommand _LoadGame;
        public RelayCommand LoadGame
        {
            get
            {
                if (_LoadGame == null)
                {
                    _LoadGame = new RelayCommand(async (object parameter) =>
                    {
                        switch (parameter.ToString())
                        {
                            case "New":
                                string name = await this.ShowInputAsync(Application.Current.FindResource("NewGame").ToString(), Application.Current.FindResource("Name".ToString()) + ":");
                                MainViewModel.Instance.CurrentGame = new Models.Game(name);
                                break;
                        }
                    });
                }
                return _LoadGame;
            }
        }

        private RelayCommand _CloseApplication;
        public RelayCommand CloseApplication
        {
            get
            {
                if (_CloseApplication == null)
                {
                    _CloseApplication = new RelayCommand((object parameter) =>
                    {
                        this.Close();
                    });
                }
                return _CloseApplication;
            }
        }

        private RelayCommand _DeleteAll;
        public RelayCommand DeleteAll
        {
            get
            {
                if (_DeleteAll == null)
                {
                    _DeleteAll = new RelayCommand((object parameter) =>
                    {
                        switch (parameter.ToString())
                        {
                            case "Class":
                                MainViewModel.Instance.CurrentGame.Classes.Clear();
                                break;
                            case "Image":
                                MainViewModel.Instance.CurrentGame.Images.Clear();
                                break;
                            case "Object":
                                MainViewModel.Instance.CurrentGame.Objects.Clear();
                                break;
                            case "Level":
                                MainViewModel.Instance.CurrentGame.Levels.Clear();
                                break;
                        }
                    });
                }
                return _DeleteAll;
            }
        }

        private RelayCommand _CopyItem;
        public RelayCommand CopyItem
        {
            get
            {
                if (_CopyItem == null)
                {
                    _CopyItem = new RelayCommand((object parameter) =>
                    {
                        switch (parameter.ToString())
                        {
                            case "Class":
                                Clipboard.Clear();

                                //Clipboard.SetData(...);
                                break;
                        }
                    });
                }
                return _CopyItem;
            }
        }

        /*                       <ContextMenu>
                           <MenuItem Header="{DynamicResource Copy}" Command="{Binding ElementName=window, Path=CopyItem}" CommandParameter="Class"/>
                           <MenuItem Header="{DynamicResource Paste}" Command="{Binding ElementName=window, Path=PasteItem}" CommandParameter="Class"/>
                           <MenuItem Header="{DynamicResource Cut}" Command="{Binding ElementName=window, Path=CutItem}" CommandParameter="Class"/>
                           <MenuItem Header="{DynamicResource Delete}" Command="{Binding ElementName=window, Path=DeleteItem}" CommandParameter="Class"/>
                           <MenuItem Header="{DynamicResource Edit}" Command="{Binding ElementName=window, Path=EditItem}" CommandParameter="Class"/>
                       </ContextMenu>*/

    }
}
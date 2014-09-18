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

    }
}
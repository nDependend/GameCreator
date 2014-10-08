﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameCreator.ViewModels
{
    class LevelPaneViewModel : PaneViewModel
    {
        public LevelPaneViewModel(GC_Level gclevel)
        {
            if (gclevel == null)
                throw new ArgumentNullException("gclevel");
            this.Item = gclevel;
            this.Title = gclevel.Name;
        }

        public override void AssignChanges()
        {
            if ((Item as GC_Level).Game.Levels.Where(x => x.Name == this.Title).Count() > 0)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            (Item as GC_Level).Name = this.Title;
        }
    }
}
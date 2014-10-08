using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;
using System.Windows;
using System.Windows.Controls;
using GameCreator.ViewModels;

namespace GameCreator.Views.Pane
{
    class PanesStyleSelector : StyleSelector
    {
        public Style ClassPaneStyle { get; set; }
        public Style ImagePaneStyle { get; set; }
        public Style ObjectPaneStyle { get; set; }
        public Style LevelPaneStyle { get; set; }
        
        public override Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            if(item is ClassPaneViewModel)
                return ClassPaneStyle;
            if (item is ImagePaneViewModel)
                return ImagePaneStyle;
            if (item is ObjectPaneViewModel)
                return ObjectPaneStyle;
            if (item is LevelPaneViewModel)
                return LevelPaneStyle;

            return base.SelectStyle(item, container);
        }
    }
}

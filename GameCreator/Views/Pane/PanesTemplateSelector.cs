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
    class PanesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ClassPaneTemplate { get; set; }
        public DataTemplate ImagePaneTemplate { get; set; }
        public DataTemplate ObjectPaneTemplate { get; set; }
        public DataTemplate LevelPaneTemplate { get; set; }
        
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is ClassPaneViewModel)
                return ClassPaneTemplate;
            if (item is ImagePaneViewModel)
                return ImagePaneTemplate;
            if (item is ObjectPaneViewModel)
                return ObjectPaneTemplate;
            if (item is LevelPaneViewModel)
                return LevelPaneTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}

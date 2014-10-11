using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameCreator.Extensions.Controls
{
    /// <summary>
    /// Interaktionslogik für StageEditor.xaml
    /// </summary>
    public partial class StageEditor : UserControl
    {
        #region DependencyProperties
        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register(
            "BackgroundBrush",
            typeof(Brush),
            typeof(StageEditor));
        #endregion

        public Brush BackgroundBrush
        {
            get
            {
                return (Brush)GetValue(BackgroundBrushProperty);
            }
            set
            {
                SetValue(BackgroundBrushProperty,value);
            }
        }

        public StageEditor()
        {
            InitializeComponent();
        }
    }
}

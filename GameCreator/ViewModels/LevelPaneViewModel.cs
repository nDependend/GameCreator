using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace GameCreator.ViewModels
{
    class LevelPaneViewModel : PaneViewModel
    {
        #region Constant values
        private readonly ObservableCollection<string> _ImageLayout = new ObservableCollection<string>(new string[]{
            "Stretch","Tile","None"
        });
        public ObservableCollection<string> ImageLayout
        {
            get
            {
                return _ImageLayout;
            }
        }
        #endregion

        private GC_Image _BackgroundImage;
        public GC_Image BackgroundImage
        {
            get
            {
                return _BackgroundImage;
            }
            set
            {
                SetProperty(value, ref _BackgroundImage);
            }
        }

        private string _BackgroundImageLayout;
        public string BackgroundImageLayout
        {
            get
            {
                return _BackgroundImageLayout;
            }
            set
            {
                SetProperty(value, ref _BackgroundImageLayout);
            }
        }

        private int _Width;
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                SetProperty(value, ref _Width);
            }
        }

        private int _Height;
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                SetProperty(value, ref _Height);
            }
        }

        public LevelPaneViewModel(GC_Level gclevel)
        {
            if (gclevel == null)
                throw new ArgumentNullException("gclevel");
            this.Item = gclevel;
            this.Title = gclevel.Name;
            this.BackgroundImage = gclevel.BackgroundImage;
            this.BackgroundImageLayout = gclevel.BackgroundImageLayout;
            this.Width = gclevel.Width;
            this.Height = gclevel.Height;
        }

        public override void AssignChanges()
        {
            IEnumerable<GC_Level> coll = (Item as GC_Level).Game.Levels.Where(x => x.Name == this.Title);
            if (coll.Count() > 0 && coll.FirstOrDefault() != this.Item)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            GC_Level level = Item as GC_Level;
            level.Name = this.Title;
            level.BackgroundImage = this.BackgroundImage;
            level.BackgroundImageLayout = this.BackgroundImageLayout;
            level.Width = this.Width;
            level.Height = this.Height;
        }
    }
}

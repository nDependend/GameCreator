using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace GameCreator.ViewModels
{
    class ImagePaneViewModel : PaneViewModel
    {
        public ImagePaneViewModel(GC_Image gcimage)
        {
            if (gcimage == null)
                throw new ArgumentNullException("gcimage");
            this.Item = gcimage;
            this.Title = gcimage.Name;
        }

        public override void AssignChanges()
        {
            IEnumerable<GC_Image> coll = (Item as GC_Image).Game.Images.Where(x => x.Name == this.Title);
            if (coll.Count() > 0 && coll.FirstOrDefault() != this.Item)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            (Item as GC_Image).Name = this.Title;
        }
    }
}

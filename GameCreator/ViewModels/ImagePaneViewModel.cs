using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            (Item as GC_Image).Name = this.Title;
        }
    }
}

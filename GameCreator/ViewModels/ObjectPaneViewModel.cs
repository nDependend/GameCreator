using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameCreator.ViewModels
{
    class ObjectPaneViewModel : PaneViewModel
    {
        private GC_Class _Class;
        public GC_Class Class
        {
            get
            {
                return _Class;
            }
            set
            {
                SetProperty(value, ref _Class);
            }
        }

        private GC_Image _Image;
        public GC_Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                SetProperty(value, ref _Image);
            }
        }

        public ObjectPaneViewModel(GC_Object gcobject)
        {
            if (gcobject == null)
                throw new ArgumentNullException("gcobject");
            this.Item = gcobject;
            this.Title = gcobject.Name;
            this.Class = gcobject.Class;
            this.Image = gcobject.Image;
        }

        public override void AssignChanges()
        {
            IEnumerable<GC_Object> coll = (Item as GC_Object).Game.Objects.Where(x => x.Name == this.Title);
            if (coll.Count() > 0 && coll.FirstOrDefault() != this.Item)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            GC_Object obj = Item as GC_Object;
            obj.Name = this.Title;
            obj.Class = this.Class;
            obj.Image = this.Image;
        }
    }
}

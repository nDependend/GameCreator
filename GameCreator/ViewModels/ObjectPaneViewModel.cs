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
        public ObjectPaneViewModel(GC_Object gcobject)
        {
            if (gcobject == null)
                throw new ArgumentNullException("gcobject");
            this.Item = gcobject;
            this.Title = gcobject.Name;
        }

        public override void AssignChanges()
        {
            if ((Item as GC_Object).Game.Objects.Where(x => x.Name == this.Title).Count() > 0)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            (Item as GC_Object).Name = this.Title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            (Item as GC_Object).Name = this.Title;
        }
    }
}

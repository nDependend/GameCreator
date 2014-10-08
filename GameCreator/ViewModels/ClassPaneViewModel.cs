using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.ViewModels
{
    class ClassPaneViewModel : PaneViewModel
    {
        public ClassPaneViewModel(GC_Class gcclass)
        {
            if (gcclass == null)
                throw new ArgumentNullException("gcclass");
            this.Item = gcclass;
            this.Title = gcclass.Name;
        }

        public override void AssignChanges()
        {
            (Item as GC_Class).Name = this.Title;
        }
    }
}

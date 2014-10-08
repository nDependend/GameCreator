using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.ViewModels
{
    class LevelPaneViewModel : PaneViewModel
    {
        public LevelPaneViewModel(GC_Level gclevel)
        {
            if (gclevel == null)
                throw new ArgumentNullException("gclevel");
            this.Item = gclevel;
            this.Title = gclevel.Name;
        }

        public override void AssignChanges()
        {
            (Item as GC_Level).Name = this.Title;
        }
    }
}

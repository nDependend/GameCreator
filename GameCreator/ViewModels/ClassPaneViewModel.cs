using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            if ((Item as GC_Class).Game.Classes.Where(x => x.Name == this.Title).Count() > 0)
                this.Title = this.Title + " - " + Application.Current.FindResource("New").ToString();
            (Item as GC_Class).Name = this.Title;
        }
    }
}

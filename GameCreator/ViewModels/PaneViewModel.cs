using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.ViewModels
{
    public class PaneViewModel : PropertyChangedBase
    {
        private IGC_Item item;
        public IGC_Item Item
        {
            get
            {
                return item;
            }
            set
            {
                SetProperty(value, ref item);
            }
        }

        private string title = null;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                SetProperty(value, ref title);
            }
        }
  
        private bool isSelected = false;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                SetProperty(value, ref isSelected);
            }
        }

        private bool isActive = false;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                SetProperty(value, ref isActive);
            }
        }

        private bool isDirty = false;
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
            set
            {
                SetProperty(value, ref isDirty);
            }
        }

        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                if(closeCommand == null)
                    closeCommand = new RelayCommand((p) => OnClose(), () => CanClose());
                return closeCommand;
            }
        }
        private bool CanClose()
        {
            return true;
        }
        private void OnClose()
        {
            MainViewModel.Instance.OpenedItems.Remove(this);
        }

        public virtual void AssignChanges() { }
    }
}

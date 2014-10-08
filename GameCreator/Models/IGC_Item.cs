using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameCreator
{
    public interface IGC_Item
    {
        void Save(string filename);
        void Load(string filename);
    }
}

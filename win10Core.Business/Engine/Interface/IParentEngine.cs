using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.Engine.Interface
{
    public interface IParentEngine
    {
        Parent InsertParent(Parent insertParent);
        void UpdateParent(Parent updateParent);
        void DeleteParent(int deleteParent);
    }
}

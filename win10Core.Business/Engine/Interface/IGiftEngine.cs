using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.Engine.Interface
{
    public interface IGiftEngine
    {
        Gift InsertGift(Gift insertGift);
        void UpdateGift(Gift updateGift);
        void DeleteGift(int deleteGiftId);
    }
}

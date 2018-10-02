
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.Engine.Interface
{
    public interface IGiftEngine
    {
        Gift InsertGift(Gift insertGift);
        void UpdateGift(Gift updateGift);
        void DeleteGift(int deleteGiftId);
    }
}

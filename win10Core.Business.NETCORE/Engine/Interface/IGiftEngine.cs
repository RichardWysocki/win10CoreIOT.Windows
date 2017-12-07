using win10Core.Business.Model;

namespace win10Core.Business.NETCORE.Engine.Interface
{
    public interface IGiftEngine
    {
        Gift InsertGift(Gift insertGift);
        void UpdateGift(Gift updateGift);
        void DeleteGift(int deleteGiftId);
    }
}

﻿using win10Core.Business.Model;

namespace win10Core.Business.Engine.Interface
{
    public interface IKidEngine
    {
        Kid InsertKid(Kid insertkid);
        void UpdateKid(Kid updatekid);
        void DeleteKid(int deleteKid);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ByteCore.FerryBooking.Web
{
    public enum EnumFareCategory
    {
        CABIN,
        CARDECK,
        PASSAGE, 
        ADDON
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum BookingStatus
    {
        Complete=1,
        Pending=2,
        Fail=3
    }
}
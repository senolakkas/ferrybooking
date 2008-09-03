using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class AppSettingDto
    {

        #region Fields
        private System.String _SettingKey;
        private System.String _SettingValue;
        #endregion

        #region Constructor
        public AppSettingDto()
        {
        }
        public AppSettingDto(AppSetting appSetting)
        {
            _SettingKey = appSetting.ID;
            _SettingValue = appSetting.SettingValue;
        }

        #endregion

        #region Properties
         public virtual System.String SettingKey {
             get { return _SettingKey; }
             set { _SettingKey = value;}
         }

         public virtual System.String SettingValue {
             get { return _SettingValue; }
             set { _SettingValue = value;}
         }

        #endregion


     }
}

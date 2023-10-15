using MoreMountains.NiceVibrations;

namespace YohohoTest._src.CodeBase.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        public void PlayLightImpact() => 
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
    }
}
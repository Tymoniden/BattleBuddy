using System.Drawing;

namespace BattleBuddy.Services
{
    public interface IQRCodeService
    {
        Bitmap RenderQRCode(string text);
    }
}
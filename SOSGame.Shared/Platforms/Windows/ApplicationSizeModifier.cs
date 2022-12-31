using Microsoft.Maui.Devices;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace SOSGame.Shared;

public class ApplicationWindowSizeModifier : IApplicationSizeModifier
{
    public void Resize()
    {
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            int windowWidth = 950;
            int windowHeight = 500;
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(windowWidth, windowHeight));

            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

            int x = (int)(displayInfo.Width / displayInfo.Density - windowWidth) / 2;
            int y = (int)(displayInfo.Height / displayInfo.Density - windowHeight) / 2;

            var point = new PointInt32(x, y);

            appWindow.Move(point);
            
        });
    }
}

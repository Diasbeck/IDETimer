using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace IDETimer;

public class IDEChecker
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    
    private static DateTime _lastIdeActiveTime = DateTime.MinValue;

    public static bool IsIDEActive()
    {
        const int nChars = 256;
        StringBuilder buff = new StringBuilder(nChars);
        IntPtr handle = GetForegroundWindow();

        if (GetWindowText(handle, buff, nChars) > 0)
        {
            string title = buff.ToString();


            bool isIdeWindowNow = title.Contains(".cs") || title.Contains(".java") ||
                                    title.Contains(".py") || title.Contains(".js") ||
                                    title.Contains(".cpp") || title.Contains(".html");

            if (isIdeWindowNow)
            {
                _lastIdeActiveTime = DateTime.Now;
                return true;
            }
            else
            {
                TimeSpan timeSinceIde = DateTime.Now - _lastIdeActiveTime;
                if (timeSinceIde.TotalSeconds < 60)
                {
                    return true;
                }
            }

        }

        return false;
    }
}

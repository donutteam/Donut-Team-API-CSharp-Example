using System.Linq;

namespace LucasStuff
{
    public class ThemedRichTextBox : System.Windows.Forms.RichTextBox
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int Left, int Top, int Right, int Bottom)
            {
                this.Left = Left;
                this.Top = Top;
                this.Right = Right;
                this.Bottom = Bottom;
            }
        }

        private RECT BorderRect;

        private const int WM_THEMECHANGED = 0x31A;
        private const int WM_NCPAINT = 0x85;
        private const int WM_NCCALCSIZE = 0x83;

        private const int EP_EDITTEXT = 1;

        private const int ETS_NORMAL = 1;
        private const int ETS_HOT = 2;
        //private const int ETS_DISABLED = 4;
        private const int ETS_READONLY = 6;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    base.WndProc(ref m);
                    if (RenderWithVisualStyles())
                    {
                        var PartId = EP_EDITTEXT;
                        int StateId;
                        //if (this.Enabled)
                        {
                            if (this.ReadOnly)
                                StateId = ETS_READONLY;
                            else
                                StateId = ETS_NORMAL;
                        }
                        //else
                        //{
                        //    StateId = ETS_DISABLED;
                        //}
                        var WindowRect = default(RECT);
                        GetWindowRect(this.Handle, ref WindowRect);
                        WindowRect.Right -= WindowRect.Left;
                        WindowRect.Bottom -= WindowRect.Top;
                        WindowRect.Left = 0;
                        WindowRect.Top = 0;
                        var DC = GetWindowDC(this.Handle);
                        var ClientRect = WindowRect;
                        ClientRect.Left += this.BorderRect.Left;
                        ClientRect.Top += this.BorderRect.Top;
                        ClientRect.Right -= this.BorderRect.Right;
                        ClientRect.Bottom -= this.BorderRect.Bottom;
                        ExcludeClipRect(DC, ClientRect.Left, ClientRect.Top, ClientRect.Right, ClientRect.Bottom);
                        var Theme = OpenThemeData(this.Handle, "EDIT");
                        if (IsThemeBackgroundPartiallyTransparent(Theme, EP_EDITTEXT, ETS_NORMAL) != 0)
                            DrawThemeParentBackground(this.Handle, DC, ref WindowRect);
                        DrawThemeBackground(Theme, DC, PartId, StateId, ref WindowRect, System.IntPtr.Zero);
                        CloseThemeData(Theme);
                        ReleaseDC(this.Handle, DC);
                        m.Result = System.IntPtr.Zero;
                    }
                    break;
                case WM_NCCALCSIZE:
                    base.WndProc(ref m);
                    if (RenderWithVisualStyles())
                    {
                        var Par = new NCCALCSIZE_PARAMS();
                        RECT WindowRect;
                        if (m.WParam == System.IntPtr.Zero)
                            WindowRect = (RECT)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(RECT));
                        else
                        {
                            Par = (NCCALCSIZE_PARAMS)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                            WindowRect = Par.rgrc0;
                        }
                        var ContentRect = default(RECT);
                        var DC = GetWindowDC(this.Handle);
                        var Theme = OpenThemeData(this.Handle, "EDIT");
                        if (GetThemeBackgroundContentRect(Theme, DC, EP_EDITTEXT, ETS_NORMAL, ref WindowRect, ref ContentRect) == S_OK)
                        {
                            ContentRect.Left += 1;
                            ContentRect.Top += 1;
                            ContentRect.Right -= 1;
                            ContentRect.Bottom -= 1;
                            this.BorderRect = new RECT(ContentRect.Left - WindowRect.Left, ContentRect.Top - WindowRect.Top, WindowRect.Right - ContentRect.Right, WindowRect.Bottom - ContentRect.Bottom);
                            if (m.WParam == System.IntPtr.Zero)
                                System.Runtime.InteropServices.Marshal.StructureToPtr(ContentRect, m.LParam, false);
                            else
                            {
                                Par.rgrc0 = ContentRect;
                                System.Runtime.InteropServices.Marshal.StructureToPtr(Par, m.LParam, false);
                            }
                            m.Result = new System.IntPtr(WVR_REDRAW);
                        }
                        CloseThemeData(Theme);
                        ReleaseDC(this.Handle, DC);
                    }
                    break;
                case WM_THEMECHANGED:
                    UpdateStyles();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0;
            public RECT rgrc1;
            public RECT rgrc2;
            public System.IntPtr lppos;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern System.IntPtr GetWindowDC(System.IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int ReleaseDC(System.IntPtr hWnd, System.IntPtr hDC);

        [System.Runtime.InteropServices.DllImport("uxtheme.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern System.IntPtr OpenThemeData(System.IntPtr hWnd, string classList);

        [System.Runtime.InteropServices.DllImport("uxtheme", ExactSpelling = true)]
        private static extern int GetThemeBackgroundContentRect(System.IntPtr hTheme, System.IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, ref RECT pContentRect);

        private const int S_OK = 0x0;

        private const int WVR_HREDRAW = 0x100;
        private const int WVR_VREDRAW = 0x200;
        private const int WVR_REDRAW = WVR_HREDRAW | WVR_VREDRAW;

        [System.Runtime.InteropServices.DllImport("uxtheme", ExactSpelling = true)]
        private static extern int IsThemeBackgroundPartiallyTransparent(System.IntPtr hTheme, int iPartId, int iStateId);

        [System.Runtime.InteropServices.DllImport("uxtheme.dll", ExactSpelling = true)]
        private static extern int CloseThemeData(System.IntPtr hTheme);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool GetWindowRect(System.IntPtr hWnd, ref RECT lpRect);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int ExcludeClipRect(System.IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [System.Runtime.InteropServices.DllImport("uxtheme", ExactSpelling = true)]
        private static extern int DrawThemeParentBackground(System.IntPtr hWnd, System.IntPtr hdc, ref RECT pRect);

        [System.Runtime.InteropServices.DllImport("uxtheme", ExactSpelling = true)]
        private static extern int DrawThemeBackground(System.IntPtr hTheme, System.IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, System.IntPtr pClipRect);

        private bool RenderWithVisualStyles()
        {
            return this.BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D && System.Windows.Forms.Application.RenderWithVisualStyles;
        }

        private const int WS_EX_CLIENTEDGE = 0x200;

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var p = base.CreateParams;
                if (RenderWithVisualStyles() && (p.ExStyle & WS_EX_CLIENTEDGE) == WS_EX_CLIENTEDGE)
                    p.ExStyle = p.ExStyle ^ WS_EX_CLIENTEDGE;
                return p;
            }
        }
    }
}
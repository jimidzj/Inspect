using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;




namespace GENLSYS.MES.WinPAD.Common.Forms
{
    
    public class vkButton : Label
    {
        public vkButton(string text)
        {
            New(text, new Size(50, 50), new Font("tahoma", 12, FontStyle.Bold));
        }
        public vkButton(string text, Size size, Font font)
        {
            New(text, size, font);
        }
        public void New(string text, Size size, Font font)
        {
            this.Text = text;   //设置控件的 Text 属性
            this.Tag = text;
            this.Font = font;  //控件所使用的字体
            this.Size = size;  //控件呈现的大小尺寸
            //定义控件为自绘模式并使用双缓存
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
                            | ControlStyles.OptimizedDoubleBuffer, true);
            //添加鼠标事件响应事件
            this.MouseUp += new MouseEventHandler(btnNormal);
            this.MouseDown += new MouseEventHandler(btnPressed);
            this.MouseLeave += new EventHandler(btnNormal);
            this.MouseHover += new EventHandler(btnHover);
            //实例化后默认常规状态的颜色
            this.NormalColor = Color.LightSteelBlue;
            this.HoverColor = Color.Orange;
            this.PressedColor = Color.Red;
        }
        public Color HoverColor { set; get; }    //鼠标激活时的颜色的属性
        public Color NormalColor { set; get; } //正常状态的颜色的属性
        public Color PressedColor { set; get; } //鼠标按下时的颜色的属性
        private void btnNormal(object o, EventArgs e)
        {
            //这里绘画常规状态的控件界面
            Graphics graphic = this.CreateGraphics(); //创建绘图对象
            btnPaint(graphic, this.ForeColor, NormalColor); //绘画界面
            graphic.Dispose(); //及时释放对象资源
        }
        private void btnHover(object o, EventArgs e)
        {
            //这里绘画鼠标激活时的控件界面
            Graphics graphic = this.CreateGraphics();
            btnPaint(graphic, this.ForeColor, HoverColor);
            graphic.Dispose();
        }
        private void btnPressed(object o, EventArgs e)
        {
            //这里绘画鼠标按下后的控件界面
            Graphics graphic = this.CreateGraphics();
            btnPaint(graphic, this.ForeColor, PressedColor);
            graphic.Dispose();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            btnPaint(e.Graphics, this.ForeColor, this.NormalColor);
        }


        /* 此方法用于根据传入的参数绘制控件界面*/
        private void btnPaint(Graphics graphic, Color foreColor, Color backgroundColor)
        {
            graphic.Clear(this.BackColor);  //以背景色清除图象
            Color lightColor, darkColor;    //定义高亮和暗部分的颜色
            StringFormat textFormat = new StringFormat(); //用于设置文字格式
            LinearGradientBrush brush; //定义渐变笔刷
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1); //获取矩型区域
            lightColor = Color.FromArgb(0, backgroundColor);  //获取高亮颜色
            darkColor = Color.FromArgb(255, backgroundColor); //获取暗颜色
            //生成渐变笔刷实例
            brush = new LinearGradientBrush(rect, lightColor, darkColor, LinearGradientMode.BackwardDiagonal);
            graphic.FillRectangle(brush, rect); //使用渐变画笔刷填充 
            graphic.DrawRectangle(new Pen(foreColor), rect); //使用前景色画边框
            textFormat.Alignment = StringAlignment.Center; //设置文字垂直对齐方式          
            textFormat.LineAlignment = StringAlignment.Center; //设置文字水平对齐方式
            //绘画控件显示的正文
            graphic.DrawString(this.Text, this.Font, new SolidBrush(foreColor), rect, textFormat);
        }
    }
    public static class Win32API
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessage(
             int hwnd,
             int wMsg,
             int wParam,
             int lParam);
        [DllImport("user32.dll", EntryPoint = "PostMessageW")]
        public static extern int PostMessage(
             int hwnd,
             int wMsg,
             int wParam,
             int lParam);
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetFocus();
        [DllImport("user32.dll")]
        public static extern int AttachThreadInput(
             int idAttach,
             int idAttachTo,
             int fAttach);
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(
             int hwnd,
             int lpdwProcessId);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        public const int WM_MOUSEACTIVATE = 0x21;
        public const int WM_KEYDOWN = 0x100;
        public const int MA_NOACTIVATE = 3;
        public const int WS_EX_NOACTIVATE = 0x8000000;
    }
    public class vkForm : Form
    {
        static readonly short VK_OEM_1 = 0xBA;  // ';:' for US
        static readonly short VK_OEM_PLUS = 0xBB;  // '+' any country
        static readonly short VK_OEM_MINUS = 0xBD;  // '-' any country
        static readonly short VK_OEM_2 = 0xBF;  // '/?' for US
        static readonly short VK_OEM_3 = 0xC0;  // '`~' for US
        static readonly short VK_OEM_4 = 0xDB;  //  '[{' for US
        static readonly short VK_OEM_5 = 0xDC;  //  '\|' for US
        static readonly short VK_OEM_6 = 0xDD;  //  ']}' for US
        static readonly short VK_OEM_7 = 0xDE;  //  ''"' for US
        static readonly short VK_OEM_PERIOD = 0xBE;  // '.>' any country
        static readonly short VK_OEM_COMMA = 0xBC;  // ',<' any country

        public static bool isOpen = false;
        private vkButton[] vk = new vkButton[44];  //36 +9
        private vkButton btnExit;
        private Point offset;
        public static vkForm kb;
        
        protected override void OnLoad(EventArgs e)
        {
            btnExit = new vkButton("关闭");
           // btnExit.Dock = DockStyle.Bottom;
            btnExit.Size = new Size(50, 50);
            btnExit.Location = new Point(10, 10);
            //先添加26个字母的虚拟按键
            for (int i = 0; i < 26; i++)
            {
                //使用刚才建立的按钮类实例化每个虚拟按钮
                //字母A对应ASCII代码为 65,即B为 66,如此类推
                vk[i] = new vkButton(((char)(i + 65)).ToString());
            }
            //继续添加0-9的数字键
            for (int i = 0; i < 10; i++)
            {
                //实例化各个数字的虚拟按钮,0 对应ASCII代码为 48
                vk[26 + i] = new vkButton(((char)(i + 48)).ToString());
            }

             
 
            vk[36] = new vkButton("-");
            vk[37] = new vkButton(",");
            vk[38] = new vkButton(".");
            vk[39] = new vkButton(";");
            vk[40] = new vkButton("/");
            vk[41] = new vkButton("=");
            vk[42] = new vkButton("空格");
            vk[43] = new vkButton("删除");


            this.TopMost = true;
            this.ControlBox = false;
            this.Size = new Size(530, 290);
            this.Controls.AddRange(vk);    //加入所有的虚拟按键
            this.Controls.Add(btnExit);  //加入一个退出程序的按钮
            int x = 64;
            int y = 10;
            for (int i = 0; i < vk.Length ; i++)
            {
                vk[i].Click += btnCommon_Click;  //为按钮添加事件响应
                vk[i].Location = new Point(x, y);
                x += 52 + 2;
                if (x + 52 >= this.Width)
                {
                    y += 52;
                    x = 10;
                }
            }
            btnExit.Click += btnExit_Click; //为退出按钮添加事件响应

            Screen screen = Screen.PrimaryScreen;
            int screenW = screen.Bounds.Width;         //宽 
            int screenH = screen.Bounds.Height;         //高 
            this.Size = new Size(530, 290);
            int x2 = (screenW - this.Width) / 2;
            int y2 = screenH - this.Height - 10;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x2, y2);
            
        }
        public static void move(int x , int y)
        {           
            if (kb == null)
            {
                kb = new vkForm();
            }

            kb.StartPosition = FormStartPosition.Manual;
            kb.Location = new Point(x, y);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point offset = e.Location;
                offset = this.PointToScreen(e.Location);
                this.Left = offset.X - this.offset.X;
                this.Top = offset.Y - this.offset.Y;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                offset = e.Location;
            }
        }
        private void AttachThreadInput(bool b)
        {
            //设置线程亲和,附到前台窗口所在线程,只有在线程内才可以获取线程内控件的焦点
            //线程亲和: AttachThreadInput(目标线程标识, 当前线程标识, 非零值关联) 零表示取消
            //窗口所在的线程的标识: GetWindowThreadProcessId(窗体句柄, 这里返回进程标识)
            //当前的前台窗口的句柄: GetForegroundWindow()
            //当前程序所在的线程标识: GetCurrentThreadId()
            Win32API.AttachThreadInput(
                   Win32API.GetWindowThreadProcessId(
                            Win32API.GetForegroundWindow(), 0),
                   Win32API.GetCurrentThreadId(), Convert.ToInt32(b));
        }
        private void btnCommon_Click(object o, EventArgs e)
        {
            AttachThreadInput(true); //设置线程亲和的关联
            int getFocus = Win32API.GetFocus();
            //o为object类型,使用强制转换成vkButton
            char keyvalue = ((vkButton)o).Text.ToCharArray()[0];
            //向前台窗口发送按键消息
            if (((vkButton)o).Text == "删除")
            {
                keyvalue = '\b';
                // keyvalue = System.Convert.ToChar(0xBD);
            }
            else
            {
                if (((vkButton)o).Text == "-")
                {
                    keyvalue = System.Convert.ToChar(VK_OEM_MINUS);
                }
                else
                {
                    if (((vkButton)o).Text == ",")
                    {
                        keyvalue = System.Convert.ToChar(VK_OEM_COMMA);
                    }
                    else
                    {
                        if (((vkButton)o).Text == ".")
                        {
                            keyvalue = System.Convert.ToChar(VK_OEM_PERIOD);
                        }
                        else
                        {
                            if (((vkButton)o).Text == ";")
                            {
                                keyvalue = System.Convert.ToChar(VK_OEM_1);
                            }
                            else
                            {
                                if (((vkButton)o).Text == "/")
                                {
                                    keyvalue = System.Convert.ToChar(0xBF);

                                }
                                else
                                {
                                    if (((vkButton)o).Text == "=")
                                    {
                                        keyvalue = System.Convert.ToChar(0xBB);

                                    }
                                    else
                                    {
                                        if (((vkButton)o).Text == "空格")
                                        {
                                            keyvalue = System.Convert.ToChar(0x20);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
             


                    
            //向前台窗口发送按键消息
            Win32API.PostMessage(getFocus, Win32API.WM_KEYDOWN, (byte)keyvalue, 0);
            AttachThreadInput(false); //取消线程亲和的关联
        }
        private void btnExit_Click(object o, EventArgs e)
        {
            this.Hide();
            isOpen = false;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //若在窗体上产生鼠标点击事件的消息则使消息返回值标记为不激活
            //程序内部的窗口切换仅需返回 MA_NOACTIVATE 即可,若相对其它
            //的程序窗口切换时 还需要设置 WS_EX_NOACTIVATE 样式
            if (m.Msg == Win32API.WM_MOUSEACTIVATE)
                m.Result = (IntPtr)Win32API.MA_NOACTIVATE;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //为窗体样式添加不激活标识
                cp.ExStyle = Win32API.WS_EX_NOACTIVATE;
                return cp;
            }
        }
       
        public static void showKeyboard()
        {
            if (kb == null)
            {
                kb = new vkForm();
            }

            if (! isOpen)
            {              
                kb.Show();
                isOpen = true;
            }

        }

        public static void hideKeyboard()
        {
            if (isOpen)
            {
               
                kb.Show();
                isOpen = false;
            }

        }
  
        public static void iniKeyboard()
        {
            if (kb == null)
            {
                kb = new vkForm();
                isOpen = false;
            }

          
            
        }
        
    }
}


using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace busyIdle
{
    
    public partial class frm_BusyIdle : Form
    {
        Timer mainLoop;
        Random random;

        int[] timesInt = new int[] {1000, 60000, 300000, 600000, 3600000};
        String[] timesNames = new string[] { "1 sec", "1 min", "5 min", "10 min", "1 hour" };

        int screenX, screenY;

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }


        public frm_BusyIdle()
        {
            InitializeComponent();
        }

        private void startIdel()
        {
            if(mainLoop.Enabled) return;
            setInput(false);

            mainLoop.Start();
        }

        private void setInput(bool on)
        {
            if (!on) lb_output.Text = "";
            grp_working.Visible = !on;
            trbr_time.Enabled = on;
        }

        private void stopIdel()
        {
            if (!mainLoop.Enabled) return;
            setInput(true);
            mainLoop.Stop();
        }

        private void onChangedTick(object sender, EventArgs e)
        {
            if (chbx_On.Checked)
                startIdel();
            else
                stopIdel();
        }

        private void frm_BusyIdle_Load(object sender, EventArgs e)
        {
            int startTime = 2;

            mainLoop = new Timer();
            mainLoop.Stop();
            mainLoop.Interval = timesInt[startTime];
            lb_time.Text = timesNames[startTime];
            Console.Out.WriteLine(DateTime.Now.ToString());
            random = new Random(DateTime.Now.Second);

            screenX = Screen.PrimaryScreen.Bounds.Width;
            screenY = Screen.PrimaryScreen.Bounds.Height;

            mainLoop.Tick += new EventHandler(tickMouse);

            chbx_On.Focus();
        }

        private void changeInterval(object sender, EventArgs e)
        {
            int i = trbr_time.Value;
            lb_time.Text = timesNames[i];
            mainLoop.Interval = timesInt[i];            
        }

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("kernal32.dll",CharSet = CharSet.Auto,SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState

        private void onClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tickMouse(Object myObject, EventArgs eventArgs)
        {
            int x = random.Next(0, screenX);
            int y = random.Next(0, screenY);
            SetCursorPos(x, y);
            lb_output.Text = "X: " + x + " Y: " + y;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_and_stopwatch
{
    public partial class Form1 : Form
    {
        private bool RedBlue;
        private int time = 10;
        private bool isTimerRunning = false;
        private int saveSeconds = 0;
        private int saveMinutes = 0;
        private int saveHours = 0;
        private int checkSeconds = 0;
        private int checkMinutes = 0;
        private int checkHours = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Timer_Setting(object sender, EventArgs e)
        {
            this.Controls.Add(EndTimer);
            this.BackColor = Color.FromArgb(153, 153, 153);

            Timer1.Tick -= Stopwatches_Tick_Function;
            Timer1.Tick += Timer_Tick_Function;
            StartAndStop.Click -= Click_Start_Or_Stop_For_Stopwatches;
            StartAndStop.Click += Click_Start_Or_Stop_For_Timer;
            StartAndStop.Click += Set_ProgressBar;
            Restart.Click -= Stopwatches_Restart;
            Restart.Click += Timer_Restart;
            Seconds.Enabled = true;
            Minutes.Enabled = true;
            Hours.Enabled = true;
        }
        private void Stopwatches_Setting(object sender, EventArgs e)
        {
            this.Controls.RemoveByKey("ProgBar_Time");
            this.BackColor = Color.FromArgb(188, 188, 188);

            Timer1.Tick -= Timer_Tick_Function;
            Timer1.Tick += Stopwatches_Tick_Function; 
            StartAndStop.Click -= Click_Start_Or_Stop_For_Timer;
            StartAndStop.Click += Click_Start_Or_Stop_For_Stopwatches;
            StartAndStop.Click -= Set_ProgressBar;
            Restart.Click -= Timer_Restart;
            Restart.Click += Stopwatches_Restart;
            Seconds.Enabled = false;
            Minutes.Enabled = false;
            Hours.Enabled = false;
        }
        private void Timer_Tick_Function(object sender, EventArgs e)
        {
            if (Seconds.SelectedIndex != 0)
            {
                EndTimer.Value--;
                Seconds.SelectedIndex--;
            }
            if(Seconds.SelectedIndex == 0 && Minutes.SelectedIndex != 0)
            {
                Seconds.SelectedIndex = 59;
                Minutes.SelectedIndex--;
            }
            if(Seconds.SelectedIndex == 0 && Minutes.SelectedIndex == 0 && Hours.SelectedIndex != 0)
            {
                Seconds.SelectedIndex = 59;
                Minutes.SelectedIndex = 59;
                Hours.SelectedIndex--;
            }
            if (Seconds.SelectedIndex == 0 && Minutes.SelectedIndex == 0 && Hours.SelectedIndex == 0)
            {
                Timer1.Stop();
                alert.Start();
            }
        }
        private void Stopwatches_Tick_Function(object sender, EventArgs e)
        {
            if (Seconds.SelectedIndex < 60)
                Seconds.SelectedIndex++;
            if(Seconds.SelectedIndex == 59 && Minutes.SelectedIndex != 59)
            {
                Seconds.SelectedIndex = 0;
                Minutes.SelectedIndex++;
            }
            if(Seconds.SelectedIndex == 60 && Minutes.SelectedIndex == 59 && Hours.SelectedIndex != 23)
            {
                Seconds.SelectedIndex = 0;
                Minutes.SelectedIndex = 0;
                Hours.SelectedIndex++;
            }
            if(Seconds.SelectedIndex == 0 && Minutes.SelectedIndex == 0 && Hours.SelectedIndex == 24)
            {
                Timer1.Stop();
            }
        }
        private void Click_Start_Or_Stop_For_Timer(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                checkSeconds = Seconds.SelectedIndex;
                checkMinutes = Minutes.SelectedIndex;
                checkHours = Hours.SelectedIndex;
                Timer1.Stop();
                isTimerRunning = false;
                StartAndStop.Text = "Start";
                Seconds.Enabled = true;
                Minutes.Enabled = true;
                Hours.Enabled = true;
                Restart.Enabled = true;
                if (this.BackColor == Color.FromArgb(255, 0, 0) || this.BackColor == Color.FromArgb(0, 0, 255))
                {
                    alert.Stop();
                    this.BackColor = Color.FromArgb(153, 153, 153);
                    time = 10;
                }
            }
            else
            {
                if (checkSeconds != Seconds.SelectedIndex || checkMinutes != Minutes.SelectedIndex || checkHours != Hours.SelectedIndex)
                {
                    saveSeconds = Seconds.SelectedIndex;
                    saveMinutes = Minutes.SelectedIndex;
                    saveHours = Hours.SelectedIndex;
                }
                Timer1.Start();
                isTimerRunning = true;
                StartAndStop.Text = "Stop";
                Seconds.Enabled = false;
                Minutes.Enabled = false;
                Hours.Enabled = false;
                Restart.Enabled = false;
            }
        }
        private void Click_Start_Or_Stop_For_Stopwatches(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                Timer1.Stop();
                isTimerRunning = false;
                StartAndStop.Text = "Start";
            }
            else
            {
                Timer1.Start();
                isTimerRunning = true;
                StartAndStop.Text = "Stop";
            }
        }
        private void Timer_Restart(object sender, EventArgs e)
        {
            Seconds.SelectedIndex = saveSeconds;
            Minutes.SelectedIndex = saveMinutes;
            Hours.SelectedIndex = saveHours;
        }
        private void Stopwatches_Restart(object sender, EventArgs e)
        {
            Seconds.SelectedIndex = 0;
            Minutes.SelectedIndex = 0;
            Hours.SelectedIndex = 0;
        }
        private void Set_ProgressBar(object sender, EventArgs e)
        {
            EndTimer.Maximum = Seconds.SelectedIndex + ((Hours.SelectedIndex * 60) * 60) + (Minutes.SelectedIndex * 60);
            EndTimer.Value = EndTimer.Maximum;
        }
    }
}

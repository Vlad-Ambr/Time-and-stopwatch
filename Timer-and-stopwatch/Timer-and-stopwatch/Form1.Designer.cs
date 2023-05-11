using System.Drawing;
using System.Windows.Forms;

namespace Timer_and_stopwatch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Timer";
            this.Width = 450;
            this.Height = 300;
            this.Load += Timer_Setting;


            //
            //
            //
            Switch = new MenuStrip();
            Switch.BackColor = Color.FromArgb(74, 71, 71);
            Switch.Height = 50;
            this.Controls.Add(Switch);



            //
            //
            //
            Timers = new ToolStripMenuItem();
            Timers.Text = "Timer";
            Timers.ForeColor = Color.FromArgb(255, 255, 255);
            Timers.BackColor = Color.FromArgb(153, 153, 153);
            Timers.Click += Timer_Setting;
            Switch.Items.Add(Timers);



            //
            //
            //
            Stopwatches = new ToolStripMenuItem();
            Stopwatches.Text = "Stopwatch";
            Stopwatches.ForeColor = Color.FromArgb(255, 255, 255);
            Stopwatches.BackColor = Color.FromArgb(188, 188, 188);
            Stopwatches.Click += Stopwatches_Setting;
            Switch.Items.Add(Stopwatches);



            //
            //
            //
            Seconds = new ListBox();
            Seconds.Font = new Font(Seconds.Font.FontFamily, 22);
            Seconds.Width = 58;
            Seconds.Height = 40;
            for (int i = 0; i <= 60; i++)
                Seconds.Items.Add(i.ToString());
            Seconds.SelectedIndex = 0;
            Seconds.Location = new Point((this.Width / 2) + ((Seconds.Width / 2) + 20), (this.Height / 2) - 100);
            this.Controls.Add(Seconds);
            


            //
            //
            //
            Minutes = new ListBox();
            Minutes.Font = new Font(Minutes.Font.FontFamily, 22);
            Minutes.Width = 58;
            Minutes.Height = 40;
            for (int i = 0; i <= 60; i++)
                Minutes.Items.Add(i.ToString());
            Minutes.SelectedIndex = 0;
            Minutes.Location = new Point((this.Width / 2) - (Minutes.Width / 2 + 5), (this.Height / 2) - 100);
            this.Controls.Add(Minutes);



            //
            //
            //
            Hours = new ListBox();
            Hours.Font = new Font(Hours.Font.FontFamily, 22);
            Hours.Width = 58;
            Hours.Height = 40;
            for (int i = 0; i <= 24; i++)
                Hours.Items.Add(i.ToString());
            Hours.SelectedIndex = 0;
            Hours.Location = new Point((this.Width / 2) - ((Hours.Width / 2) + 88), (this.Height / 2) - 100);
            this.Controls.Add(Hours);



            //
            //
            //
            Timer1 = new Timer();
            Timer1.Interval = 1000;



            //
            //
            //
            StartAndStop = new Button();
            StartAndStop.Text = "Start";
            StartAndStop.BackColor = Color.FromArgb(255, 255, 255);
            StartAndStop.Location = new Point((this.Width / 2) + (StartAndStop.Width / 2), Minutes.Location.Y + Minutes.Height + 20);
            this.Controls.Add(StartAndStop);



            //
            //
            //
            Restart = new Button();
            Restart.Text = "Restart";
            Restart.BackColor = Color.FromArgb(255, 255, 255);
            Restart.Location = new Point((this.Width / 2) - ((Restart.Width / 2) + Restart.Width), Minutes.Location.Y + Minutes.Height + 20);
            this.Controls.Add(Restart);



            //
            //
            //
            EndTimer = new ProgressBar();
            EndTimer.Name = "ProgBar_Time";
            EndTimer.Minimum = 0;
            EndTimer.Width = this.Width - 70;
            EndTimer.Location = new Point(25, StartAndStop.Location.Y + StartAndStop.Height + 25);


            
            //
            //
            //
            alert = new Timer();
            alert.Interval = 400;
            alert.Tick += (s, e) =>
            {
                time--;
                if (RedBlue)
                {
                    this.BackColor = Color.FromArgb(255, 0, 0);
                    RedBlue = false;
                }
                else
                {
                    this.BackColor = Color.FromArgb(0, 0, 255);
                    RedBlue = true;
                }
                if(time == 0)
                {
                    alert.Stop();
                    this.BackColor = Color.FromArgb(153, 153, 153);
                    time = 10;
                    StartAndStop.Text = "Start";
                    isTimerRunning = false;
                    Restart.Enabled = true;
                }
            };
        }
        
        MenuStrip Switch;
        ToolStripMenuItem Timers;
        ToolStripMenuItem Stopwatches;
        ListBox Seconds;
        ListBox Minutes;
        ListBox Hours;
        ProgressBar EndTimer;
        Timer Timer1;
        Button StartAndStop;
        Button Restart;
        Timer alert;
        
        #endregion
    }
}


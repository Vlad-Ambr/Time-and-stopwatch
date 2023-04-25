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
            this.Load += (s, e) => this.Controls.Add(PanelTimer);


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
            Timers.Click += (s, e) =>
            {
                this.Controls.RemoveByKey("panel_2");
                this.Controls.Add(PanelTimer);
            };
            Switch.Items.Add(Timers);



            //
            //
            //
            Stopwatches = new ToolStripMenuItem();
            Stopwatches.Text = "Stopwatch";
            Stopwatches.ForeColor = Color.FromArgb(255, 255, 255);
            Stopwatches.BackColor = Color.FromArgb(188, 188, 188);
            Stopwatches.Click += (s, e) =>
            {
                this.Controls.RemoveByKey("panel_1");
                this.Controls.Add(PanelStopwatch);
            };
            Switch.Items.Add(Stopwatches);



            //
            //
            //
            PanelTimer = new Panel();
            PanelTimer.Name = "panel_1";
            PanelTimer.Width = this.Width;
            PanelTimer.Height = this.Height - Switch.Height;
            PanelTimer.BackColor = Color.FromArgb(153, 153, 153);
            PanelTimer.Location = new Point(0, Switch.Height);



            //
            //
            //
            PanelStopwatch = new Panel();
            PanelStopwatch.Name = "panel_2";
            PanelStopwatch.Width = this.Width;
            PanelStopwatch.Height = this.Height - Switch.Height;
            PanelStopwatch.BackColor = Color.FromArgb(188, 188, 188);
            PanelStopwatch.Location = new Point(0, Switch.Height);



            //
            //
            //
            Seconds = new ListBox();
            Seconds.Font = new Font(Seconds.Font.FontFamily, 22);
            Seconds.Width = 58;
            Seconds.Height = 120;
            Seconds.BackColor = Color.White;
            for(int i = 1; i <= 60; i++)
                Seconds.Items.Add(i.ToString());
            Seconds.Location = new Point((PanelTimer.Width / 2) + ((Seconds.Width / 2) + 20), (PanelTimer.Height / 2) - 100);
            PanelTimer.Controls.Add(Seconds);



            //
            //
            //
            Minutes = new ListBox();
            Minutes.Font = new Font(Minutes.Font.FontFamily, 22);
            Minutes.Width = 58;
            Minutes.Height = 120;
            Minutes.BackColor = Color.White;
            for(int i = 1; i <= 60; i++)
                Minutes.Items.Add(i.ToString());
            Minutes.Location = new Point((PanelTimer.Width / 2) - (Minutes.Width / 2 + 5), (PanelTimer.Height / 2) - 100);
            PanelTimer.Controls.Add(Minutes);



            //
            //
            //
            Hours = new ListBox();
            Hours.Font = new Font(Hours.Font.FontFamily, 22);
            Hours.Width = 58;
            Hours.Height = 120;
            Hours.BackColor = Color.White;
            Hours.ForeColor = Color.Gray;
            Hours.SelectedIndexChanged += (s, e) => Hours.ForeColor = Color.Black;
            for (int i = 1; i <= 24; i++)
                Hours.Items.Add(i.ToString());
            Hours.Location = new Point((PanelTimer.Width / 2) - ((Hours.Width / 2) + 88), (PanelTimer.Height / 2) - 100);
            PanelTimer.Controls.Add(Hours);
        }
        MenuStrip Switch;
        ToolStripMenuItem Timers;
        ToolStripMenuItem Stopwatches;
        Panel PanelTimer;
        Panel PanelStopwatch;
        ListBox Seconds;
        ListBox Minutes;
        ListBox Hours;
        #endregion
    }
}


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace busyIdle;

public class frm_BusyIdle : Form
{
	private Timer mainLoop;

	private poker poker;

	private int[] timesInt = new int[5] { 1000, 60000, 300000, 600000, 3600000 };

	private string[] timesNames = new string[5] { "1 sec", "1 min", "5 min", "10 min", "1 hour" };

	private bool keepAwake;

	private IContainer components;

	private GroupBox grp_working;

	private Label lb_output;

	private TrackBar trbr_time;

	private Label label1;

	private Label lb_time;

	private CheckBox chbx_keepAwake;

	private Button btn_func;

	private Label label2;

	private Label label3;

	public frm_BusyIdle()
	{
		InitializeComponent();
	}

	private void setEnabled(bool on)
	{
		if (on)
		{
			mainLoop.Stop();
		}
		else
		{
			lb_output.Text = "";
			mainLoop.Start();
		}
		btn_func.Text = (on ? "Start" : "Stop");
		grp_working.Visible = !on;
		trbr_time.Enabled = on;
		chbx_keepAwake.Enabled = on;
	}

	private void onLoad(object sender, EventArgs e)
	{
		mainLoop = new Timer();
		mainLoop.Stop();
		mainLoop.Interval = 300000;
		poker = new poker(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
		mainLoop.Tick += tickMouse;
		btn_func.Focus();
	}

	private void changeInterval(object sender, EventArgs e)
	{
		int value = trbr_time.Value;
		lb_time.Text = timesNames[value];
		mainLoop.Interval = timesInt[value];
	}

	private void changeKeepAwake(object sender, EventArgs e)
	{
		keepAwake = chbx_keepAwake.Checked;
	}

	private void tickMouse(object myObject, EventArgs eventArgs)
	{
		int[] array = poker.poke(keepAwake);
		lb_output.Text = "X: " + array[0] + " Y: " + array[1];
	}

	private void clicked(object sender, EventArgs e)
	{
		setEnabled(mainLoop.Enabled);
	}

	private void frm_BusyIdle_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyValue == 27)
		{
			Application.Exit();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.grp_working = new System.Windows.Forms.GroupBox();
		this.label2 = new System.Windows.Forms.Label();
		this.lb_output = new System.Windows.Forms.Label();
		this.trbr_time = new System.Windows.Forms.TrackBar();
		this.label1 = new System.Windows.Forms.Label();
		this.lb_time = new System.Windows.Forms.Label();
		this.chbx_keepAwake = new System.Windows.Forms.CheckBox();
		this.btn_func = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.grp_working.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.trbr_time).BeginInit();
		base.SuspendLayout();
		this.grp_working.CausesValidation = false;
		this.grp_working.Controls.Add(this.label3);
		this.grp_working.Controls.Add(this.label2);
		this.grp_working.Controls.Add(this.lb_output);
		this.grp_working.Location = new System.Drawing.Point(12, 134);
		this.grp_working.Name = "grp_working";
		this.grp_working.Size = new System.Drawing.Size(210, 115);
		this.grp_working.TabIndex = 0;
		this.grp_working.TabStop = false;
		this.grp_working.UseWaitCursor = true;
		this.grp_working.Visible = false;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(67, 62);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(67, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Space - stop";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label2.UseWaitCursor = true;
		this.lb_output.AutoSize = true;
		this.lb_output.Location = new System.Drawing.Point(67, 25);
		this.lb_output.Name = "lb_output";
		this.lb_output.Size = new System.Drawing.Size(55, 13);
		this.lb_output.TabIndex = 0;
		this.lb_output.Text = "12345678";
		this.lb_output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lb_output.UseWaitCursor = true;
		this.trbr_time.LargeChange = 1;
		this.trbr_time.Location = new System.Drawing.Point(70, 48);
		this.trbr_time.Maximum = 4;
		this.trbr_time.Name = "trbr_time";
		this.trbr_time.Size = new System.Drawing.Size(152, 45);
		this.trbr_time.TabIndex = 3;
		this.trbr_time.Value = 2;
		this.trbr_time.Scroll += new System.EventHandler(changeInterval);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(14, 45);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(42, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Interval";
		this.lb_time.AutoSize = true;
		this.lb_time.Location = new System.Drawing.Point(14, 69);
		this.lb_time.Name = "lb_time";
		this.lb_time.Size = new System.Drawing.Size(32, 13);
		this.lb_time.TabIndex = 0;
		this.lb_time.Text = "5 min";
		this.chbx_keepAwake.AutoSize = true;
		this.chbx_keepAwake.Location = new System.Drawing.Point(56, 12);
		this.chbx_keepAwake.Name = "chbx_keepAwake";
		this.chbx_keepAwake.Size = new System.Drawing.Size(130, 17);
		this.chbx_keepAwake.TabIndex = 2;
		this.chbx_keepAwake.Text = "Keep Screen Awake?";
		this.chbx_keepAwake.UseVisualStyleBackColor = true;
		this.chbx_keepAwake.CheckedChanged += new System.EventHandler(changeKeepAwake);
		this.btn_func.Location = new System.Drawing.Point(82, 99);
		this.btn_func.Name = "btn_func";
		this.btn_func.Size = new System.Drawing.Size(75, 23);
		this.btn_func.TabIndex = 4;
		this.btn_func.Text = "Start";
		this.btn_func.UseVisualStyleBackColor = true;
		this.btn_func.Click += new System.EventHandler(clicked);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(67, 89);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(77, 13);
		this.label3.TabIndex = 2;
		this.label3.Text = "Escape - close";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.UseWaitCursor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.ClientSize = new System.Drawing.Size(234, 261);
		base.Controls.Add(this.btn_func);
		base.Controls.Add(this.chbx_keepAwake);
		base.Controls.Add(this.lb_time);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.trbr_time);
		base.Controls.Add(this.grp_working);
		base.KeyPreview = true;
		base.Name = "frm_BusyIdle";
		this.Text = "Busy Idle";
		base.Load += new System.EventHandler(onLoad);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_BusyIdle_KeyDown);
		this.grp_working.ResumeLayout(false);
		this.grp_working.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.trbr_time).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}

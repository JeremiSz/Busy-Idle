
namespace busyIdle
{
    partial class frm_BusyIdle
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
            this.chbx_On = new System.Windows.Forms.CheckBox();
            this.grp_working = new System.Windows.Forms.GroupBox();
            this.lb_output = new System.Windows.Forms.Label();
            this.trbr_time = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.grp_working.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbr_time)).BeginInit();
            this.SuspendLayout();
            // 
            // chbx_On
            // 
            this.chbx_On.AutoSize = true;
            this.chbx_On.Location = new System.Drawing.Point(92, 27);
            this.chbx_On.Name = "chbx_On";
            this.chbx_On.Size = new System.Drawing.Size(46, 17);
            this.chbx_On.TabIndex = 1;
            this.chbx_On.Text = "On?";
            this.chbx_On.UseVisualStyleBackColor = true;
            this.chbx_On.CheckedChanged += new System.EventHandler(this.onChangedTick);
            // 
            // grp_working
            // 
            this.grp_working.CausesValidation = false;
            this.grp_working.Controls.Add(this.lb_output);
            this.grp_working.Location = new System.Drawing.Point(13, 128);
            this.grp_working.Name = "grp_working";
            this.grp_working.Size = new System.Drawing.Size(216, 97);
            this.grp_working.TabIndex = 0;
            this.grp_working.TabStop = false;
            this.grp_working.UseWaitCursor = true;
            this.grp_working.Visible = false;
            // 
            // lb_output
            // 
            this.lb_output.AutoSize = true;
            this.lb_output.Location = new System.Drawing.Point(90, 46);
            this.lb_output.Name = "lb_output";
            this.lb_output.Size = new System.Drawing.Size(0, 13);
            this.lb_output.TabIndex = 0;
            this.lb_output.UseWaitCursor = true;
            // 
            // trbr_time
            // 
            this.trbr_time.LargeChange = 1;
            this.trbr_time.Location = new System.Drawing.Point(71, 80);
            this.trbr_time.Maximum = 4;
            this.trbr_time.Name = "trbr_time";
            this.trbr_time.Size = new System.Drawing.Size(152, 45);
            this.trbr_time.TabIndex = 3;
            this.trbr_time.Value = 2;
            this.trbr_time.Scroll += new System.EventHandler(this.changeInterval);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(15, 101);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(32, 13);
            this.lb_time.TabIndex = 0;
            this.lb_time.Text = "5 min";
            // 
            // frm_BusyIdle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(248, 243);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbr_time);
            this.Controls.Add(this.grp_working);
            this.Controls.Add(this.chbx_On);
            this.Name = "frm_BusyIdle";
            this.Text = "Busy Idle";
            this.Load += new System.EventHandler(this.frm_BusyIdle_Load);
            this.Click += new System.EventHandler(this.onClick);
            this.grp_working.ResumeLayout(false);
            this.grp_working.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbr_time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbx_On;
        private System.Windows.Forms.GroupBox grp_working;
        private System.Windows.Forms.Label lb_output;
        private System.Windows.Forms.TrackBar trbr_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_time;
    }
}



 namespace ConsoleApplication4
   
{
    partial class user_controle
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
            this.enableKeyboard = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.onOff = new System.Windows.Forms.Button();
            this.qlt_ud = new System.Windows.Forms.NumericUpDown();
            this.compressionUpDown = new System.Windows.Forms.NumericUpDown();
            this.frameUpDown = new System.Windows.Forms.NumericUpDown();
            this.enableMouse = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.backg = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlt_ud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backg)).BeginInit();
            this.SuspendLayout();
            // 
            // enableKeyboard
            // 
            this.enableKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enableKeyboard.AutoSize = true;
            this.enableKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableKeyboard.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.enableKeyboard.Location = new System.Drawing.Point(672, 3);
            this.enableKeyboard.Name = "enableKeyboard";
            this.enableKeyboard.Size = new System.Drawing.Size(122, 21);
            this.enableKeyboard.TabIndex = 5;
            this.enableKeyboard.Text = "Enable Keyboard";
            this.enableKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableKeyboard.UseVisualStyleBackColor = true;
            this.enableKeyboard.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.backg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 462);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tableLayoutPanel3.ColumnCount = 16;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.81343F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.18657F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.onOff, 15, 0);
            this.tableLayoutPanel3.Controls.Add(this.qlt_ud, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.compressionUpDown, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.frameUpDown, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.enableMouse, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.enableKeyboard, 11, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 12, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 14, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 430);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(974, 27);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quality :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // onOff
            // 
            this.onOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onOff.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.onOff.Location = new System.Drawing.Point(869, 0);
            this.onOff.Margin = new System.Windows.Forms.Padding(0);
            this.onOff.Name = "onOff";
            this.onOff.Size = new System.Drawing.Size(105, 27);
            this.onOff.TabIndex = 3;
            this.onOff.Text = "Stop";
            this.onOff.UseVisualStyleBackColor = true;
            this.onOff.Click += new System.EventHandler(this.onOff_Click_1);
            // 
            // qlt_ud
            // 
            this.qlt_ud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.qlt_ud.Location = new System.Drawing.Point(218, 3);
            this.qlt_ud.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.qlt_ud.Name = "qlt_ud";
            this.qlt_ud.Size = new System.Drawing.Size(43, 20);
            this.qlt_ud.TabIndex = 1;
            this.qlt_ud.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.qlt_ud.ValueChanged += new System.EventHandler(this.qlt_ud_ValueChanged);
            // 
            // compressionUpDown
            // 
            this.compressionUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.compressionUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.compressionUpDown.Location = new System.Drawing.Point(71, 3);
            this.compressionUpDown.Name = "compressionUpDown";
            this.compressionUpDown.Size = new System.Drawing.Size(43, 20);
            this.compressionUpDown.TabIndex = 1;
            this.compressionUpDown.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.compressionUpDown.ValueChanged += new System.EventHandler(this.compression_ud_ValueChanged);
            // 
            // frameUpDown
            // 
            this.frameUpDown.DecimalPlaces = 1;
            this.frameUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.frameUpDown.Location = new System.Drawing.Point(355, 3);
            this.frameUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.frameUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.frameUpDown.Name = "frameUpDown";
            this.frameUpDown.Size = new System.Drawing.Size(46, 20);
            this.frameUpDown.TabIndex = 1;
            this.frameUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameUpDown.ValueChanged += new System.EventHandler(this.frameUpDown_ValueChanged);
            // 
            // enableMouse
            // 
            this.enableMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enableMouse.AutoSize = true;
            this.enableMouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableMouse.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.enableMouse.Location = new System.Drawing.Point(542, 3);
            this.enableMouse.Name = "enableMouse";
            this.enableMouse.Size = new System.Drawing.Size(114, 21);
            this.enableMouse.TabIndex = 4;
            this.enableMouse.Text = "Enable Mouse";
            this.enableMouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableMouse.UseVisualStyleBackColor = true;
            this.enableMouse.CheckedChanged += new System.EventHandler(this.enableMouse_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Location = new System.Drawing.Point(120, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Compression :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(267, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "frames/sec : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(404, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 27);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(534, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 27);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(797, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 27);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(864, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 27);
            this.panel4.TabIndex = 9;
            // 
            // backg
            // 
            this.backg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.backg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.backg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backg.Location = new System.Drawing.Point(5, 5);
            this.backg.Margin = new System.Windows.Forms.Padding(5);
            this.backg.Name = "backg";
            this.backg.Size = new System.Drawing.Size(974, 420);
            this.backg.TabIndex = 0;
            this.backg.TabStop = false;
            this.backg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backg_MouseClick);
            this.backg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.backg_MouseDoubleClick);
            // 
            // user_controle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "user_controle";
            this.Text = "Navigate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.user_controle_FormClosing);
            this.Load += new System.EventHandler(this.user_controle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.user_controle_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.user_controle_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlt_ud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox enableKeyboard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox backg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown compressionUpDown;
        private System.Windows.Forms.NumericUpDown frameUpDown;
        private System.Windows.Forms.CheckBox enableMouse;
        private System.Windows.Forms.Button onOff;
        private System.Windows.Forms.NumericUpDown qlt_ud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
       

    }
}
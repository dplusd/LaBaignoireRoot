namespace ClassProducer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPlayStart = new System.Windows.Forms.Button();
            this.btnPlayEnd = new System.Windows.Forms.Button();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.btnSetEnd = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtEndPosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstParagraphs = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rtbText.Location = new System.Drawing.Point(0, 55);
            this.rtbText.Name = "rtbText";
            this.rtbText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbText.Size = new System.Drawing.Size(775, 499);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Player);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 47);
            this.panel1.TabIndex = 1;
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(0, 0);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(775, 47);
            this.Player.TabIndex = 0;
            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 55);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPlayStart);
            this.panel3.Controls.Add(this.btnPlayEnd);
            this.panel3.Controls.Add(this.btnSetStart);
            this.panel3.Controls.Add(this.btnSetEnd);
            this.panel3.Controls.Add(this.btnPlay);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.txtEndPosition);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtStartPosition);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lstParagraphs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(775, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 601);
            this.panel3.TabIndex = 3;
            // 
            // btnPlayStart
            // 
            this.btnPlayStart.Location = new System.Drawing.Point(21, 385);
            this.btnPlayStart.Name = "btnPlayStart";
            this.btnPlayStart.Size = new System.Drawing.Size(75, 23);
            this.btnPlayStart.TabIndex = 10;
            this.btnPlayStart.Text = "Play Start";
            this.btnPlayStart.UseVisualStyleBackColor = true;
            this.btnPlayStart.Click += new System.EventHandler(this.btnPlayStart_Click);
            // 
            // btnPlayEnd
            // 
            this.btnPlayEnd.Location = new System.Drawing.Point(102, 385);
            this.btnPlayEnd.Name = "btnPlayEnd";
            this.btnPlayEnd.Size = new System.Drawing.Size(75, 23);
            this.btnPlayEnd.TabIndex = 9;
            this.btnPlayEnd.Text = "Play End";
            this.btnPlayEnd.UseVisualStyleBackColor = true;
            this.btnPlayEnd.Click += new System.EventHandler(this.btnPlayEnd_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.Location = new System.Drawing.Point(21, 356);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(75, 23);
            this.btnSetStart.TabIndex = 8;
            this.btnSetStart.Text = "Set Start";
            this.btnSetStart.UseVisualStyleBackColor = true;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // btnSetEnd
            // 
            this.btnSetEnd.Location = new System.Drawing.Point(102, 356);
            this.btnSetEnd.Name = "btnSetEnd";
            this.btnSetEnd.Size = new System.Drawing.Size(75, 23);
            this.btnSetEnd.TabIndex = 7;
            this.btnSetEnd.Text = "Set End";
            this.btnSetEnd.UseVisualStyleBackColor = true;
            this.btnSetEnd.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(102, 327);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Taatik";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(21, 327);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtEndPosition
            // 
            this.txtEndPosition.Location = new System.Drawing.Point(119, 290);
            this.txtEndPosition.Name = "txtEndPosition";
            this.txtEndPosition.Size = new System.Drawing.Size(47, 20);
            this.txtEndPosition.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Position";
            // 
            // txtStartPosition
            // 
            this.txtStartPosition.Location = new System.Drawing.Point(119, 264);
            this.txtStartPosition.Name = "txtStartPosition";
            this.txtStartPosition.Size = new System.Drawing.Size(47, 20);
            this.txtStartPosition.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Position";
            // 
            // lstParagraphs
            // 
            this.lstParagraphs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstParagraphs.FormattingEnabled = true;
            this.lstParagraphs.Location = new System.Drawing.Point(0, 0);
            this.lstParagraphs.Name = "lstParagraphs";
            this.lstParagraphs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstParagraphs.Size = new System.Drawing.Size(200, 251);
            this.lstParagraphs.TabIndex = 0;
            this.lstParagraphs.SelectedIndexChanged += new System.EventHandler(this.lstParagraphs_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 601);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtEndPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstParagraphs;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnSetEnd;
        private System.Windows.Forms.Button btnPlayStart;
        private System.Windows.Forms.Button btnPlayEnd;
    }
}


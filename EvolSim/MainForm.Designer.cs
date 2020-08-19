namespace EvolSim
{
    partial class MainForm
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
            this.SimulationPanel = new System.Windows.Forms.Panel();
            this.SimulationControlPanel = new System.Windows.Forms.Panel();
            this.BtnWorldGenHM = new System.Windows.Forms.Button();
            this.BtnWorldGenGaia = new System.Windows.Forms.Button();
            this.CycleSleep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.WeatherChangePeriod = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.WeatherSin = new System.Windows.Forms.RadioButton();
            this.WeatherStatic = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.MinimalCreatureAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MapGenProgress = new System.Windows.Forms.ProgressBar();
            this.WorldHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.WorldWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnWorldGenCA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CreatureControlPanel = new System.Windows.Forms.Panel();
            this.SimulationControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CycleSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherChangePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimalCreatureAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // SimulationPanel
            // 
            this.SimulationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SimulationPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SimulationPanel.Location = new System.Drawing.Point(12, 12);
            this.SimulationPanel.Name = "SimulationPanel";
            this.SimulationPanel.Size = new System.Drawing.Size(500, 500);
            this.SimulationPanel.TabIndex = 0;
            this.SimulationPanel.Click += new System.EventHandler(this.SimulationField_Click);
            // 
            // SimulationControlPanel
            // 
            this.SimulationControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SimulationControlPanel.Controls.Add(this.BtnWorldGenHM);
            this.SimulationControlPanel.Controls.Add(this.BtnWorldGenGaia);
            this.SimulationControlPanel.Controls.Add(this.CycleSleep);
            this.SimulationControlPanel.Controls.Add(this.label8);
            this.SimulationControlPanel.Controls.Add(this.WeatherChangePeriod);
            this.SimulationControlPanel.Controls.Add(this.label7);
            this.SimulationControlPanel.Controls.Add(this.radioButton1);
            this.SimulationControlPanel.Controls.Add(this.WeatherSin);
            this.SimulationControlPanel.Controls.Add(this.WeatherStatic);
            this.SimulationControlPanel.Controls.Add(this.label6);
            this.SimulationControlPanel.Controls.Add(this.MinimalCreatureAmount);
            this.SimulationControlPanel.Controls.Add(this.label5);
            this.SimulationControlPanel.Controls.Add(this.label4);
            this.SimulationControlPanel.Controls.Add(this.MapGenProgress);
            this.SimulationControlPanel.Controls.Add(this.WorldHeight);
            this.SimulationControlPanel.Controls.Add(this.label3);
            this.SimulationControlPanel.Controls.Add(this.WorldWidth);
            this.SimulationControlPanel.Controls.Add(this.label2);
            this.SimulationControlPanel.Controls.Add(this.BtnWorldGenCA);
            this.SimulationControlPanel.Controls.Add(this.label1);
            this.SimulationControlPanel.Location = new System.Drawing.Point(518, 12);
            this.SimulationControlPanel.Name = "SimulationControlPanel";
            this.SimulationControlPanel.Size = new System.Drawing.Size(329, 245);
            this.SimulationControlPanel.TabIndex = 3;
            // 
            // BtnWorldGenHM
            // 
            this.BtnWorldGenHM.Location = new System.Drawing.Point(6, 77);
            this.BtnWorldGenHM.Name = "BtnWorldGenHM";
            this.BtnWorldGenHM.Size = new System.Drawing.Size(100, 23);
            this.BtnWorldGenHM.TabIndex = 3;
            this.BtnWorldGenHM.Text = "Height Map";
            this.BtnWorldGenHM.UseVisualStyleBackColor = true;
            this.BtnWorldGenHM.Click += new System.EventHandler(this.BtnWorldGenHM_Click);
            // 
            // BtnWorldGenGaia
            // 
            this.BtnWorldGenGaia.Location = new System.Drawing.Point(224, 77);
            this.BtnWorldGenGaia.Name = "BtnWorldGenGaia";
            this.BtnWorldGenGaia.Size = new System.Drawing.Size(100, 23);
            this.BtnWorldGenGaia.TabIndex = 5;
            this.BtnWorldGenGaia.Text = "Gaia";
            this.BtnWorldGenGaia.UseVisualStyleBackColor = true;
            this.BtnWorldGenGaia.Click += new System.EventHandler(this.BtnWorldGenGaia_Click);
            // 
            // CycleSleep
            // 
            this.CycleSleep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CycleSleep.Location = new System.Drawing.Point(176, 214);
            this.CycleSleep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CycleSleep.Name = "CycleSleep";
            this.CycleSleep.Size = new System.Drawing.Size(149, 22);
            this.CycleSleep.TabIndex = 15;
            this.CycleSleep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(4, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sleep after cycle (ms)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WeatherChangePeriod
            // 
            this.WeatherChangePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WeatherChangePeriod.Location = new System.Drawing.Point(176, 186);
            this.WeatherChangePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeatherChangePeriod.Name = "WeatherChangePeriod";
            this.WeatherChangePeriod.Size = new System.Drawing.Size(148, 22);
            this.WeatherChangePeriod.TabIndex = 10;
            this.WeatherChangePeriod.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(4, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cycles / weather change";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(259, 163);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.Text = "Random";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // WeatherSin
            // 
            this.WeatherSin.AutoSize = true;
            this.WeatherSin.Location = new System.Drawing.Point(180, 163);
            this.WeatherSin.Name = "WeatherSin";
            this.WeatherSin.Size = new System.Drawing.Size(73, 17);
            this.WeatherSin.TabIndex = 8;
            this.WeatherSin.Text = "Sinusoidal";
            this.WeatherSin.UseVisualStyleBackColor = true;
            // 
            // WeatherStatic
            // 
            this.WeatherStatic.AutoSize = true;
            this.WeatherStatic.Checked = true;
            this.WeatherStatic.Location = new System.Drawing.Point(122, 163);
            this.WeatherStatic.Name = "WeatherStatic";
            this.WeatherStatic.Size = new System.Drawing.Size(52, 17);
            this.WeatherStatic.TabIndex = 7;
            this.WeatherStatic.TabStop = true;
            this.WeatherStatic.Text = "Static";
            this.WeatherStatic.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(4, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Weather:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MinimalCreatureAmount
            // 
            this.MinimalCreatureAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinimalCreatureAmount.Location = new System.Drawing.Point(176, 135);
            this.MinimalCreatureAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinimalCreatureAmount.Name = "MinimalCreatureAmount";
            this.MinimalCreatureAmount.Size = new System.Drawing.Size(148, 22);
            this.MinimalCreatureAmount.TabIndex = 6;
            this.MinimalCreatureAmount.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Minimal creature amount:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Progress:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MapGenProgress
            // 
            this.MapGenProgress.Location = new System.Drawing.Point(88, 106);
            this.MapGenProgress.Name = "MapGenProgress";
            this.MapGenProgress.Size = new System.Drawing.Size(236, 23);
            this.MapGenProgress.Step = 1;
            this.MapGenProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MapGenProgress.TabIndex = 5;
            // 
            // WorldHeight
            // 
            this.WorldHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorldHeight.Location = new System.Drawing.Point(209, 26);
            this.WorldHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WorldHeight.Name = "WorldHeight";
            this.WorldHeight.Size = new System.Drawing.Size(115, 22);
            this.WorldHeight.TabIndex = 2;
            this.WorldHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "World size: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorldWidth
            // 
            this.WorldWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorldWidth.Location = new System.Drawing.Point(88, 26);
            this.WorldWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WorldWidth.Name = "WorldWidth";
            this.WorldWidth.Size = new System.Drawing.Size(115, 22);
            this.WorldWidth.TabIndex = 1;
            this.WorldWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Generate world using:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnWorldGenCA
            // 
            this.BtnWorldGenCA.Location = new System.Drawing.Point(112, 77);
            this.BtnWorldGenCA.Name = "BtnWorldGenCA";
            this.BtnWorldGenCA.Size = new System.Drawing.Size(106, 23);
            this.BtnWorldGenCA.TabIndex = 4;
            this.BtnWorldGenCA.Text = "Cellular automata";
            this.BtnWorldGenCA.UseVisualStyleBackColor = true;
            this.BtnWorldGenCA.Click += new System.EventHandler(this.BtnWorldGenCA_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulation controls";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreatureControlPanel
            // 
            this.CreatureControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CreatureControlPanel.Location = new System.Drawing.Point(518, 263);
            this.CreatureControlPanel.Name = "CreatureControlPanel";
            this.CreatureControlPanel.Size = new System.Drawing.Size(329, 249);
            this.CreatureControlPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(856, 526);
            this.Controls.Add(this.CreatureControlPanel);
            this.Controls.Add(this.SimulationControlPanel);
            this.Controls.Add(this.SimulationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Evol Sim";
            this.SimulationControlPanel.ResumeLayout(false);
            this.SimulationControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CycleSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherChangePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimalCreatureAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SimulationPanel;
        private System.Windows.Forms.Panel SimulationControlPanel;
        private System.Windows.Forms.Panel CreatureControlPanel;
        private System.Windows.Forms.NumericUpDown WorldHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown WorldWidth;
        private System.Windows.Forms.Button BtnWorldGenHM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnWorldGenCA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar MapGenProgress;
        private System.Windows.Forms.NumericUpDown MinimalCreatureAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown WeatherChangePeriod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton WeatherSin;
        private System.Windows.Forms.RadioButton WeatherStatic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown CycleSleep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnWorldGenGaia;
    }
}


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
            this.components = new System.ComponentModel.Container();
            this.SimulationPanel = new System.Windows.Forms.Panel();
            this.SimulationControlPanel = new System.Windows.Forms.Panel();
            this.WeatherAmplitude = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.StatusIndicator = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StatusSwitchButton = new System.Windows.Forms.Button();
            this.BtnWorldGenHM = new System.Windows.Forms.Button();
            this.BtnWorldGenGaia = new System.Windows.Forms.Button();
            this.CycleSleep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.WeatherChangePeriod = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.WeatherRandom = new System.Windows.Forms.RadioButton();
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
            this.FieldControlPanel = new System.Windows.Forms.Panel();
            this.TileMaxCalories = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.TileTemperature = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TileCalories = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.TileInitialTemperature = new System.Windows.Forms.NumericUpDown();
            this.TileCoordinates = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TileHeight = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TileTemperatureOffset = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.GraphicTimer = new System.Windows.Forms.Timer(this.components);
            this.CreatureControlPanel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.SimulationControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CycleSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherChangePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimalCreatureAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldWidth)).BeginInit();
            this.FieldControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileCalories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileInitialTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileTemperatureOffset)).BeginInit();
            this.CreatureControlPanel.SuspendLayout();
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
            this.SimulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SimulationPanel_Paint);
            // 
            // SimulationControlPanel
            // 
            this.SimulationControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SimulationControlPanel.Controls.Add(this.WeatherAmplitude);
            this.SimulationControlPanel.Controls.Add(this.label10);
            this.SimulationControlPanel.Controls.Add(this.StatusIndicator);
            this.SimulationControlPanel.Controls.Add(this.label9);
            this.SimulationControlPanel.Controls.Add(this.StatusSwitchButton);
            this.SimulationControlPanel.Controls.Add(this.BtnWorldGenHM);
            this.SimulationControlPanel.Controls.Add(this.BtnWorldGenGaia);
            this.SimulationControlPanel.Controls.Add(this.CycleSleep);
            this.SimulationControlPanel.Controls.Add(this.label8);
            this.SimulationControlPanel.Controls.Add(this.WeatherChangePeriod);
            this.SimulationControlPanel.Controls.Add(this.label7);
            this.SimulationControlPanel.Controls.Add(this.WeatherRandom);
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
            this.SimulationControlPanel.Size = new System.Drawing.Size(329, 300);
            this.SimulationControlPanel.TabIndex = 3;
            // 
            // WeatherAmplitude
            // 
            this.WeatherAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WeatherAmplitude.Location = new System.Drawing.Point(176, 185);
            this.WeatherAmplitude.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.WeatherAmplitude.Name = "WeatherAmplitude";
            this.WeatherAmplitude.Size = new System.Drawing.Size(148, 22);
            this.WeatherAmplitude.TabIndex = 19;
            this.WeatherAmplitude.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.WeatherAmplitude.ValueChanged += new System.EventHandler(this.WeatherAmplitude_ValueChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(4, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Weather amplitude";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusIndicator
            // 
            this.StatusIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusIndicator.Location = new System.Drawing.Point(109, 269);
            this.StatusIndicator.Name = "StatusIndicator";
            this.StatusIndicator.Size = new System.Drawing.Size(106, 23);
            this.StatusIndicator.TabIndex = 18;
            this.StatusIndicator.Text = "Not started";
            this.StatusIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(4, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Status:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusSwitchButton
            // 
            this.StatusSwitchButton.Location = new System.Drawing.Point(224, 269);
            this.StatusSwitchButton.Name = "StatusSwitchButton";
            this.StatusSwitchButton.Size = new System.Drawing.Size(100, 23);
            this.StatusSwitchButton.TabIndex = 16;
            this.StatusSwitchButton.Text = "Start / Pause";
            this.StatusSwitchButton.UseVisualStyleBackColor = true;
            this.StatusSwitchButton.Click += new System.EventHandler(this.StatusSwitchButton_Click);
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
            this.CycleSleep.Location = new System.Drawing.Point(176, 241);
            this.CycleSleep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CycleSleep.Name = "CycleSleep";
            this.CycleSleep.Size = new System.Drawing.Size(148, 22);
            this.CycleSleep.TabIndex = 15;
            this.CycleSleep.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.CycleSleep.ValueChanged += new System.EventHandler(this.CycleSleep_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(3, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sleep after cycle (ms)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WeatherChangePeriod
            // 
            this.WeatherChangePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WeatherChangePeriod.Location = new System.Drawing.Point(176, 213);
            this.WeatherChangePeriod.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WeatherChangePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeatherChangePeriod.Name = "WeatherChangePeriod";
            this.WeatherChangePeriod.Size = new System.Drawing.Size(148, 22);
            this.WeatherChangePeriod.TabIndex = 10;
            this.WeatherChangePeriod.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.WeatherChangePeriod.ValueChanged += new System.EventHandler(this.WeatherChangePeriod_ValueChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(4, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cycles / weather change";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WeatherRandom
            // 
            this.WeatherRandom.AutoSize = true;
            this.WeatherRandom.Location = new System.Drawing.Point(259, 163);
            this.WeatherRandom.Name = "WeatherRandom";
            this.WeatherRandom.Size = new System.Drawing.Size(65, 17);
            this.WeatherRandom.TabIndex = 9;
            this.WeatherRandom.Text = "Random";
            this.WeatherRandom.UseVisualStyleBackColor = true;
            this.WeatherRandom.CheckedChanged += new System.EventHandler(this.WeatherChanged);
            // 
            // WeatherSin
            // 
            this.WeatherSin.AutoSize = true;
            this.WeatherSin.Checked = true;
            this.WeatherSin.Location = new System.Drawing.Point(180, 163);
            this.WeatherSin.Name = "WeatherSin";
            this.WeatherSin.Size = new System.Drawing.Size(73, 17);
            this.WeatherSin.TabIndex = 8;
            this.WeatherSin.TabStop = true;
            this.WeatherSin.Text = "Sinusoidal";
            this.WeatherSin.UseVisualStyleBackColor = true;
            this.WeatherSin.CheckedChanged += new System.EventHandler(this.WeatherChanged);
            // 
            // WeatherStatic
            // 
            this.WeatherStatic.AutoSize = true;
            this.WeatherStatic.Location = new System.Drawing.Point(122, 163);
            this.WeatherStatic.Name = "WeatherStatic";
            this.WeatherStatic.Size = new System.Drawing.Size(52, 17);
            this.WeatherStatic.TabIndex = 7;
            this.WeatherStatic.Text = "Static";
            this.WeatherStatic.UseVisualStyleBackColor = true;
            this.WeatherStatic.CheckedChanged += new System.EventHandler(this.WeatherChanged);
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
            this.MinimalCreatureAmount.ValueChanged += new System.EventHandler(this.MinimalCreatureAmount_ValueChanged);
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
            this.WorldHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
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
            this.WorldWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
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
            // FieldControlPanel
            // 
            this.FieldControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FieldControlPanel.Controls.Add(this.TileMaxCalories);
            this.FieldControlPanel.Controls.Add(this.label20);
            this.FieldControlPanel.Controls.Add(this.TileTemperature);
            this.FieldControlPanel.Controls.Add(this.label18);
            this.FieldControlPanel.Controls.Add(this.TileCalories);
            this.FieldControlPanel.Controls.Add(this.label17);
            this.FieldControlPanel.Controls.Add(this.TileInitialTemperature);
            this.FieldControlPanel.Controls.Add(this.TileCoordinates);
            this.FieldControlPanel.Controls.Add(this.label13);
            this.FieldControlPanel.Controls.Add(this.TileHeight);
            this.FieldControlPanel.Controls.Add(this.label12);
            this.FieldControlPanel.Controls.Add(this.label14);
            this.FieldControlPanel.Controls.Add(this.label11);
            this.FieldControlPanel.Controls.Add(this.TileTemperatureOffset);
            this.FieldControlPanel.Controls.Add(this.label15);
            this.FieldControlPanel.Location = new System.Drawing.Point(518, 318);
            this.FieldControlPanel.Name = "FieldControlPanel";
            this.FieldControlPanel.Size = new System.Drawing.Size(329, 194);
            this.FieldControlPanel.TabIndex = 4;
            // 
            // TileMaxCalories
            // 
            this.TileMaxCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileMaxCalories.Location = new System.Drawing.Point(175, 59);
            this.TileMaxCalories.Name = "TileMaxCalories";
            this.TileMaxCalories.Size = new System.Drawing.Size(148, 23);
            this.TileMaxCalories.TabIndex = 32;
            this.TileMaxCalories.Text = "N/A";
            this.TileMaxCalories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(4, 59);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 23);
            this.label20.TabIndex = 31;
            this.label20.Text = "Max. calories:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TileTemperature
            // 
            this.TileTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileTemperature.Location = new System.Drawing.Point(175, 40);
            this.TileTemperature.Name = "TileTemperature";
            this.TileTemperature.Size = new System.Drawing.Size(148, 23);
            this.TileTemperature.TabIndex = 30;
            this.TileTemperature.Text = "N/A";
            this.TileTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(3, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 23);
            this.label18.TabIndex = 29;
            this.label18.Text = "Temperature:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TileCalories
            // 
            this.TileCalories.Enabled = false;
            this.TileCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileCalories.Location = new System.Drawing.Point(176, 167);
            this.TileCalories.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TileCalories.Name = "TileCalories";
            this.TileCalories.Size = new System.Drawing.Size(148, 22);
            this.TileCalories.TabIndex = 27;
            this.TileCalories.ValueChanged += new System.EventHandler(this.TileCalories_ValueChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(3, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(166, 23);
            this.label17.TabIndex = 28;
            this.label17.Text = "Calories";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TileInitialTemperature
            // 
            this.TileInitialTemperature.Enabled = false;
            this.TileInitialTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileInitialTemperature.Location = new System.Drawing.Point(176, 83);
            this.TileInitialTemperature.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TileInitialTemperature.Name = "TileInitialTemperature";
            this.TileInitialTemperature.Size = new System.Drawing.Size(148, 22);
            this.TileInitialTemperature.TabIndex = 25;
            this.TileInitialTemperature.ValueChanged += new System.EventHandler(this.TileInitialTemperature_ValueChanged);
            // 
            // TileCoordinates
            // 
            this.TileCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileCoordinates.Location = new System.Drawing.Point(175, 21);
            this.TileCoordinates.Name = "TileCoordinates";
            this.TileCoordinates.Size = new System.Drawing.Size(148, 23);
            this.TileCoordinates.TabIndex = 22;
            this.TileCoordinates.Text = "N/A";
            this.TileCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(4, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 23);
            this.label13.TabIndex = 26;
            this.label13.Text = "Initial temperature";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TileHeight
            // 
            this.TileHeight.Enabled = false;
            this.TileHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileHeight.Location = new System.Drawing.Point(176, 139);
            this.TileHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TileHeight.Name = "TileHeight";
            this.TileHeight.Size = new System.Drawing.Size(148, 22);
            this.TileHeight.TabIndex = 24;
            this.TileHeight.ValueChanged += new System.EventHandler(this.TileHeight_ValueChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(4, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 23);
            this.label12.TabIndex = 21;
            this.label12.Text = "Coordinates:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(3, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 23);
            this.label14.TabIndex = 23;
            this.label14.Text = "Height";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(321, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Selected field controls";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TileTemperatureOffset
            // 
            this.TileTemperatureOffset.Enabled = false;
            this.TileTemperatureOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TileTemperatureOffset.Location = new System.Drawing.Point(176, 111);
            this.TileTemperatureOffset.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TileTemperatureOffset.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.TileTemperatureOffset.Name = "TileTemperatureOffset";
            this.TileTemperatureOffset.Size = new System.Drawing.Size(148, 22);
            this.TileTemperatureOffset.TabIndex = 21;
            this.TileTemperatureOffset.ValueChanged += new System.EventHandler(this.TileTemperatureOffset_ValueChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(3, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 23);
            this.label15.TabIndex = 22;
            this.label15.Text = "Temperature offset";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GraphicTimer
            // 
            this.GraphicTimer.Interval = 8;
            this.GraphicTimer.Tick += new System.EventHandler(this.GraphicTimer_Tick);
            // 
            // CreatureControlPanel
            // 
            this.CreatureControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CreatureControlPanel.Controls.Add(this.label16);
            this.CreatureControlPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreatureControlPanel.Location = new System.Drawing.Point(12, 518);
            this.CreatureControlPanel.Name = "CreatureControlPanel";
            this.CreatureControlPanel.Size = new System.Drawing.Size(835, 81);
            this.CreatureControlPanel.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(321, 23);
            this.label16.TabIndex = 33;
            this.label16.Text = "Selected creature controls";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(856, 611);
            this.Controls.Add(this.CreatureControlPanel);
            this.Controls.Add(this.FieldControlPanel);
            this.Controls.Add(this.SimulationControlPanel);
            this.Controls.Add(this.SimulationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Evol Sim";
            this.SimulationControlPanel.ResumeLayout(false);
            this.SimulationControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CycleSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherChangePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimalCreatureAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldWidth)).EndInit();
            this.FieldControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TileCalories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileInitialTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileTemperatureOffset)).EndInit();
            this.CreatureControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SimulationPanel;
        private System.Windows.Forms.Panel SimulationControlPanel;
        private System.Windows.Forms.Panel FieldControlPanel;
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
        private System.Windows.Forms.RadioButton WeatherRandom;
        private System.Windows.Forms.RadioButton WeatherSin;
        private System.Windows.Forms.RadioButton WeatherStatic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown CycleSleep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnWorldGenGaia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button StatusSwitchButton;
        private System.Windows.Forms.Label StatusIndicator;
        private System.Windows.Forms.Timer GraphicTimer;
        private System.Windows.Forms.NumericUpDown WeatherAmplitude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label TileCoordinates;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown TileCalories;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown TileInitialTemperature;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown TileHeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown TileTemperatureOffset;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label TileMaxCalories;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label TileTemperature;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel CreatureControlPanel;
        private System.Windows.Forms.Label label16;
    }
}


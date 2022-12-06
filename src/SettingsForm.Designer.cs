namespace SnowFlakes
{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.label1 = new System.Windows.Forms.Label();
			this.InpCount = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.InpSize = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.BtnColor = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.InpSpeedX = new System.Windows.Forms.NumericUpDown();
			this.InpSpeedXMax = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.InpSpeedYRange = new System.Windows.Forms.NumericUpDown();
			this.InpSpeedY = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.InpD = new System.Windows.Forms.NumericUpDown();
			this.InpForce = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.BtnReset = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnGithub = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.RBPreset0 = new System.Windows.Forms.RadioButton();
			this.RBPreset1 = new System.Windows.Forms.RadioButton();
			this.RBPreset2 = new System.Windows.Forms.RadioButton();
			this.RBPreset3 = new System.Windows.Forms.RadioButton();
			this.RBPreset4 = new System.Windows.Forms.RadioButton();
			this.InpFPS = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.PanelColor = new System.Windows.Forms.Panel();
			this.PanelImg = new System.Windows.Forms.Panel();
			this.BtnImg = new System.Windows.Forms.Button();
			this.PBImg = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.RBimg2 = new System.Windows.Forms.RadioButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.RBimg0 = new System.Windows.Forms.RadioButton();
			this.RBimg1 = new System.Windows.Forms.RadioButton();
			this.RBimg = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.RBimgCirc = new System.Windows.Forms.RadioButton();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.DialogOpenFile = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.InpCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSize)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedXMax)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedYRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedY)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InpForce)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpFPS)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.PanelColor.SuspendLayout();
			this.PanelImg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Количество снежинок";
			// 
			// InpCount
			// 
			this.InpCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpCount.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.InpCount.Location = new System.Drawing.Point(244, 6);
			this.InpCount.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			this.InpCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpCount.Name = "InpCount";
			this.InpCount.Size = new System.Drawing.Size(65, 29);
			this.InpCount.TabIndex = 1;
			this.InpCount.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
			this.InpCount.ValueChanged += new System.EventHandler(this.Count_Change);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Размер снежинок";
			// 
			// InpSize
			// 
			this.InpSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSize.Location = new System.Drawing.Point(244, 41);
			this.InpSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.InpSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpSize.Name = "InpSize";
			this.InpSize.Size = new System.Drawing.Size(65, 29);
			this.InpSize.TabIndex = 2;
			this.InpSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.InpSize.ValueChanged += new System.EventHandler(this.Size_Change);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(3, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "Цвет снежинок";
			// 
			// colorDialog
			// 
			this.colorDialog.FullOpen = true;
			// 
			// BtnColor
			// 
			this.BtnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnColor.BackColor = System.Drawing.Color.LightBlue;
			this.BtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnColor.ForeColor = System.Drawing.Color.Gray;
			this.BtnColor.Location = new System.Drawing.Point(196, 1);
			this.BtnColor.Name = "BtnColor";
			this.BtnColor.Size = new System.Drawing.Size(65, 27);
			this.BtnColor.TabIndex = 2;
			this.BtnColor.UseVisualStyleBackColor = false;
			this.BtnColor.Click += new System.EventHandler(this.Color_Change);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.InpSpeedX);
			this.groupBox1.Controls.Add(this.InpSpeedXMax);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(300, 104);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ветер";
			// 
			// InpSpeedX
			// 
			this.InpSpeedX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpSpeedX.DecimalPlaces = 1;
			this.InpSpeedX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.InpSpeedX.Location = new System.Drawing.Point(229, 63);
			this.InpSpeedX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.InpSpeedX.Name = "InpSpeedX";
			this.InpSpeedX.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedX.TabIndex = 2;
			this.InpSpeedX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpSpeedX.ValueChanged += new System.EventHandler(this.SpeedX_Change);
			// 
			// InpSpeedXMax
			// 
			this.InpSpeedXMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpSpeedXMax.DecimalPlaces = 1;
			this.InpSpeedXMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedXMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.InpSpeedXMax.Location = new System.Drawing.Point(229, 28);
			this.InpSpeedXMax.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.InpSpeedXMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.InpSpeedXMax.Name = "InpSpeedXMax";
			this.InpSpeedXMax.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedXMax.TabIndex = 1;
			this.InpSpeedXMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.InpSpeedXMax.ValueChanged += new System.EventHandler(this.SpeedXMax_Change);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(6, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 21);
			this.label5.TabIndex = 9;
			this.label5.Text = "Вихри";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(6, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 21);
			this.label4.TabIndex = 8;
			this.label4.Text = "Сила";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.InpSpeedYRange);
			this.groupBox2.Controls.Add(this.InpSpeedY);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox2.Location = new System.Drawing.Point(6, 116);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(300, 104);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Падение снежинок";
			// 
			// InpSpeedYRange
			// 
			this.InpSpeedYRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpSpeedYRange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedYRange.Location = new System.Drawing.Point(229, 65);
			this.InpSpeedYRange.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.InpSpeedYRange.Name = "InpSpeedYRange";
			this.InpSpeedYRange.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedYRange.TabIndex = 2;
			this.InpSpeedYRange.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.InpSpeedYRange.ValueChanged += new System.EventHandler(this.SpeedY_Change);
			// 
			// InpSpeedY
			// 
			this.InpSpeedY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpSpeedY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedY.Location = new System.Drawing.Point(229, 30);
			this.InpSpeedY.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.InpSpeedY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpSpeedY.Name = "InpSpeedY";
			this.InpSpeedY.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedY.TabIndex = 1;
			this.InpSpeedY.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.InpSpeedY.ValueChanged += new System.EventHandler(this.SpeedY_Change);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label6.Location = new System.Drawing.Point(6, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(140, 21);
			this.label6.TabIndex = 9;
			this.label6.Text = "Разброс значений";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(6, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 21);
			this.label7.TabIndex = 8;
			this.label7.Text = "Скорость";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.InpD);
			this.groupBox3.Controls.Add(this.InpForce);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox3.Location = new System.Drawing.Point(6, 112);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(300, 108);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Сдувание курсором";
			// 
			// InpD
			// 
			this.InpD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpD.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.InpD.Location = new System.Drawing.Point(229, 63);
			this.InpD.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
			this.InpD.Name = "InpD";
			this.InpD.Size = new System.Drawing.Size(65, 29);
			this.InpD.TabIndex = 2;
			this.InpD.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.InpD.ValueChanged += new System.EventHandler(this.ForceD_Change);
			// 
			// InpForce
			// 
			this.InpForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpForce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpForce.Location = new System.Drawing.Point(229, 28);
			this.InpForce.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.InpForce.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpForce.Name = "InpForce";
			this.InpForce.Size = new System.Drawing.Size(65, 29);
			this.InpForce.TabIndex = 1;
			this.InpForce.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.InpForce.ValueChanged += new System.EventHandler(this.Force_Change);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label8.Location = new System.Drawing.Point(6, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(85, 21);
			this.label8.TabIndex = 9;
			this.label8.Text = "Дальность";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label9.Location = new System.Drawing.Point(6, 30);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 21);
			this.label9.TabIndex = 8;
			this.label9.Text = "Сила";
			// 
			// BtnReset
			// 
			this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnReset.Location = new System.Drawing.Point(7, 372);
			this.BtnReset.Name = "BtnReset";
			this.BtnReset.Size = new System.Drawing.Size(103, 32);
			this.BtnReset.TabIndex = 3;
			this.BtnReset.Text = "Сбросить";
			this.BtnReset.UseVisualStyleBackColor = true;
			this.BtnReset.Click += new System.EventHandler(this.ResetBtn_Click);
			// 
			// BtnOk
			// 
			this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnOk.Location = new System.Drawing.Point(227, 372);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(100, 32);
			this.BtnOk.TabIndex = 2;
			this.BtnOk.Text = "Сохранить";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// BtnGithub
			// 
			this.BtnGithub.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.BtnGithub.BackColor = System.Drawing.Color.Transparent;
			this.BtnGithub.BackgroundImage = global::SnowFlakes.Properties.Resources.github;
			this.BtnGithub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.BtnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnGithub.ForeColor = System.Drawing.Color.Transparent;
			this.BtnGithub.Location = new System.Drawing.Point(151, 374);
			this.BtnGithub.Name = "BtnGithub";
			this.BtnGithub.Size = new System.Drawing.Size(32, 32);
			this.BtnGithub.TabIndex = 4;
			this.BtnGithub.UseVisualStyleBackColor = false;
			this.BtnGithub.Click += new System.EventHandler(this.GitHub_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.flowLayoutPanel1);
			this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox4.Location = new System.Drawing.Point(6, 226);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(300, 100);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Готовые варианты";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.RBPreset0);
			this.flowLayoutPanel1.Controls.Add(this.RBPreset1);
			this.flowLayoutPanel1.Controls.Add(this.RBPreset2);
			this.flowLayoutPanel1.Controls.Add(this.RBPreset3);
			this.flowLayoutPanel1.Controls.Add(this.RBPreset4);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 28);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 66);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// RBPreset0
			// 
			this.RBPreset0.AutoSize = true;
			this.RBPreset0.Location = new System.Drawing.Point(3, 3);
			this.RBPreset0.Name = "RBPreset0";
			this.RBPreset0.Size = new System.Drawing.Size(63, 25);
			this.RBPreset0.TabIndex = 0;
			this.RBPreset0.TabStop = true;
			this.RBPreset0.Text = "Своё";
			this.RBPreset0.UseVisualStyleBackColor = true;
			this.RBPreset0.CheckedChanged += new System.EventHandler(this.Preset0_Change);
			// 
			// RBPreset1
			// 
			this.RBPreset1.AutoSize = true;
			this.RBPreset1.Location = new System.Drawing.Point(72, 3);
			this.RBPreset1.Name = "RBPreset1";
			this.RBPreset1.Size = new System.Drawing.Size(161, 25);
			this.RBPreset1.TabIndex = 1;
			this.RBPreset1.TabStop = true;
			this.RBPreset1.Text = "Спокойная погода";
			this.RBPreset1.UseVisualStyleBackColor = true;
			this.RBPreset1.CheckedChanged += new System.EventHandler(this.Preset1_Change);
			// 
			// RBPreset2
			// 
			this.RBPreset2.AutoSize = true;
			this.RBPreset2.Location = new System.Drawing.Point(3, 34);
			this.RBPreset2.Name = "RBPreset2";
			this.RBPreset2.Size = new System.Drawing.Size(96, 25);
			this.RBPreset2.TabIndex = 2;
			this.RBPreset2.TabStop = true;
			this.RBPreset2.Text = "Снегопад";
			this.RBPreset2.UseVisualStyleBackColor = true;
			this.RBPreset2.CheckedChanged += new System.EventHandler(this.Preset2_Change);
			// 
			// RBPreset3
			// 
			this.RBPreset3.AutoSize = true;
			this.RBPreset3.Location = new System.Drawing.Point(105, 34);
			this.RBPreset3.Name = "RBPreset3";
			this.RBPreset3.Size = new System.Drawing.Size(62, 25);
			this.RBPreset3.TabIndex = 3;
			this.RBPreset3.TabStop = true;
			this.RBPreset3.Text = "Буря";
			this.RBPreset3.UseVisualStyleBackColor = true;
			this.RBPreset3.CheckedChanged += new System.EventHandler(this.Preset3_Change);
			// 
			// RBPreset4
			// 
			this.RBPreset4.AutoSize = true;
			this.RBPreset4.Location = new System.Drawing.Point(173, 34);
			this.RBPreset4.Name = "RBPreset4";
			this.RBPreset4.Size = new System.Drawing.Size(81, 25);
			this.RBPreset4.TabIndex = 4;
			this.RBPreset4.TabStop = true;
			this.RBPreset4.Text = "Метель";
			this.RBPreset4.UseVisualStyleBackColor = true;
			this.RBPreset4.CheckedChanged += new System.EventHandler(this.Preset4_Change);
			// 
			// InpFPS
			// 
			this.InpFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InpFPS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpFPS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.InpFPS.Location = new System.Drawing.Point(244, 77);
			this.InpFPS.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
			this.InpFPS.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.InpFPS.Name = "InpFPS";
			this.InpFPS.Size = new System.Drawing.Size(65, 29);
			this.InpFPS.TabIndex = 3;
			this.InpFPS.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.InpFPS.ValueChanged += new System.EventHandler(this.FPS_Change);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label10.Location = new System.Drawing.Point(6, 79);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(36, 21);
			this.label10.TabIndex = 12;
			this.label10.Text = "FPS";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Location = new System.Drawing.Point(7, 7);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(320, 360);
			this.tabControl2.TabIndex = 1;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.Controls.Add(this.InpFPS);
			this.tabPage4.Controls.Add(this.InpCount);
			this.tabPage4.Controls.Add(this.groupBox3);
			this.tabPage4.Controls.Add(this.InpSize);
			this.tabPage4.Controls.Add(this.label2);
			this.tabPage4.Controls.Add(this.label10);
			this.tabPage4.Location = new System.Drawing.Point(4, 24);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(312, 332);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Основное";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.PanelColor);
			this.tabPage5.Controls.Add(this.PanelImg);
			this.tabPage5.Controls.Add(this.RBimg);
			this.tabPage5.Controls.Add(this.label11);
			this.tabPage5.Controls.Add(this.RBimgCirc);
			this.tabPage5.Location = new System.Drawing.Point(4, 24);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(312, 332);
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "Снежинки";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// PanelColor
			// 
			this.PanelColor.Controls.Add(this.label3);
			this.PanelColor.Controls.Add(this.BtnColor);
			this.PanelColor.Location = new System.Drawing.Point(45, 58);
			this.PanelColor.Name = "PanelColor";
			this.PanelColor.Size = new System.Drawing.Size(261, 29);
			this.PanelColor.TabIndex = 7;
			// 
			// PanelImg
			// 
			this.PanelImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PanelImg.Controls.Add(this.BtnImg);
			this.PanelImg.Controls.Add(this.PBImg);
			this.PanelImg.Controls.Add(this.pictureBox2);
			this.PanelImg.Controls.Add(this.RBimg2);
			this.PanelImg.Controls.Add(this.pictureBox1);
			this.PanelImg.Controls.Add(this.RBimg0);
			this.PanelImg.Controls.Add(this.RBimg1);
			this.PanelImg.Location = new System.Drawing.Point(45, 114);
			this.PanelImg.Name = "PanelImg";
			this.PanelImg.Size = new System.Drawing.Size(261, 99);
			this.PanelImg.TabIndex = 4;
			// 
			// BtnImg
			// 
			this.BtnImg.BackgroundImage = global::SnowFlakes.Properties.Resources.file_add;
			this.BtnImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.BtnImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnImg.Location = new System.Drawing.Point(230, 65);
			this.BtnImg.Name = "BtnImg";
			this.BtnImg.Size = new System.Drawing.Size(28, 28);
			this.BtnImg.TabIndex = 4;
			this.BtnImg.UseVisualStyleBackColor = false;
			this.BtnImg.Click += new System.EventHandler(this.ChoseImg_Click);
			// 
			// PBImg
			// 
			this.PBImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PBImg.Location = new System.Drawing.Point(196, 65);
			this.PBImg.Name = "PBImg";
			this.PBImg.Size = new System.Drawing.Size(28, 28);
			this.PBImg.TabIndex = 14;
			this.PBImg.TabStop = false;
			this.PBImg.Click += new System.EventHandler(this.Img0_Change);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::SnowFlakes.Properties.Resources.snowflake;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox2.Location = new System.Drawing.Point(196, 34);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(28, 28);
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.Img2_Change);
			// 
			// RBimg2
			// 
			this.RBimg2.AutoSize = true;
			this.RBimg2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RBimg2.Location = new System.Drawing.Point(3, 34);
			this.RBimg2.Name = "RBimg2";
			this.RBimg2.Size = new System.Drawing.Size(100, 25);
			this.RBimg2.TabIndex = 2;
			this.RBimg2.Text = "Вариант 2";
			this.RBimg2.UseVisualStyleBackColor = true;
			this.RBimg2.CheckedChanged += new System.EventHandler(this.Img2_Change);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::SnowFlakes.Properties.Resources.snowflake_simple;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(196, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(28, 28);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.Img1_Change);
			// 
			// RBimg0
			// 
			this.RBimg0.AutoSize = true;
			this.RBimg0.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RBimg0.Location = new System.Drawing.Point(3, 65);
			this.RBimg0.Name = "RBimg0";
			this.RBimg0.Size = new System.Drawing.Size(63, 25);
			this.RBimg0.TabIndex = 3;
			this.RBimg0.Text = "Своя";
			this.RBimg0.UseVisualStyleBackColor = true;
			this.RBimg0.CheckedChanged += new System.EventHandler(this.Img0_Change);
			// 
			// RBimg1
			// 
			this.RBimg1.AutoSize = true;
			this.RBimg1.Checked = true;
			this.RBimg1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RBimg1.Location = new System.Drawing.Point(3, 3);
			this.RBimg1.Name = "RBimg1";
			this.RBimg1.Size = new System.Drawing.Size(100, 25);
			this.RBimg1.TabIndex = 1;
			this.RBimg1.TabStop = true;
			this.RBimg1.Text = "Вариант 1";
			this.RBimg1.UseVisualStyleBackColor = true;
			this.RBimg1.CheckedChanged += new System.EventHandler(this.Img1_Change);
			// 
			// RBimg
			// 
			this.RBimg.AutoSize = true;
			this.RBimg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RBimg.Location = new System.Drawing.Point(6, 83);
			this.RBimg.Name = "RBimg";
			this.RBimg.Size = new System.Drawing.Size(95, 25);
			this.RBimg.TabIndex = 3;
			this.RBimg.Text = "Картинка";
			this.RBimg.UseVisualStyleBackColor = true;
			this.RBimg.CheckedChanged += new System.EventHandler(this.Img_Change);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label11.Location = new System.Drawing.Point(3, 3);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(182, 21);
			this.label11.TabIndex = 6;
			this.label11.Text = "Как выглядят снежинки:";
			// 
			// RBimgCirc
			// 
			this.RBimgCirc.AutoSize = true;
			this.RBimgCirc.Checked = true;
			this.RBimgCirc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RBimgCirc.Location = new System.Drawing.Point(6, 27);
			this.RBimgCirc.Name = "RBimgCirc";
			this.RBimgCirc.Size = new System.Drawing.Size(101, 25);
			this.RBimgCirc.TabIndex = 1;
			this.RBimgCirc.TabStop = true;
			this.RBimgCirc.Text = "Кружочки";
			this.RBimgCirc.UseVisualStyleBackColor = true;
			this.RBimgCirc.CheckedChanged += new System.EventHandler(this.ImgCirc_Change);
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.groupBox1);
			this.tabPage6.Controls.Add(this.groupBox4);
			this.tabPage6.Controls.Add(this.groupBox2);
			this.tabPage6.Location = new System.Drawing.Point(4, 24);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(312, 332);
			this.tabPage6.TabIndex = 2;
			this.tabPage6.Text = "Полёт снежинок";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 411);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.BtnGithub);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnReset);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Снежинки";
			((System.ComponentModel.ISupportInitialize)(this.InpCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSize)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedXMax)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedYRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InpSpeedY)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InpForce)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InpFPS)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.PanelColor.ResumeLayout(false);
			this.PanelColor.PerformLayout();
			this.PanelImg.ResumeLayout(false);
			this.PanelImg.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabPage6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private Label label1;
		private NumericUpDown InpCount;
		private Label label2;
		private NumericUpDown InpSize;
		private Label label3;
		private ColorDialog colorDialog;
		private Button BtnColor;
		private GroupBox groupBox1;
		private NumericUpDown InpSpeedXMax;
		private Label label5;
		private Label label4;
		private NumericUpDown InpSpeedX;
		private GroupBox groupBox2;
		private NumericUpDown InpSpeedYRange;
		private NumericUpDown InpSpeedY;
		private Label label6;
		private Label label7;
		private GroupBox groupBox3;
		private NumericUpDown InpD;
		private NumericUpDown InpForce;
		private Label label8;
		private Label label9;
		private Button BtnReset;
		private Button BtnOk;
		private Button BtnGithub;
		private GroupBox groupBox4;
		private FlowLayoutPanel flowLayoutPanel1;
		private RadioButton RBPreset0;
		private RadioButton RBPreset1;
		private RadioButton RBPreset2;
		private RadioButton RBPreset3;
		private NumericUpDown InpFPS;
		private Label label10;
		private RadioButton RBPreset4;
		private TabControl tabControl2;
		private TabPage tabPage4;
		private TabPage tabPage5;
		private TabPage tabPage6;
		private Panel PanelImg;
		private PictureBox pictureBox1;
		private RadioButton RBimg0;
		private RadioButton RBimg1;
		private RadioButton RBimg;
		private Label label11;
		private RadioButton RBimgCirc;
		private PictureBox PBImg;
		private PictureBox pictureBox2;
		private RadioButton RBimg2;
		private Button BtnImg;
		private Panel PanelColor;
		private OpenFileDialog DialogOpenFile;
	}
}
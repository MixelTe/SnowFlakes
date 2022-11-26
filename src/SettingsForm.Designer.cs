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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Количество снежинок";
			// 
			// InpCount
			// 
			this.InpCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpCount.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.InpCount.Location = new System.Drawing.Point(194, 7);
			this.InpCount.Maximum = new decimal(new int[] {
            1000,
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
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Размер снежинок";
			// 
			// InpSize
			// 
			this.InpSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSize.Location = new System.Drawing.Point(194, 42);
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
			this.label3.Location = new System.Drawing.Point(12, 79);
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
			this.BtnColor.BackColor = System.Drawing.Color.LightBlue;
			this.BtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnColor.ForeColor = System.Drawing.Color.Gray;
			this.BtnColor.Location = new System.Drawing.Point(194, 79);
			this.BtnColor.Name = "BtnColor";
			this.BtnColor.Size = new System.Drawing.Size(65, 27);
			this.BtnColor.TabIndex = 3;
			this.BtnColor.UseVisualStyleBackColor = false;
			this.BtnColor.Click += new System.EventHandler(this.Color_Change);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.InpSpeedX);
			this.groupBox1.Controls.Add(this.InpSpeedXMax);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(12, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(247, 104);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ветер";
			// 
			// InpSpeedX
			// 
			this.InpSpeedX.DecimalPlaces = 1;
			this.InpSpeedX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.InpSpeedX.Location = new System.Drawing.Point(176, 63);
			this.InpSpeedX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.InpSpeedX.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.InpSpeedX.Name = "InpSpeedX";
			this.InpSpeedX.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedX.TabIndex = 5;
			this.InpSpeedX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.InpSpeedX.ValueChanged += new System.EventHandler(this.SpeedX_Change);
			// 
			// InpSpeedXMax
			// 
			this.InpSpeedXMax.DecimalPlaces = 1;
			this.InpSpeedXMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedXMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.InpSpeedXMax.Location = new System.Drawing.Point(176, 28);
			this.InpSpeedXMax.Maximum = new decimal(new int[] {
            15,
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
			this.InpSpeedXMax.TabIndex = 4;
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
			this.groupBox2.Controls.Add(this.InpSpeedYRange);
			this.groupBox2.Controls.Add(this.InpSpeedY);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox2.Location = new System.Drawing.Point(265, 7);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(247, 99);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Падение снежинок";
			// 
			// InpSpeedYRange
			// 
			this.InpSpeedYRange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedYRange.Location = new System.Drawing.Point(176, 63);
			this.InpSpeedYRange.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.InpSpeedYRange.Name = "InpSpeedYRange";
			this.InpSpeedYRange.Size = new System.Drawing.Size(65, 29);
			this.InpSpeedYRange.TabIndex = 7;
			this.InpSpeedYRange.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.InpSpeedYRange.ValueChanged += new System.EventHandler(this.SpeedY_Change);
			// 
			// InpSpeedY
			// 
			this.InpSpeedY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpSpeedY.Location = new System.Drawing.Point(176, 28);
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
			this.InpSpeedY.TabIndex = 6;
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
			this.groupBox3.Controls.Add(this.InpD);
			this.groupBox3.Controls.Add(this.InpForce);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox3.Location = new System.Drawing.Point(265, 112);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(247, 104);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Сдувание курсором";
			// 
			// InpD
			// 
			this.InpD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpD.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.InpD.Location = new System.Drawing.Point(176, 63);
			this.InpD.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
			this.InpD.Name = "InpD";
			this.InpD.Size = new System.Drawing.Size(65, 29);
			this.InpD.TabIndex = 9;
			this.InpD.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.InpD.ValueChanged += new System.EventHandler(this.ForceD_Change);
			// 
			// InpForce
			// 
			this.InpForce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InpForce.Location = new System.Drawing.Point(176, 28);
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
			this.InpForce.TabIndex = 8;
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
			this.BtnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnReset.Location = new System.Drawing.Point(12, 222);
			this.BtnReset.Name = "BtnReset";
			this.BtnReset.Size = new System.Drawing.Size(168, 32);
			this.BtnReset.TabIndex = 8;
			this.BtnReset.Text = "Сбросить настройки";
			this.BtnReset.UseVisualStyleBackColor = true;
			this.BtnReset.Click += new System.EventHandler(this.ResetBtn_Click);
			// 
			// BtnOk
			// 
			this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BtnOk.Location = new System.Drawing.Point(412, 222);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(100, 32);
			this.BtnOk.TabIndex = 7;
			this.BtnOk.Text = "Сохранить";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// BtnGithub
			// 
			this.BtnGithub.BackColor = System.Drawing.Color.Transparent;
			this.BtnGithub.BackgroundImage = global::SnowFlakes.Properties.Resources.github;
			this.BtnGithub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.BtnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnGithub.ForeColor = System.Drawing.Color.Transparent;
			this.BtnGithub.Location = new System.Drawing.Point(246, 224);
			this.BtnGithub.Name = "BtnGithub";
			this.BtnGithub.Size = new System.Drawing.Size(32, 32);
			this.BtnGithub.TabIndex = 9;
			this.BtnGithub.UseVisualStyleBackColor = false;
			this.BtnGithub.Click += new System.EventHandler(this.GitHub_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 266);
			this.Controls.Add(this.BtnGithub);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnReset);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.BtnColor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.InpSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.InpCount);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
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
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}
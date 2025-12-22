namespace SnowFlakes
{
	partial class WindowsFilterEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFilterEditForm));
			label2 = new Label();
			InpValue = new TextBox();
			BtnOk = new Button();
			BtnDelete = new Button();
			CBRegex = new CheckBox();
			LblRegexError = new Label();
			SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 15);
			label2.Name = "label2";
			label2.Size = new Size(69, 15);
			label2.TabIndex = 2;
			label2.Text = "Подстрока:";
			// 
			// InpValue
			// 
			InpValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpValue.Location = new Point(95, 12);
			InpValue.Name = "InpValue";
			InpValue.Size = new Size(271, 23);
			InpValue.TabIndex = 3;
			InpValue.TextChanged += InpValue_TextChanged;
			// 
			// BtnOk
			// 
			BtnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnOk.Location = new Point(302, 41);
			BtnOk.Name = "BtnOk";
			BtnOk.Size = new Size(64, 23);
			BtnOk.TabIndex = 4;
			BtnOk.Text = "ОК";
			BtnOk.UseVisualStyleBackColor = true;
			BtnOk.Click += BtnOk_Click;
			// 
			// BtnDelete
			// 
			BtnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnDelete.Location = new Point(232, 41);
			BtnDelete.Name = "BtnDelete";
			BtnDelete.Size = new Size(64, 23);
			BtnDelete.TabIndex = 5;
			BtnDelete.Text = "Удалить";
			BtnDelete.UseVisualStyleBackColor = true;
			BtnDelete.Click += BtnDelete_Click;
			// 
			// CBRegex
			// 
			CBRegex.AutoSize = true;
			CBRegex.Location = new Point(12, 44);
			CBRegex.Name = "CBRegex";
			CBRegex.Size = new Size(58, 19);
			CBRegex.TabIndex = 6;
			CBRegex.Text = "Regex";
			CBRegex.UseVisualStyleBackColor = true;
			CBRegex.CheckedChanged += CBRegex_CheckedChanged;
			// 
			// LblRegexError
			// 
			LblRegexError.AutoSize = true;
			LblRegexError.ForeColor = Color.IndianRed;
			LblRegexError.Location = new Point(76, 45);
			LblRegexError.Name = "LblRegexError";
			LblRegexError.Size = new Size(150, 15);
			LblRegexError.TabIndex = 7;
			LblRegexError.Text = "Ошибка regex синтаксиса";
			LblRegexError.Visible = false;
			// 
			// WindowsFilterEditForm
			// 
			AcceptButton = BtnOk;
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(378, 76);
			Controls.Add(LblRegexError);
			Controls.Add(CBRegex);
			Controls.Add(BtnDelete);
			Controls.Add(BtnOk);
			Controls.Add(InpValue);
			Controls.Add(label2);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "WindowsFilterEditForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Снежинки | Фильтр окон > Редактирование";
			KeyDown += WindowsFilterEditForm_KeyDown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label2;
		private TextBox InpValue;
		private Button BtnOk;
		private Button BtnDelete;
		private CheckBox CBRegex;
		private Label LblRegexError;
	}
}
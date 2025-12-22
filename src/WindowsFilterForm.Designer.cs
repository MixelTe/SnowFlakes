namespace SnowFlakes
{
	partial class WindowsFilterForm
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFilterForm));
			splitContainer1 = new SplitContainer();
			label1 = new Label();
			CBListWindows = new CheckedListBox();
			label3 = new Label();
			ListFilters = new ListView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			MenuItemEdit = new ToolStripMenuItem();
			MenuItemDelete = new ToolStripMenuItem();
			label2 = new Label();
			Timer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(0, 117);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(CBListWindows);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(label3);
			splitContainer1.Panel2.Controls.Add(ListFilters);
			splitContainer1.Size = new Size(454, 244);
			splitContainer1.SplitterDistance = 227;
			splitContainer1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 6);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 1;
			label1.Text = "Окна:";
			// 
			// CBListWindows
			// 
			CBListWindows.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			CBListWindows.FormattingEnabled = true;
			CBListWindows.Location = new Point(0, 24);
			CBListWindows.Name = "CBListWindows";
			CBListWindows.Size = new Size(227, 220);
			CBListWindows.TabIndex = 0;
			CBListWindows.ItemCheck += CBListWindows_ItemCheck;
			CBListWindows.SelectedIndexChanged += CBListWindows_SelectedIndexChanged;
			CBListWindows.DoubleClick += CBListWindows_DoubleClick;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(3, 6);
			label3.Name = "label3";
			label3.Size = new Size(164, 15);
			label3.TabIndex = 1;
			label3.Text = "Фильтры по заголовку окна:";
			// 
			// ListFilters
			// 
			ListFilters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ListFilters.ContextMenuStrip = contextMenuStrip1;
			ListFilters.HideSelection = true;
			ListFilters.Location = new Point(0, 24);
			ListFilters.MultiSelect = false;
			ListFilters.Name = "ListFilters";
			ListFilters.Size = new Size(223, 220);
			ListFilters.TabIndex = 0;
			ListFilters.UseCompatibleStateImageBehavior = false;
			ListFilters.View = View.List;
			ListFilters.DoubleClick += ListFilters_DoubleClick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { MenuItemEdit, MenuItemDelete });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(155, 48);
			// 
			// MenuItemEdit
			// 
			MenuItemEdit.Name = "MenuItemEdit";
			MenuItemEdit.Size = new Size(154, 22);
			MenuItemEdit.Text = "Редактировать";
			MenuItemEdit.Click += MenuItemEdit_Click;
			// 
			// MenuItemDelete
			// 
			MenuItemDelete.Name = "MenuItemDelete";
			MenuItemDelete.Size = new Size(154, 22);
			MenuItemDelete.Text = "Удалить";
			MenuItemDelete.Click += MenuItemDelete_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 9);
			label2.Name = "label2";
			label2.Size = new Size(337, 105);
			label2.TabIndex = 2;
			label2.Text = resources.GetString("label2.Text");
			// 
			// Timer
			// 
			Timer.Enabled = true;
			Timer.Interval = 200;
			Timer.Tick += Timer_Tick;
			// 
			// WindowsFilterForm
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(454, 361);
			Controls.Add(label2);
			Controls.Add(splitContainer1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(470, 400);
			Name = "WindowsFilterForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Снежинки | Фильтр окон";
			FormClosed += WindowsFilterForm_FormClosed;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private SplitContainer splitContainer1;
		private CheckedListBox CBListWindows;
		private Label label2;
		private System.Windows.Forms.Timer Timer;
		private ListView ListFilters;
		private Label label3;
		private Label label1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem MenuItemEdit;
		private ToolStripMenuItem MenuItemDelete;
	}
}
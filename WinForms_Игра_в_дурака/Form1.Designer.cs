namespace WinForms_Игра_в_дурака
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialisableXMLMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeSerialisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.OtbojButton2 = new System.Windows.Forms.Button();
            this.ZabirayuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewGameContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ZabirayuContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OtbojContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialisableXMLMenu,
            this.DeSerialisMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SerialisableXMLMenu
            // 
            this.SerialisableXMLMenu.Name = "SerialisableXMLMenu";
            this.SerialisableXMLMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.SerialisableXMLMenu.Size = new System.Drawing.Size(224, 22);
            this.SerialisableXMLMenu.Text = "Прервать игру";
            this.SerialisableXMLMenu.Click += new System.EventHandler(this.SerialisableXMLMenu_Click);
            // 
            // DeSerialisMenu
            // 
            this.DeSerialisMenu.Name = "DeSerialisMenu";
            this.DeSerialisMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.DeSerialisMenu.Size = new System.Drawing.Size(224, 22);
            this.DeSerialisMenu.Text = "Продолжить игру";
            this.DeSerialisMenu.Click += new System.EventHandler(this.DeSerialisMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(774, 463);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(774, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Новая игра";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtbojButton2
            // 
            this.OtbojButton2.Location = new System.Drawing.Point(590, 437);
            this.OtbojButton2.Name = "OtbojButton2";
            this.OtbojButton2.Size = new System.Drawing.Size(75, 23);
            this.OtbojButton2.TabIndex = 4;
            this.OtbojButton2.Text = "Отбой";
            this.OtbojButton2.UseVisualStyleBackColor = true;
            this.OtbojButton2.Click += new System.EventHandler(this.OtbojButton2_Click);
            // 
            // ZabirayuButton
            // 
            this.ZabirayuButton.Location = new System.Drawing.Point(485, 437);
            this.ZabirayuButton.Name = "ZabirayuButton";
            this.ZabirayuButton.Size = new System.Drawing.Size(75, 23);
            this.ZabirayuButton.TabIndex = 5;
            this.ZabirayuButton.Text = "Забираю";
            this.ZabirayuButton.UseVisualStyleBackColor = true;
            this.ZabirayuButton.Click += new System.EventHandler(this.ZabirayuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(166, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Кол-во карт в колоде: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(12, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Кол-во карт в отбое: ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameContextMenu,
            this.ZabirayuContextMenu,
            this.OtbojContextMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // NewGameContextMenu
            // 
            this.NewGameContextMenu.Name = "NewGameContextMenu";
            this.NewGameContextMenu.Size = new System.Drawing.Size(136, 22);
            this.NewGameContextMenu.Text = "Новая игра";
            this.NewGameContextMenu.Click += new System.EventHandler(this.NewGameContextMenu_Click);
            // 
            // ZabirayuContextMenu
            // 
            this.ZabirayuContextMenu.Name = "ZabirayuContextMenu";
            this.ZabirayuContextMenu.Size = new System.Drawing.Size(136, 22);
            this.ZabirayuContextMenu.Text = "Забираю";
            this.ZabirayuContextMenu.Click += new System.EventHandler(this.ZabirayuContextMenu_Click);
            // 
            // OtbojContextMenu
            // 
            this.OtbojContextMenu.Name = "OtbojContextMenu";
            this.OtbojContextMenu.Size = new System.Drawing.Size(136, 22);
            this.OtbojContextMenu.Text = "Отбой";
            this.OtbojContextMenu.Click += new System.EventHandler(this.OtbojContextMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(774, 487);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZabirayuButton);
            this.Controls.Add(this.OtbojButton2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OtbojButton2;
        private System.Windows.Forms.Button ZabirayuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NewGameContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ZabirayuContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OtbojContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SerialisableXMLMenu;
        private System.Windows.Forms.ToolStripMenuItem DeSerialisMenu;
    }
}


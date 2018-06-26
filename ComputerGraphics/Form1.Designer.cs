namespace ComputerGraphics
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_test = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button_line = new System.Windows.Forms.ToolStripButton();
            this.Button_rect = new System.Windows.Forms.ToolStripButton();
            this.Button_ellip = new System.Windows.Forms.ToolStripButton();
            this.Button_poly = new System.Windows.Forms.ToolStripButton();
            this.Button_drawBezier = new System.Windows.Forms.ToolStripButton();
            this.Button_fill = new System.Windows.Forms.ToolStripButton();
            this.Button_move = new System.Windows.Forms.ToolStripButton();
            this.Button_resize = new System.Windows.Forms.ToolStripButton();
            this.Button_rotation = new System.Windows.Forms.ToolStripButton();
            this.Button_clip = new System.Windows.Forms.ToolStripButton();
            this.Button_3D = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件ToolStripMenuItem,
            this.载入图像ToolStripMenuItem,
            this.保存图像ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建文件ToolStripMenuItem
            // 
            this.新建文件ToolStripMenuItem.Name = "新建文件ToolStripMenuItem";
            this.新建文件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.新建文件ToolStripMenuItem.Text = "新建文件";
            this.新建文件ToolStripMenuItem.Click += new System.EventHandler(this.新建文件ToolStripMenuItem_Click);
            // 
            // 载入图像ToolStripMenuItem
            // 
            this.载入图像ToolStripMenuItem.Enabled = false;
            this.载入图像ToolStripMenuItem.Name = "载入图像ToolStripMenuItem";
            this.载入图像ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.载入图像ToolStripMenuItem.Text = "载入图像";
            this.载入图像ToolStripMenuItem.Click += new System.EventHandler(this.载入图像ToolStripMenuItem_Click);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.Enabled = false;
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(13, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(933, 619);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 715);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 20);
            this.toolStripStatusLabel1.Text = "X:     ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(22, 20);
            this.toolStripStatusLabel2.Text = "Y:";
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(553, 32);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(131, 23);
            this.button_test.TabIndex = 4;
            this.button_test.Text = "button_test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 42);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_line,
            this.Button_rect,
            this.Button_ellip,
            this.Button_poly,
            this.Button_drawBezier,
            this.Button_fill,
            this.Button_move,
            this.Button_resize,
            this.Button_rotation,
            this.Button_clip,
            this.Button_3D});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 42);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Button_line
            // 
            this.Button_line.CheckOnClick = true;
            this.Button_line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_line.Image = ((System.Drawing.Image)(resources.GetObject("Button_line.Image")));
            this.Button_line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_line.Name = "Button_line";
            this.Button_line.Size = new System.Drawing.Size(24, 39);
            this.Button_line.Text = "绘制直线";
            this.Button_line.Click += new System.EventHandler(this.Button_line_Click);
            // 
            // Button_rect
            // 
            this.Button_rect.CheckOnClick = true;
            this.Button_rect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_rect.Image = ((System.Drawing.Image)(resources.GetObject("Button_rect.Image")));
            this.Button_rect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_rect.Name = "Button_rect";
            this.Button_rect.Size = new System.Drawing.Size(24, 39);
            this.Button_rect.Text = "绘制矩形";
            this.Button_rect.Click += new System.EventHandler(this.Button_rect_Click);
            // 
            // Button_ellip
            // 
            this.Button_ellip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_ellip.Image = ((System.Drawing.Image)(resources.GetObject("Button_ellip.Image")));
            this.Button_ellip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_ellip.Name = "Button_ellip";
            this.Button_ellip.Size = new System.Drawing.Size(24, 39);
            this.Button_ellip.Text = "绘制椭圆";
            this.Button_ellip.Click += new System.EventHandler(this.Button_ellip_Click);
            // 
            // Button_poly
            // 
            this.Button_poly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_poly.Image = ((System.Drawing.Image)(resources.GetObject("Button_poly.Image")));
            this.Button_poly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_poly.Name = "Button_poly";
            this.Button_poly.Size = new System.Drawing.Size(24, 39);
            this.Button_poly.Text = "绘制多边形";
            this.Button_poly.Click += new System.EventHandler(this.Button_poly_Click);
            // 
            // Button_drawBezier
            // 
            this.Button_drawBezier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_drawBezier.Image = ((System.Drawing.Image)(resources.GetObject("Button_drawBezier.Image")));
            this.Button_drawBezier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_drawBezier.Name = "Button_drawBezier";
            this.Button_drawBezier.Size = new System.Drawing.Size(24, 39);
            this.Button_drawBezier.Text = "绘制Bezier曲线";
            this.Button_drawBezier.Click += new System.EventHandler(this.Button_Bezier_Click);
            // 
            // Button_fill
            // 
            this.Button_fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_fill.Image = ((System.Drawing.Image)(resources.GetObject("Button_fill.Image")));
            this.Button_fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_fill.Name = "Button_fill";
            this.Button_fill.Size = new System.Drawing.Size(24, 39);
            this.Button_fill.Text = "填充";
            this.Button_fill.Click += new System.EventHandler(this.Button_fill_Click);
            // 
            // Button_move
            // 
            this.Button_move.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_move.Image = ((System.Drawing.Image)(resources.GetObject("Button_move.Image")));
            this.Button_move.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_move.Name = "Button_move";
            this.Button_move.Size = new System.Drawing.Size(24, 39);
            this.Button_move.Text = "移动";
            this.Button_move.Click += new System.EventHandler(this.Button_move_Click);
            // 
            // Button_resize
            // 
            this.Button_resize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_resize.Image = ((System.Drawing.Image)(resources.GetObject("Button_resize.Image")));
            this.Button_resize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_resize.Name = "Button_resize";
            this.Button_resize.Size = new System.Drawing.Size(24, 39);
            this.Button_resize.Text = "缩放";
            this.Button_resize.Click += new System.EventHandler(this.Button_resize_Click);
            // 
            // Button_rotation
            // 
            this.Button_rotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_rotation.Image = ((System.Drawing.Image)(resources.GetObject("Button_rotation.Image")));
            this.Button_rotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_rotation.Name = "Button_rotation";
            this.Button_rotation.Size = new System.Drawing.Size(24, 39);
            this.Button_rotation.Text = "旋转";
            this.Button_rotation.Click += new System.EventHandler(this.Button_rotation_Click);
            // 
            // Button_clip
            // 
            this.Button_clip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_clip.Image = ((System.Drawing.Image)(resources.GetObject("Button_clip.Image")));
            this.Button_clip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_clip.Name = "Button_clip";
            this.Button_clip.Size = new System.Drawing.Size(24, 39);
            this.Button_clip.Text = "裁剪";
            this.Button_clip.Click += new System.EventHandler(this.Button_clip_Click);
            // 
            // Button_3D
            // 
            this.Button_3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_3D.Image = ((System.Drawing.Image)(resources.GetObject("Button_3D.Image")));
            this.Button_3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_3D.Name = "Button_3D";
            this.Button_3D.Size = new System.Drawing.Size(24, 39);
            this.Button_3D.Text = "3D图形";
            this.Button_3D.Click += new System.EventHandler(this.Button_3D_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(958, 740);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入图像ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 新建文件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Button_line;
        private System.Windows.Forms.ToolStripButton Button_rect;
        private System.Windows.Forms.ToolStripButton Button_ellip;
        private System.Windows.Forms.ToolStripButton Button_poly;
        private System.Windows.Forms.ToolStripButton Button_move;
        private System.Windows.Forms.ToolStripButton Button_resize;
        private System.Windows.Forms.ToolStripButton Button_rotation;
        private System.Windows.Forms.ToolStripButton Button_fill;
        private System.Windows.Forms.ToolStripButton Button_drawBezier;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton Button_clip;
        private System.Windows.Forms.ToolStripButton Button_3D;
    }
}


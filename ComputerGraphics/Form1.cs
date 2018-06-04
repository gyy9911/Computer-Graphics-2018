﻿/*计算机图形学大作业
 * 高亦远 151160014
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        public Primitive newPrim;//刚绘制的图元,将在下一个图元创建前绘制于g1上
        public Primitive tempPrim;//拖拽时的临时图元

        public Graphics g,g1;//g1为实际保存的图像，g为绘制的图像
        public enum tools
        {
            drawLine,drawRect,drawEllip,drawPoly,drawBezier,
            move,resize,rotaton,
            fill
        }       
        public tools tempTool;//当前作画工具
        public static Color backColor = Color.White;
        public static Color tempColor = Color.Black;
        public static Bitmap img1;//g1实际画在img上
        public static Bitmap img;
        public static Pen pen;
        public static Brush brush;
        public Point startPoint;//绘图始终点
        public Point tempPoint;
        public bool isDrawing=false;
        public bool isEditing = false;//是否正在进行移动、缩放等编辑
        public Form1()
        {
            InitializeComponent();            
            
            img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pen = new Pen(tempColor);
            brush = new SolidBrush(tempColor);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {

            img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            g1 = Graphics.FromImage(img);
            g1.Clear(backColor);
            g = pictureBox1.CreateGraphics();
            g.Clear(backColor);
            载入图像ToolStripMenuItem.Enabled = true;
            保存图像ToolStripMenuItem.Enabled = true;
            toolStrip1.Enabled = true;
            
        }
        private void 新建文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //创建一个Bitmap 
            img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);           
            g1 = Graphics.FromImage(img);
            g1.Clear(backColor);
            g = pictureBox1.CreateGraphics();
            g.Clear(backColor);
            载入图像ToolStripMenuItem.Enabled = true;
            保存图像ToolStripMenuItem.Enabled = true;
            toolStrip1.Enabled = true;
        }

        private void 载入图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                string fileName = openFileDialog.FileName;
                //img = Bitmap.FromFile(openFileDialog.FileName);
                img = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);

                g.DrawImage(img, pictureBox1.ClientRectangle);
                g1 = Graphics.FromImage(img);
            }
        }

        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "图像(*.bmp)|*.bmp";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {             
                img.Save(saveFileDialog.FileName);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {                      
            if (e.Button == MouseButtons.Left&& tempTool!=tools.drawPoly&& tempTool != tools.drawBezier)//多边形绘制单独处理
            {
                isDrawing = true; 
                startPoint = new Point(e.X, e.Y);
                tempPoint = new Point(e.X, e.Y);

                switch (tempTool)
                {
                    case tools.drawLine:
                    case tools.drawRect:
                    case tools.drawEllip:
                    case tools.drawPoly:
                    case tools.drawBezier:
                    case tools.fill:
                        {
                            if (newPrim != null) newPrim.DrawTrim(g1);//创建新图元前，将前一个确认绘制至g1上
                            break;
                        }                   
                    case tools.move:
                    case tools.resize:
                    case tools.rotaton:
                        {
                            if (newPrim != null && isMouseOnKeyPoint(e.X, e.Y)) isEditing = true;
                            break;
                        }

                    default: break;
                }

            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "X:" + Convert.ToString(e.X);
            toolStripStatusLabel2.Text = "Y:" + Convert.ToString(e.Y);

            if (isDrawing)
            {
                switch(tempTool)
                {
                    case tools.drawLine:
                        {                           
                            tempPoint.X = e.X; tempPoint.Y = e.Y;

                            g.DrawImage(img, pictureBox1.ClientRectangle);

                            tempPrim = new PrimitiveLine();
                            tempPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);
                            tempPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.drawRect:
                        {
                            tempPoint.X = e.X; tempPoint.Y = e.Y;

                            g.DrawImage(img, pictureBox1.ClientRectangle);
                            
                            tempPrim = new PrimitiveRectangle();
                            tempPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);
                            tempPrim.AddKeyPoints(tempPoint.X, startPoint.Y, startPoint.X, tempPoint.Y);//添加矩形的另两个顶点

                            tempPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.drawEllip:
                        {

                            tempPoint.X = e.X; tempPoint.Y = e.Y;

                            g.DrawImage(img, pictureBox1.ClientRectangle);

                            tempPrim = new PrimitiveEllipse();
                            tempPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);
                            tempPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.drawPoly:
                        {
                            tempPoint.X = e.X; tempPoint.Y = e.Y;
                            g.DrawImage(img, pictureBox1.ClientRectangle);

                            tempPrim.tempPoint = tempPoint;
                            ((PrimitivePolygon)tempPrim).DrawTrim_unclosed(g);

                            break;
                        }
                    case tools.move:
                        {
                            if (isEditing)
                            {
                                tempPoint.X = e.X; tempPoint.Y = e.Y;
                                newPrim.Move(tempPoint, startPoint,tempPrim);//tempPrim存储着该图元变换前的副本，作为后续变换的基础

                                g.DrawImage(img, pictureBox1.ClientRectangle);

                                newPrim.DrawTrim_temp(g);
                            }
                            break;
                        }
                    case tools.resize:
                        {
                            if (isEditing)
                            {
                                tempPoint.X = e.X; tempPoint.Y = e.Y;
                                newPrim.Resize(tempPoint, startPoint,tempPrim);

                                g.DrawImage(img, pictureBox1.ClientRectangle);

                                newPrim.DrawTrim_temp(g);
                            }
                            break;
                        }
                    case tools.rotaton:
                        {
                            if (isEditing)
                            {
                                tempPoint.X = e.X; tempPoint.Y = e.Y;
                                newPrim.Rotation(tempPoint, startPoint,tempPrim);

                                g.DrawImage(img, pictureBox1.ClientRectangle);

                                newPrim.DrawTrim_temp(g);
                            }
                            break;
                        }

                    default:break;
                }              
               
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing&&e.Button==MouseButtons.Left)
            {
                switch (tempTool)
                {
                    case tools.drawLine:
                        {
                            newPrim = new PrimitiveLine();//保存完成绘制的图元

                            tempPoint.X = e.X; tempPoint.Y = e.Y;     
                            isDrawing = false;
                            newPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);
                            newPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.drawRect:
                        {
                            newPrim = new PrimitiveRectangle();

                            tempPoint.X = e.X; tempPoint.Y = e.Y;
                            isDrawing = false;
                            newPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);

                            newPrim.AddKeyPoints(tempPoint.X, startPoint.Y, startPoint.X, tempPoint.Y);//添加矩形的另两个顶点

                            newPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.drawEllip:
                        {
                            newPrim = new PrimitiveEllipse();

                            tempPoint.X = e.X; tempPoint.Y = e.Y;
                           
                            isDrawing = false;
                            newPrim.AddKeyPoints(startPoint.X, startPoint.Y, tempPoint.X, tempPoint.Y);

                            newPrim.DrawTrim_temp(g);
                            break;
                        }
                    case tools.move:
                        {
                            isDrawing = false;
                            isEditing = false;
                            break;
                        }
                    case tools.resize:
                        {
                            isDrawing = false;
                            isEditing = false;
                            break;
                        }
                    case tools.rotaton:
                        {
                            isDrawing = false;
                            isEditing = false;
                            break;
                        }
                    case tools.fill:
                        {
                            Color color = img.GetPixel(e.X, e.Y);
                            MyDraw mydraw = new MyDraw();
                            img=mydraw.Fill(img, new Point(e.X, e.Y), color);
                            g.DrawImage(img, pictureBox1.ClientRectangle);
                            g1.DrawImage(img, pictureBox1.ClientRectangle);

                            isDrawing = false;
                            break;
                        }
                    default: break;
                }
            }           
            
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //多边形及曲线由单击开始绘制，无须拖动
            if (tempTool!= tools.drawPoly&& tempTool != tools.drawBezier) return;
            switch(tempTool)
            {
                case tools.drawPoly:
                    {
                        if (isDrawing == false)//第一次点击
                        {
                            if (newPrim != null) newPrim.DrawTrim(g1);
                            startPoint = new Point(e.X, e.Y);
                            isDrawing = true;
                            tempPrim = new PrimitivePolygon();
                            tempPrim.AddKeyPoint(startPoint.X, startPoint.Y);
                            newPrim = new PrimitivePolygon();
                            newPrim.AddKeyPoint(startPoint.X, startPoint.Y);
                        }
                        else if (isDrawing == true)//中途点击
                        {
                            tempPoint.X = e.X; tempPoint.Y = e.Y;
                            tempPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                            newPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                            ((PrimitivePolygon)tempPrim).DrawTrim_unclosed(g);
                        }
                        break;
                    }
                case tools.drawBezier:
                    {
                        if (isDrawing == false)//第一次点击
                        {
                            if (newPrim != null) newPrim.DrawTrim(g1);
                            g.DrawImage(img, pictureBox1.ClientRectangle);
                            startPoint = new Point(e.X, e.Y);
                            isDrawing = true;
                            tempPrim = new PrimitiveBezier();
                            tempPrim.AddKeyPoint(startPoint.X, startPoint.Y);
                            newPrim = new PrimitiveBezier();
                            newPrim.AddKeyPoint(startPoint.X, startPoint.Y);


                            tempPrim.DrawTrim_temp(g);
                        }
                        else if (isDrawing == true)//中途点击
                        {
                            tempPoint.X = e.X; tempPoint.Y = e.Y;
                            tempPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                            newPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);

                            g.DrawImage(img, pictureBox1.ClientRectangle);
                            tempPrim.DrawTrim_temp(g);
                        }
                        break;
                    }

                default:break;
            }
            
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //多边形及曲线由双击结束绘制
            if (isDrawing==true&&tempTool==tools.drawPoly)
            {
                //tempPoint.X = e.X; tempPoint.Y = e.Y;
                //tempPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                tempPrim.DrawTrim_temp(g);
                //newPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                isDrawing = false;
            }
            else if(isDrawing == true && tempTool == tools.drawBezier)
            {
                //tempPoint.X = e.X; tempPoint.Y = e.Y;
                //tempPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                tempPrim.DrawTrim_temp(g);
                //newPrim.AddKeyPoint(tempPoint.X, tempPoint.Y);
                isDrawing = false;
            }
        }
        private void Button_line_Click(object sender, EventArgs e)
        {
            tempTool = tools.drawLine;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_line.Checked = true;

        }

        private void Button_rect_Click(object sender, EventArgs e)
        {
            tempTool = tools.drawRect;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_rect.Checked = true;
        }


        private void Button_ellip_Click(object sender, EventArgs e)
        {
            tempTool = tools.drawEllip;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_ellip.Checked = true;
        }

        private void button_test_Click(object sender, EventArgs e)//测试用
        {
            tempPrim = new PrimitiveBezier();
            tempPrim.AddKeyPoint(100, 50);
            tempPrim.AddKeyPoint(200, 150);
            tempPrim.AddKeyPoint(250, 100);
            tempPrim.AddKeyPoint(300, 250);
            tempPrim.DrawTrim(g);
        }

        private void Button_poly_Click(object sender, EventArgs e)
        {
            tempTool = tools.drawPoly;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_poly.Checked = true;

        }

        private void Button_move_Click(object sender, EventArgs e)
        {
            tempTool = tools.move;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_move.Checked = true;
            if(newPrim!=null&&tempPrim!=null)//更改编辑工具时，保存编辑后的图元，作为后续操作的基础
            {
                tempPrim = newPrim.Copy();
            }
        }

        private void Button_resize_Click(object sender, EventArgs e)
        {
            tempTool = tools.resize;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_resize.Checked = true;
            if (newPrim != null && tempPrim != null)
            {
                tempPrim = newPrim.Copy();
            }
        }

        private void Button_rotation_Click(object sender, EventArgs e)
        {
            tempTool = tools.rotaton;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_rotation.Checked = true;
            if (newPrim != null && tempPrim != null)
            {
                tempPrim = newPrim.Copy();
            }
        }

        private void Button_fill_Click(object sender, EventArgs e)
        {
            tempTool = tools.fill;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_fill.Checked = true;
        }

        private void Button_Bezier_Click(object sender, EventArgs e)
        {
            tempTool = tools.drawBezier;
            foreach (ToolStripButton mi in toolStrip1.Items)
            {
                mi.Checked = false;
            }
            Button_drawBezier.Checked = true;
        }

        private bool isMouseOnKeyPoint(int x,int y)
        {
            foreach(Point p in newPrim.keyPoints)
            {
                if (p.X - x < 8 && p.X - x > -8 && p.Y - y < 8 && p.Y - y > -8) return true;
            }
            return false;            
        }

    }
}

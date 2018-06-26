using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ComputerGraphics
{
    abstract public class Primitive
    {//基本图元，线、矩形、圆等
        public List<Point> pointSet = new List<Point>();
        public List<Point> keyPoints = new List<Point>();
        public Point tempPoint;

        public void DrawLine(Graphics g, Point p0, Point p1)
        {
            int x0 = p0.X;
            int y0 = p0.Y;
            int x1 = p1.X;
            int y1 = p1.Y;
            float pk;
            float m;
            if (x0 == x1)
            {
                int dy = y1 > y0 ? 1 : -1;//y的增量
                for (int y = y0; y != y1;)
                {
                    g.FillEllipse(Form1.brush, x0, y, 2, 2);
                    y += dy;
                }
            }
            else if (y0 == y1)
            {
                int dx = x1 > x0 ? 1 : -1;
                for (int x = x0; x != x1;)
                {
                    g.FillEllipse(Form1.brush, x, y0, 2, 2);
                    x += dx;
                }
            }
            else if (y1 - y0 == x1 - x0 || y1 - y0 == -(x1 - x0))
            {
                int x = x0;
                int y = y0;
                int dx = x1 > x ? 1 : -1;
                int dy = dx * (y1 - y0) / (x1 - x0);
                for (x = x0; x != x1;)
                {
                    g.FillEllipse(Form1.brush, x, y, 2, 2);
                    x += dx;
                    y += dy;
                }
            }
            else//非特殊情况时
            {
                m = (float)(y1 - y0) / (float)(x1 - x0);//斜率
                if (m > 1)//将所求直线变换到斜率0~1之间
                {
                    int temp = x0;
                    x0 = y0;
                    y0 = temp;
                    temp = x1;
                    x1 = y1;
                    y1 = temp;
                    if (x0 > x1)//保证x0为左端点
                    {
                        temp = x0; x0 = x1; x1 = temp;
                        temp = y0; y0 = y1; y1 = temp;
                    }
                }
                else if (m >= -1 && m < 0)
                {
                    y0 = -y0;
                    y1 = -y1;
                    if (x0 > x1)
                    {
                        int temp = x0; x0 = x1; x1 = temp;
                        temp = y0; y0 = y1; y1 = temp;
                    }
                }
                else if (m < -1)
                {
                    int temp = x0;
                    x0 = y0;
                    y0 = -temp;
                    temp = x1;
                    x1 = y1;
                    y1 = -temp;
                    if (x0 > x1)
                    {
                        temp = x0; x0 = x1; x1 = temp;
                        temp = y0; y0 = y1; y1 = temp;
                    }
                }
                else//斜率0~1之间
                {
                    if (x0 > x1)
                    {
                        int temp = x0;
                        x0 = x1; x1 = temp;
                        temp = y0; y0 = y1; y1 = temp;
                    }
                }

                int x, y;
                int dx, dy;
                dx = x1 - x0;
                dy = y1 - y0;
                pk = 2 * dy - dx;
                g.FillEllipse(Form1.brush, x0, y0, 2, 2);//画起始点
                for (x = x0 + 1, y = y0; x <= x1; x++)
                {
                    if (pk <= 0)
                    {
                        if (m > 0 && m <= 1)//变为原直线
                            g.FillEllipse(Form1.brush, x, y, 2, 2);
                        if (m > 1)
                            g.FillEllipse(Form1.brush, y, x, 2, 2);
                        if (m >= -1 && m < 0)
                            g.FillEllipse(Form1.brush, x, -y, 2, 2);
                        if (m < -1)
                            g.FillEllipse(Form1.brush, -y, x, 2, 2);
                        pk += 2 * dy;
                    }
                    else
                    {
                        if (m > 0 && m <= 1)
                            g.FillEllipse(Form1.brush, x, ++y, 2, 2);
                        if (m > 1)
                            g.FillEllipse(Form1.brush, ++y, x, 2, 2);
                        if (m >= -1 && m < 0)
                            g.FillEllipse(Form1.brush, x, -(++y), 2, 2);
                        if (m < -1)
                            g.FillEllipse(Form1.brush, -(++y), x, 2, 2);
                        pk += 2 * dy - 2 * dx;
                    }
                }
            }
        }

        public void AddKeyPoints(int x0, int y0, int x1, int y1)//添加关键点，如线段的两端点
        {
            keyPoints.Add(new Point(x0, y0));
            keyPoints.Add(new Point(x1, y1));
        }
        public void AddKeyPoints(Point p0, Point p1)
        {
            keyPoints.Add(p0);
            keyPoints.Add(p1);
        }
        public void AddKeyPoint(int x0, int y0)//添加单个关键点，如多边形的顶点
        {
            keyPoints.Add(new Point(x0, y0));
        }
        public void AddKeyPoint(Point p)
        {
            keyPoints.Add(p);
        }

        virtual public void DrawTrim_temp(Graphics g) { DrawTrim(g); }//绘制该图元,区别在于对关键点的强调
        virtual public void DrawTrim(Graphics g) { }//确认该图元，将其绘制于g1

        public void Move(Point tempP, Point startP, Primitive ori)//origin为变换前图元的副本
        {
            int dx = tempP.X - startP.X;
            int dy = tempP.Y - startP.Y;
            for (int i = 0; i < keyPoints.Count; i++)
            {
                keyPoints[i] = new Point(ori.keyPoints[i].X + dx, ori.keyPoints[i].Y + dy);
            }
            //DrawTrim_temp(g);
        }
        public void Resize(Point tempP, Point startP, Primitive ori)
        {
            Point centerP;
            int sumX = 0, sumY = 0;
            foreach (Point p in ori.keyPoints)
            {
                sumX += p.X;
                sumY += p.Y;
            }
            centerP = new Point(sumX / keyPoints.Count, sumY / keyPoints.Count);

            float sx, sy;
            sx = (float)(tempP.X - centerP.X) / (float)((startP.X - centerP.X) + 1e-6);
            sy = (float)(tempP.Y - centerP.Y) / (float)((startP.Y - centerP.Y) + 1e-6);

            for (int i = 0; i < keyPoints.Count; i++)
            {
                float x, y;
                x = ori.keyPoints[i].X * sx + centerP.X * (1 - sx);
                y = ori.keyPoints[i].Y * sy + centerP.Y * (1 - sy);

                keyPoints[i] = new Point((int)x, (int)y);
            }
        }

        public void Rotation(Point tempP, Point startP, Primitive ori)
        {
            Point centerP;
            int sumX = 0, sumY = 0;
            foreach (Point p in ori.keyPoints)
            {
                sumX += p.X;
                sumY += p.Y;
            }
            centerP = new Point(sumX / keyPoints.Count, sumY / keyPoints.Count);

            double t;//旋转角theta
            double t1, t2;
            t2 = Math.Atan2((double)(tempP.Y - centerP.Y), (double)(tempP.X - centerP.X));
            t1 = Math.Atan2((double)(startP.Y - centerP.Y), (double)(startP.X - centerP.X));
            t = t2 - t1;

            for (int i = 0; i < keyPoints.Count; i++)
            {
                double x, y;
                x = centerP.X + (ori.keyPoints[i].X - centerP.X) * Math.Cos(t) - (ori.keyPoints[i].Y - centerP.Y) * Math.Sin(t);
                y = centerP.Y + (ori.keyPoints[i].X - centerP.X) * Math.Sin(t) + (ori.keyPoints[i].Y - centerP.Y) * Math.Cos(t);

                keyPoints[i] = new Point((int)x, (int)y);
            }
        }

        public void ClipLine(Point p1, Point p2, Point w1, Point w2, Graphics g)//裁剪单条线段p1p2,w1w2为裁剪窗口
        {
            int xmin = w1.X < w2.X ? w1.X : w2.X;
            int ymin = w1.Y < w2.Y ? w1.Y : w2.Y;
            int xmax = w1.X > w2.X ? w1.X : w2.X;
            int ymax = w1.Y > w2.Y ? w1.Y : w2.Y;

            Point Q0 = new Point();
            Point Q1 = new Point();
            bool flag = false;
            float u1 = 0, u2 = 1;
            int[] p = new int[4];
            int[] q = new int[4];
            float r;
            p[0] = p1.X - p2.X;
            p[1] = p2.X - p1.X;
            p[2] = p1.Y - p2.Y;
            p[3] = -p1.Y + p2.Y;

            q[0] = p1.X - xmin;
            q[1] = xmax - p1.X;
            q[2] = p1.Y - ymin;
            q[3] = ymax - p1.Y;

            for (int i = 0; i < 4; i++)
            {
                r = (float)q[i] / (float)p[i];
                if (p[i] < 0)
                {
                    u1 = Math.Max(u1, r);
                    if (u1 > u2)
                    {
                        flag = true;
                    }
                }
                if (p[i] > 0)
                {
                    u2 = Math.Min(u2, r);
                    if (u1 > u2)
                    {
                        flag = true;
                    }
                }
                if (p[i] == 0 && q[i] < 0)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                return;
            }
            Q0.X = (int)(p1.X - u1 * (p1.X - p2.X));
            Q0.Y = (int)(p1.Y - u1 * (p1.Y - p2.Y));
            Q1.X = (int)(p1.X - u2 * (p1.X - p2.X));
            Q1.Y = (int)(p1.Y - u2 * (p1.Y - p2.Y));

            DrawLine(g, Q0, Q1);
        }

        virtual public void Clip(Point w1, Point w2, Graphics g)
        {

        }

        public Primitive Copy()//复制该图元
        {
            Type t = this.GetType();
            Primitive copy = (Primitive)Activator.CreateInstance(t);
            this.keyPoints.ForEach(p => { copy.keyPoints.Add(p); });

            return copy;
        }
    }
    class PrimitiveLine : Primitive
    {
        override public void DrawTrim_temp(Graphics g)
        {
            DrawTrim(g);

            Point p0 = keyPoints[0];
            Point p1 = keyPoints[1];
            g.FillRectangle(Form1.brush, p0.X, p0.Y, 6, 6);//强调关键点
            g.FillRectangle(Form1.brush, p1.X, p1.Y, 6, 6);
        }

        public override void DrawTrim(Graphics g)
        {
            Point p0 = keyPoints[0];
            Point p1 = keyPoints[1];
            DrawLine(g, p0, p1);

        }
    
        override public void Clip(Point w1, Point w2, Graphics g)
        {
            ClipLine(keyPoints[0], keyPoints[1], w1, w2, g);
        }
    }
        class PrimitiveRectangle : Primitive
        {

        override public void DrawTrim_temp(Graphics g)
        {
            DrawTrim(g);

            foreach (Point p in keyPoints)//强调关键点
            {
                g.FillRectangle(Form1.brush, p.X, p.Y, 6, 6);
            }
        }

        override public void DrawTrim(Graphics g)
        {
            Point p0 = keyPoints[0];
            Point p1 = keyPoints[1];

            int x0 = p0.X;
            int y0 = p0.Y;
            int x1 = p1.X;
            int y1 = p1.Y;

            DrawLine(g, keyPoints[0], keyPoints[2]);//起始点开始，顺时针四个点的下标为0213
            DrawLine(g, keyPoints[2], keyPoints[1]);
            DrawLine(g, keyPoints[1], keyPoints[3]);
            DrawLine(g, keyPoints[3], keyPoints[0]);

        }
        override public void Clip(Point w1, Point w2, Graphics g)
        {
            Point p0 = keyPoints[0];
            Point p1 = keyPoints[1];

            int x0 = p0.X;
            int y0 = p0.Y;
            int x1 = p1.X;
            int y1 = p1.Y;

            ClipLine(keyPoints[0], keyPoints[2], w1, w2, g);//起始点开始，顺时针四个点的下标为0213
            ClipLine(keyPoints[2], keyPoints[1], w1, w2, g);
            ClipLine(keyPoints[1], keyPoints[3], w1, w2, g);
            ClipLine(keyPoints[3], keyPoints[0], w1, w2, g);
        }

    }
        class PrimitiveEllipse : Primitive
        {
            public override void DrawTrim(Graphics g)
            {
                Point p0 = keyPoints[0];
                Point p1 = keyPoints[1];

                int x0 = p0.X;
                int y0 = p0.Y;
                int x1 = p1.X;
                int y1 = p1.Y;

                int xc = (x1 + x0) / 2;
                int yc = (y1 + y0) / 2;
                int ry = (y1 - y0) / 2;
                int rx = (x1 - x0) / 2;
                rx = rx < 0 ? (-rx) : rx;
                ry = ry < 0 ? (-ry) : ry;

                int x = 0, y = ry;//起始点
                int dx = 0;
                int dy = 2 * rx * rx * y;
                float p = (float)(ry * ry + rx * rx * ((float)(-ry) + 0.25) + 0.5);

                g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                while (dx < dy)
                {
                    x++;
                    dx += 2 * ry * ry;
                    if (p < 0)
                        p += ry * ry + dx;
                    else
                    {
                        dy -= 2 * rx * rx;
                        p += ry * ry + dx - dy;
                        y--;
                    }
                    g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                }
                p = (float)(ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - rx * rx * ry * ry + 0.5);
                while (y > 0)
                {
                    y--;
                    dy -= 2 * rx * rx;
                    if (p > 0)
                        p += rx * rx - dy;
                    else
                    {
                        dx += 2 * ry * ry;
                        p += rx * rx - dy + dx;
                        x++;
                    }
                    g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                }
            }
            public override void DrawTrim_temp(Graphics g)
            {
                DrawTrim(g);
                Point p0 = keyPoints[0];
                Point p1 = keyPoints[1];
                g.FillRectangle(Form1.brush, p0.X, p0.Y, 6, 6);//强调关键点
                g.FillRectangle(Form1.brush, p1.X, p1.Y, 6, 6);

            }
        }
    class PrimitivePolygon : Primitive
    {

        public override void DrawTrim(Graphics g)
        {
            for (int i = 1; i < keyPoints.Count; i++)
            {
                DrawLine(g, keyPoints[i - 1], keyPoints[i]);
            }
            DrawLine(g, keyPoints[keyPoints.Count - 1], keyPoints[0]);
        }
        public override void DrawTrim_temp(Graphics g)
        {
            DrawTrim(g);
            foreach (Point p in keyPoints)//强调关键点
            {
                g.FillRectangle(Form1.brush, p.X, p.Y, 6, 6);
            }

        }
        public void DrawTrim_unclosed(Graphics g)//绘制未闭合的多边形
        {
            for (int i = 1; i < keyPoints.Count; i++)
            {
                DrawLine(g, keyPoints[i - 1], keyPoints[i]);
            }
            DrawLine(g, keyPoints[keyPoints.Count - 1], tempPoint);
        }
        override public void Clip(Point w1, Point w2, Graphics g)
        {
            for (int i = 1; i < keyPoints.Count; i++)
            {
                ClipLine(keyPoints[i - 1], keyPoints[i], w1, w2, g);
            }
            ClipLine(keyPoints[keyPoints.Count - 1], keyPoints[0],w1,w2,g);
        }
    }

    class PrimitiveBezier : Primitive
        {
            public override void DrawTrim(Graphics g)
            {//将曲线细分为m个点，逐一绘制，m由控制点数目决定             
                int m, i;
                m = keyPoints.Count * 180;
                for (i = 0; i <= m; i++)
                    CalcuPoints((double)i / (double)m, g);
            }
            public override void DrawTrim_temp(Graphics g)
            {
                DrawTrim(g);
                foreach (Point p in keyPoints)//强调关键点
                {
                    g.FillRectangle(Form1.brush, p.X, p.Y, 6, 6);
                }

            }
            double CalcuFactor(int nn, int k)  //计算多项式的系数C(nn,k)  
            {
                int i;
                double sum = 1;
                for (i = 1; i <= nn; i++)
                    sum *= i;
                for (i = 1; i <= k; i++)
                    sum /= i;
                for (i = 1; i <= nn - k; i++)
                    sum /= i;
                return sum;
            }
            void CalcuPoints(double t, Graphics g)  //计算Bezier曲线上点的坐标  
            {
                double x = 0, y = 0, Ber;
                int k;
                for (k = 0; k < keyPoints.Count; k++)
                {
                    Ber = CalcuFactor(keyPoints.Count - 1, k) * Math.Pow(t, k) * Math.Pow(1 - t, keyPoints.Count - 1 - k);
                    x += keyPoints[k].X * Ber;
                    y += keyPoints[k].Y * Ber;
                }
                g.FillEllipse(Form1.brush, (int)x, (int)y, 2, 2);
            }
        }
        class MyDraw
        {
            public void DrawLine(Graphics g, int x0, int y0, int x1, int y1)
            {
                float pk;
                float m;
                if (x0 == x1)
                {
                    int dy = y1 > y0 ? 1 : -1;//y的增量
                    for (int y = y0; y != y1;)
                    {
                        g.FillEllipse(Form1.brush, x0, y, 2, 2);
                        y += dy;
                    }
                }
                else if (y0 == y1)
                {
                    int dx = x1 > x0 ? 1 : -1;
                    for (int x = x0; x != x1;)
                    {
                        g.FillEllipse(Form1.brush, x, y0, 2, 2);
                        x += dx;
                    }
                }
                else if (y1 - y0 == x1 - x0 || y1 - y0 == -(x1 - x0))
                {
                    int x = x0;
                    int y = y0;
                    int dx = x1 > x ? 1 : -1;
                    int dy = dx * (y1 - y0) / (x1 - x0);
                    for (x = x0; x != x1;)
                    {
                        g.FillEllipse(Form1.brush, x, y, 2, 2);
                        x += dx;
                        y += dy;
                    }
                }
                else//非特殊情况时
                {
                    m = (float)(y1 - y0) / (float)(x1 - x0);//斜率
                    if (m > 1)//将所求直线变换到斜率0~1之间
                    {
                        int temp = x0;
                        x0 = y0;
                        y0 = temp;
                        temp = x1;
                        x1 = y1;
                        y1 = temp;
                        if (x0 > x1)//保证x0为左端点
                        {
                            temp = x0; x0 = x1; x1 = temp;
                            temp = y0; y0 = y1; y1 = temp;
                        }
                    }
                    else if (m >= -1 && m < 0)
                    {
                        y0 = -y0;
                        y1 = -y1;
                        if (x0 > x1)
                        {
                            int temp = x0; x0 = x1; x1 = temp;
                            temp = y0; y0 = y1; y1 = temp;
                        }
                    }
                    else if (m < -1)
                    {
                        int temp = x0;
                        x0 = y0;
                        y0 = -temp;
                        temp = x1;
                        x1 = y1;
                        y1 = -temp;
                        if (x0 > x1)
                        {
                            temp = x0; x0 = x1; x1 = temp;
                            temp = y0; y0 = y1; y1 = temp;
                        }
                    }
                    else//斜率0~1之间
                    {
                        if (x0 > x1)
                        {
                            int temp = x0;
                            x0 = x1; x1 = temp;
                            temp = y0; y0 = y1; y1 = temp;
                        }
                    }

                    int x, y;
                    int dx, dy;
                    dx = x1 - x0;
                    dy = y1 - y0;
                    pk = 2 * dy - dx;
                    g.FillEllipse(Form1.brush, x0, y0, 2, 2);//画起始点
                    for (x = x0 + 1, y = y0; x <= x1; x++)
                    {
                        if (pk <= 0)
                        {
                            if (m > 0 && m <= 1)//变为原直线
                                g.FillEllipse(Form1.brush, x, y, 2, 2);
                            if (m > 1)
                                g.FillEllipse(Form1.brush, y, x, 2, 2);
                            if (m >= -1 && m < 0)
                                g.FillEllipse(Form1.brush, x, -y, 2, 2);
                            if (m < -1)
                                g.FillEllipse(Form1.brush, -y, x, 2, 2);
                            pk += 2 * dy;
                        }
                        else
                        {
                            if (m > 0 && m <= 1)
                                g.FillEllipse(Form1.brush, x, ++y, 2, 2);
                            if (m > 1)
                                g.FillEllipse(Form1.brush, ++y, x, 2, 2);
                            if (m >= -1 && m < 0)
                                g.FillEllipse(Form1.brush, x, -(++y), 2, 2);
                            if (m < -1)
                                g.FillEllipse(Form1.brush, -(++y), x, 2, 2);
                            pk += 2 * dy - 2 * dx;
                        }
                    }
                }
            }
            public void DrawRect(Graphics g, int x0, int y0, int x1, int y1)
            {
                DrawLine(g, x0, y0, x1, y0);
                DrawLine(g, x0, y0, x0, y1);
                DrawLine(g, x1, y1, x1, y0);
                DrawLine(g, x1, y1, x0, y1);
            }
            public void DrawEllip(Graphics g, int x0, int y0, int x1, int y1)
            {
                int xc = (x1 + x0) / 2;
                int yc = (y1 + y0) / 2;
                int ry = (y1 - y0) / 2;
                int rx = (x1 - x0) / 2;
                rx = rx < 0 ? (-rx) : rx;
                ry = ry < 0 ? (-ry) : ry;

                int x = 0, y = ry;//起始点
                int dx = 0;
                int dy = 2 * rx * rx * y;
                float p = (float)(ry * ry + rx * rx * ((float)(-ry) + 0.25) + 0.5);

                g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                while (dx < dy)
                {
                    x++;
                    dx += 2 * ry * ry;
                    if (p < 0)
                        p += ry * ry + dx;
                    else
                    {
                        dy -= 2 * rx * rx;
                        p += ry * ry + dx - dy;
                        y--;
                    }
                    g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                }
                p = (float)(ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - rx * rx * ry * ry + 0.5);
                while (y > 0)
                {
                    y--;
                    dy -= 2 * rx * rx;
                    if (p > 0)
                        p += rx * rx - dy;
                    else
                    {
                        dx += 2 * ry * ry;
                        p += rx * rx - dy + dx;
                        x++;
                    }
                    g.FillEllipse(Form1.brush, xc + x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc + x, yc - y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc + y, 2, 2);
                    g.FillEllipse(Form1.brush, xc - x, yc - y, 2, 2);
                }
            }

            public Bitmap Fill(Bitmap img, Point seed, Color color)
            {
                Stack<Point> stack = new Stack<Point>();
                stack.Push(seed);

                while (stack.Count > 0)
                {
                    Point p = stack.Pop();
                    img.SetPixel(p.X, p.Y, Color.Black);
                    List<Point> neighs = new List<Point>()
                {
                    new Point(p.X + 1, p.Y),
                    new Point(p.X - 1, p.Y),
                    new Point(p.X, p.Y + 1),
                    new Point(p.X, p.Y - 1)
                };
                    neighs.ForEach((u) =>
                    {
                        if (u.X >= 0 && u.Y >= 0 && u.X < img.Width && u.Y < img.Height)
                        {
                            Color c = img.GetPixel(u.X, u.Y);
                            if (c.Equals(color)) stack.Push(u);
                        }

                    });
                }
                return img;
            }

        }
    
}

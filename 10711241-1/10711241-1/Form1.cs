using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10711241_1
{
    public partial class Form1 : Form
    {
        Label[,] block = new Label[10, 10];
        Label[,] block_next1 = new Label[5, 5];
        Label[,] block_next2 = new Label[5, 5];
        Label[,] block_next3 = new Label[5, 5];
        bool[,] full = new bool[10, 10];
        int num=0;
        int bb,pv=0;
        Random r = new Random();
        int x, y;
        //String labels[]=new String[block_next1,block_next2,block_next3];
        //List<Label[,]> ls = new List<Label[,]>();// { block_next1, block_next2, block_next3 };
        List<PictureBox> ls = new List<PictureBox> ();
        List<PictureBox> block_m = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            ls.Add(pictureBox1);
            ls.Add(pictureBox2);
            ls.Add(pictureBox3);
            ls.Add(pictureBox4);
            ls.Add(pictureBox5);
            ls.Add(pictureBox6);
            //ls.Add(block_next2);
            //ls.Add(block_next3);

            /*for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block[i, j] = new Label();
                    block[i, j].Width = 30;
                    block[i, j].Height = 30;
                    block[i, j].BorderStyle = BorderStyle.FixedSingle;
                    block[i, j].BackColor = Color.Black;

                    block[i, j].Left = 150 + 30 * j;
                    block[i, j].Top = 300 - i * 30;
                    block[i, j].Visible = true;

                    block[i, j].Name = "bk" + i.ToString();
                    this.Controls.Add(block[i, j]);

                    full[i, j] = false;
                }
            }*/
            //clearall();
            //newblock();

            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (PictureBox ctrl in ls)
            {
                ctrl.MouseMove += ctrl_MouseMove;
                ctrl.MouseDown += ctrl_MouseDown;
                ctrl.MouseUp += ctrl_MouseUp;

                
                ctrl.MouseLeave += ctrl_MouseLeave;
                ctrl.MouseEnter += ctrl_MouseEnter;
                ctrl.MouseHover += ctrl_MouseHover;
            }
            label1.Text = "pv= " + pv.ToString();
            

            //this.block[,].MouseHover+=Form1_MouseHover;
            //block[0, 0].MouseHover += new EventHandler(this.Form1_MouseHover);
        }

        void ctrl_MouseEnter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //puzzle(x, y, 1);
        }

        void ctrl_MouseLeave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //puzzle(x, y, 2);
        }

        void ctrl_MouseHover(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox ctrl = sender as PictureBox;
            //throw new NotImplementedException();
            //puzzle(x, y);
            ctrl.Height += 3;
            ctrl.Width += 3;
            puzzle(ctrl.Left, ctrl.Top,ctrl);

            //ctrl.Visible = false;//


            if (pv == 0)
            {
                newblock();
            }
            check();

            clear();

            
        }

        void newblock()
        {

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;

            pv = 3;
            //int rr = r.Next(1, 5);
            int[] x = new int[3];
            for (int i = 0; i < 3; i++)
            {
                x[i] = r.Next(1, 6);
                for (int j = 0; j < i; j++)
                {
                    while (x[j] == x[i])
                    {
                        j = 0;
                        x[i] = r.Next(1, 6);
                    }

                }
                //

                creat(x[0]);
                creat(x[1]);
                creat(x[2]);
                label1.Text +="\n"+ x[0].ToString() + "\n" + x[1].ToString() + "\n" + x[2].ToString();
            }
        }

        void Form1_MouseHover(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //puzzle(x, y);
        }

        void puzzle(int x, int y,PictureBox pp)
        {
            //pv--;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((y < block[i, j].Bottom && y > block[i, j].Top) && (x > block[i, j].Left && x < block[i, j].Right))
                    {

                        if (pp == pictureBox1 && (i >= 0 && i < 10) && (j >= 0 && j + 3 < 10))
                        {
                            if (full[i, j] == false && full[i, j + 1] == false && full[i, j + 2] == false && full[i, j + 3] == false)
                            {
                                block[i, j].BackColor = Color.SkyBlue;
                                block[i, j + 1].BackColor = Color.SkyBlue;
                                block[i, j + 2].BackColor = Color.SkyBlue;
                                block[i, j + 3].BackColor = Color.SkyBlue;

                                full[i, j] = true;
                                full[i, j + 1] = true;
                                full[i, j + 2] = true;
                                full[i, j + 3] = true;
                                label1.Text = "pictureBox1";

                                pictureBox1.Left = 510;
                                pictureBox1.Top = 30;
                                pictureBox1.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                        if (pp == pictureBox2 && (i-1 >= 0 && i < 10) && (j >= 0 && j + 2 < 10))
                        {
                            if (full[i, j] == false && full[i - 1, j] == false && full[i - 1, j + 1] == false && full[i - 1, j + 2] == false)
                            {
                                block[i, j].BackColor = Color.Blue;
                                block[i - 1, j].BackColor = Color.Blue;
                                block[i - 1, j + 1].BackColor = Color.Blue;
                                block[i - 1, j + 2].BackColor = Color.Blue;

                                full[i, j] = true;
                                full[i - 1, j] = true;
                                full[i - 1, j + 1] = true;
                                full[i - 1, j + 2] = true;
                                label1.Text = "pictureBox2";

                                pictureBox2.Left = 510;
                                pictureBox2.Top = 90;
                                pictureBox2.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                        if (pp == pictureBox3 && (i - 1 >= 0 && i < 10) && (j >= 0 && j + 2 < 10))
                        {
                            if (full[i, j + 2] == false && full[i - 1, j] == false && full[i - 1, j + 1] == false && full[i - 1, j + 2] == false)
                            {
                                block[i, j + 2].BackColor = Color.Orange;
                                block[i - 1, j].BackColor = Color.Orange;
                                block[i - 1, j + 1].BackColor = Color.Orange;
                                block[i - 1, j + 2].BackColor = Color.Orange;

                                full[i, j + 2] = true;
                                full[i - 1, j] = true;
                                full[i - 1, j + 1] = true;
                                full[i - 1, j + 2] = true;
                                label1.Text = "pictureBox3";

                                pictureBox3.Left = 510;
                                pictureBox3.Top = 180;
                                pictureBox3.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                        if (pp == pictureBox4 && (i - 1 >= 0 && i < 10) && (j >= 0 && j + 1 < 10))
                        {
                            if (full[i, j] == false && full[i - 1, j + 1] == false && full[i, j + 1] == false && full[i - 1, j] == false)
                            {
                                block[i, j].BackColor = Color.Yellow;
                                block[i, j + 1].BackColor = Color.Yellow;
                                block[i - 1, j].BackColor = Color.Yellow;
                                block[i - 1, j + 1].BackColor = Color.Yellow;

                                full[i, j] = true;
                                full[i, j + 1] = true;
                                full[i - 1, j] = true;
                                full[i - 1, j + 1] = true;
                                label1.Text = "pictureBox4";

                                pictureBox4.Left = 510;
                                pictureBox4.Top = 270;
                                pictureBox4.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                        if (pp == pictureBox5 && (i - 1 >= 0 && i < 10) && (j >= 0 && j + 2 < 10))
                        {
                            if (full[i, j] == false && full[i - 1, j + 1] == false && full[i, j + 1] == false && full[i - 1, j + 2] == false)
                            {
                                block[i, j].BackColor = Color.Red;
                                block[i, j + 1].BackColor = Color.Red;
                                block[i - 1, j + 1].BackColor = Color.Red;
                                block[i - 1, j + 2].BackColor = Color.Red;

                                full[i, j] = true;
                                full[i, j + 1] = true;
                                full[i - 1, j + 1] = true;
                                full[i - 1, j + 2] = true;
                                label1.Text = "pictureBox5";

                                pictureBox5.Left = 510;
                                pictureBox5.Top = 360;
                                pictureBox5.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                        if (pp == pictureBox6 && (i >= 0 && i < 10) && (j >= 0 && j < 10))
                        {
                            if (full[i, j] == false)
                            {
                                block[i, j].BackColor = Color.Gray;

                                full[i, j] = true;
                                label1.Text = "pictureBox6";

                                pictureBox6.Left = 510;
                                pictureBox6.Top = 450;
                                pictureBox6.Visible = false;
                                //pv++;
                                pv--;
                            }

                        }

                         //pictureBox2.Location
                    }
                }
            }
            //label3.Text = "x=" + x.ToString() + "\ny=" + y.ToString();
        }

        int[] esraes_i = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] esraes_j = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        void check()
        {

            for (int i = 0; i < 10; i++)
            {
                if(full[i, 0] == true)
                {
                    bool line = true;
                    for (int j = 0; j < 10; j++)
                    {
                        if (full[i, j] != true)
                        {
                            line = false;
                            break;
                        }
                    }
                    if (line == true)
                    {
                        num++;
                        esraes_i[i] = 1;
                    }

                }
            }

            for (int j = 0; j < 10; j++)
            {
                if (full[0, j] == true)
                {
                    bool line = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (full[i, j] != true)
                        {
                            line = false;
                            break;
                        }
                    }
                    if (line == true)
                    {
                        num++;
                        esraes_j[j] = 1;
                    }

                }
            }
            //label3.Text = "esraes_i=" + esraes_i.ToString() + "\nesraes_j=" + esraes_j.ToString();
            point.Text = "分數=" + num.ToString();
        }
        int cc = 0;
        void clear()
        {
            for (int i = 0; i < 10; i++)
            {
                if (esraes_i[i] == 1)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        block[i, j].BackColor = Color.Black;
                        full[i, j] = false;
                    }
                }
                esraes_i[i] = 0;
            }
            for (int j = 0; j < 10; j++)
            {
                if (esraes_j[j] == 1)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        block[i, j].BackColor = Color.Black;
                        full[i, j] = false;
                    }
                    esraes_j[j] = 0;
                }
            }
            cc++;
            label2.Text = "clear=" + cc.ToString();
        }

        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //x = e.X;
            //y = e.Y;

            //label3.Text = "x=" + x.ToString() + "\ny=" + y.ToString();
        }

        private MouseEventArgs _pos = null;
        void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox ctrl = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                _pos = e;
            }
            ctrl.Height -= 3;
            ctrl.Width -= 3;
            //puzzle(x, y);
        }

        void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            PictureBox ctrl = sender as PictureBox;
            if (ctrl.Capture && e.Button == MouseButtons.Left)
            {
                //DoDragDrop(ctrl, DragDropEffects.Move);
                ctrl.Top = e.Y + ctrl.Location.Y -_pos.Y;
                ctrl.Left = e.X + ctrl.Location.X -_pos.X;
            }

            x = this.PointToClient(new Point(MousePosition.X, MousePosition.Y)).X;
            y = this.PointToClient(new Point(MousePosition.X, MousePosition.Y)).Y;
            
            //label3.Text = "x=" + x.ToString() + "\ny=" + y.ToString();

            //puzzle(x, y);
        }

        PictureBox _ctrl = null;
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            _ctrl = e.Data.GetData(e.Data.GetFormats(true)[0]) as PictureBox;
            if (_ctrl != null)
            {
                e.Effect = (_ctrl == null) ? DragDropEffects.None : DragDropEffects.Move;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (_ctrl != null)
            {
                _ctrl.Top = this.PointToClient(new Point(e.X, e.Y)).Y;
                _ctrl.Left = this.PointToClient(new Point(e.X, e.Y)).X;
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //label3.Text = "x=" + x.ToString() + "\ny=" + y.ToString();

        }


        void creat(int rn)
        {
            switch (rn)
            {
                case 1:
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    pictureBox2.Visible = true;
                    break;
                case 3:
                    pictureBox3.Visible = true;
                    break;
                case 4:
                    pictureBox4.Visible = true;
                    break;
                case 5:
                    pictureBox5.Visible = true;
                    break;
                case 6:
                    pictureBox6.Visible = true;
                    break;
            }
        }




        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }



        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block[i, j] = new Label();
                    block[i, j].Width = 30;
                    block[i, j].Height = 30;
                    block[i, j].BorderStyle = BorderStyle.FixedSingle;
                    block[i, j].BackColor = Color.Black;

                    block[i, j].Left = 150 + 30 * j;
                    block[i, j].Top = 300 - i * 30;
                    block[i, j].Visible = true;

                    block[i, j].Name = "bk" + i.ToString();
                    this.Controls.Add(block[i, j]);

                    full[i, j] = false;
                }
            }
            newblock();
        }

        private void reset_Click(object sender, EventArgs e)
        {

            clearall();

            newblock();
        }

        void clearall()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block[i, j].BackColor = Color.Black;

                    block[i, j].Name = "bk" + i.ToString();

                    full[i, j] = false;
                }
            }
        }






    }
}

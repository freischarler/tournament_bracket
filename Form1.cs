using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixT
{
    public struct Competitor
    {
        public string name;
        public string team;

        public Competitor(string N, string T)
        {
            name = N;
            team = T;
        }

    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var today = new DateTime().DayOfYear;

            //string[,] data_ex = { { "Martin","Ralph" }, { "Nico", "Ralph" } , { "Chapo","Ralph"},{ "Andres", "GB"} , { "Villamor", "360"} };

        }

        Competitors c = new Competitors();
        private void Run_Click(object sender, EventArgs e)
        {
            string[] NT;
            string text = cList.Text;
            string[] a = text.Split('\n');
            string[,] data = new string[a.Length,2];
            
            for (int i = 0; i< a.Length; i++)
            {
                try
                {
                    NT = a[i].Split(',');
                    data[i, 0] = NT[0].Trim();
                    data[i, 1] = NT[1].Trim();
                }
                catch { }
            }


            c.AddCompetitors(data);

            //c.PrintCompetitors();

            

            //c.SetSplit(checkBoxSeparar.Checked);


            //c.PrintCompetitors();

            c.Shuffle();
            //c.ShuffleSides();

            //c.GenerateSides();
            c.GenerateQualifers();

            Console.WriteLine("A SIDE:");
           for(int i=0; i< c.Aside.Length; i++)
                Console.WriteLine(c.Aside[i].name);

            Console.WriteLine("B SIDE:");
            for (int i = 0; i < c.Aside.Length; i++)
                Console.WriteLine(c.Bside[i].name);

            Aside.Items.Clear();

            for (int i = 0; i < c.Aside.Length; i++)
            {
                if (i == (c.Aside.Length - 1))
                {
                    Aside.Items.Add(c.Aside[i].name + " (" + c.Aside[i].team + ")");
                }
                else
                {
                    if(c.Aside[i + 1].name != null)
                    {
                        if(c.Aside[i].name != null && c.Aside[i + 1].name != null)
                            Aside.Items.Add(c.Aside[i].name + " (" + c.Aside[i].team + ")" + " vs. " + c.Aside[i + 1].name + " (" + c.Aside[i + 1].team + ")");
                        else if (c.Aside[i].name == null && c.Aside[i + 1].name != null)
                            Aside.Items.Add(c.Aside[i + 1].name + " (" + c.Aside[i + 1].team + ")");
                        else if (c.Aside[i + 1].name == null && c.Aside[i].name != null)
                            Aside.Items.Add(c.Aside[i].name + " (" + c.Aside[i + 1].team + ")");
                    }
                    else if(c.Aside[i].name != null)
                            Aside.Items.Add(c.Aside[i].name + " " + " (" + c.Aside[i].team + ")");
                    else
                        Aside.Items.Add("-");

                }

                i++;
            }

            Bside.Items.Clear();

            for (int i = 0; i < c.Bside.Length; i++)
            {
                if (i == (c.Bside.Length - 1))
                {
                    Bside.Items.Add(c.Bside[i].name + " (" + c.Bside[i].team + ")");
                }
                else
                {
                    if (c.Bside[i + 1].name != null)
                    {
                        if (c.Bside[i].name != null && c.Bside[i + 1].name != null)
                            Bside.Items.Add(c.Bside[i].name + " (" + c.Bside[i].team + ")" + " vs. " + c.Bside[i + 1].name + " (" + c.Bside[i + 1].team + ")");
                        else if (c.Bside[i].name == null && c.Bside[i + 1].name != null)
                            Bside.Items.Add(c.Bside[i + 1].name + " (" + c.Bside[i + 1].team + ")");
                        else if (c.Bside[i + 1].name == null && c.Bside[i].name != null)
                            Bside.Items.Add(c.Bside[i].name + " (" + c.Bside[i + 1].team + ")");
                    }
                    else if (c.Bside[i].name != null)
                            Bside.Items.Add(c.Bside[i].name + " " + " (" + c.Bside[i].team + ")");
                    else
                        Bside.Items.Add("-");
                }
                i++;
            }

            //c.PrintAside();

            //c.PrintAside();

        }

        void CreateSmallKey(XGraphics gfx, int x, int y, int Width, int Height)
        {
            XRect r;
            r = new XRect(x, y, 1, Height+1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x - 10, y, 10, 1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x - 10, y + Height, 10, 1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x, y + Height / 2, Width, 1);
            gfx.DrawRectangle(XBrushes.Black, r);
        }

        void CreateBigKey(XGraphics gfx, int x, int y, int Width, int Height)
        {
            XRect r;
            r = new XRect(x, y, 1, Height+1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x-10, y, Width, 1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x-10, y+Height, Width, 1);
            gfx.DrawRectangle(XBrushes.Black, r);

            r = new XRect(x, y+Height /2 , Width, 1);
            gfx.DrawRectangle(XBrushes.Black, r);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 15, XFontStyle.Regular);
            XFont NameFont = new XFont("Times New Roman", 11, XFontStyle.Regular);
            XFont EquipeFont = new XFont("Times New Roman", 7, XFontStyle.Regular);

            XFont T_font = new XFont("Times New Roman", 18, XFontStyle.Bold);
            XFont t_font = new XFont("Times New Roman", 18, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);


            /*page.Width = "15in";
            page.Height = "6in";*/

            //title
            // Draw the text
            try
            {
                gfx.DrawString(txtTournament.Text, T_font, XBrushes.Black,
                new XRect(40, 20, page.Width, page.Height),
                XStringFormats.TopLeft);
            }
            catch (Exception)
            {
                //
            }

            // Draw the text
            try
            {
                gfx.DrawString("Cinturón: " + txtBelt.Text, t_font, XBrushes.Black,
                new XRect(40, 50, page.Width, page.Height),
                XStringFormats.TopLeft);
            }
            catch (Exception)
            {
                //
            }

            try
            {
                if (ckAbs.CheckState.ToString() == "Checked")
                    gfx.DrawString("Categoría: " + "Absoluto", t_font, XBrushes.Black,
                new XRect(240, 50, page.Width, page.Height),
                XStringFormats.TopLeft);
                else
                    gfx.DrawString("Categoría: " + txtWeight.Text, t_font, XBrushes.Black,
                new XRect(240, 50, page.Width, page.Height),
                XStringFormats.TopLeft);
            }
            catch (Exception)
            {
                //
            }

            // Draw the MAT TEXT
            try
            {
                gfx.DrawString("Mat °: " + txtMat.Text, t_font, XBrushes.Black,
                new XRect(500, 50, page.Width, page.Height),
                XStringFormats.TopLeft);
            }
            catch (Exception)
            {
                //
            }

            if (c.Aside.Length == 1)
            {
                int x = 170;
                int y = 85;

                for (int i = 0; i < 1; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 44, 70, 22);
                }
            }
            else if(c.Aside.Length == 4 )
            {
                int x = 170;
                int y = 85;

                for (int i = 0; i < 4; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 44, 70, 22);
                }

                x = 250;
                y += 11;
                for (int i = 0; i < 2; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 88, 70, 44);
                }

                x = 330;
                y += 22;
                for (int i = 0; i < 1; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 176, 70, 88);
                }
            }
            else if (c.Aside.Length == 2)
            {
                int x = 170;
                int y = 85;

                for (int i = 0; i < 2; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 44, 70, 22);
                }

                x = 250;
                y += 11;
                for (int i = 0; i < 1; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 88, 70, 44);
                }
            }
            else if(c.Aside.Length == 8)
            {
                int x = 170;
                int y = 85;

                for (int i = 0; i < 8; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 44, 70, 22);
                }

                x = 250;
                y += 11;
                for (int i = 0; i < 4; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 88, 70, 44);
                }

                x = 330;
                y += 22;
                for (int i = 0; i < 2; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 176, 70, 88);
                }

                x = 410;
                y += 44;
                for (int i = 0; i < 1; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 352, 70, 176);
                }
            }
            else if (c.Aside.Length == 16)
            {
                int x = 170;
                int y = 85;
                //XRect r;


                //LADO A

                for (int i = 0; i < 16; i++)
                {
                    CreateSmallKey(gfx, x, y+i*44, 70, 22);
                }

                x = 250;
                y += 11;
                for (int i = 0; i < 8; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 88, 70, 44);
                }

                x = 330;
                y += 22;
                for (int i = 0; i < 4; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 176, 70, 88);
                }

                x = 410;
                y += 44;
                for (int i = 0; i < 2; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 352, 70, 176);
                }

                x = 490;
                y += 88;
                for (int i = 0; i < 1; i++)
                {
                    CreateSmallKey(gfx, x, y + i * 704, 70, 352);
                }

            }
            int _y=0;
            for(int i=0; i < c.Aside.Length; i++)
            {
                XRect rect = new XRect(40, 22*i+(80), 120, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rect);
                //tf.Alignment = ParagraphAlignment.Left;

                XRect rectNameLabel = new XRect(42, 22 * i + (80), 118, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rectNameLabel);

                XRect rectEquipe = new XRect(42, 22 * i + (80)+12, 118, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);

                XRect rectEquipeLabel = new XRect(44, 22 * i + (80) + 12, 112, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);

                try
                {
                    tf.DrawString(c.Aside[i].name.ToString(), NameFont, XBrushes.Black, rectNameLabel, XStringFormats.TopLeft);
                    tf.DrawString(c.Aside[i].team.ToString(), EquipeFont, XBrushes.Black, rectEquipeLabel, XStringFormats.TopLeft);
                }
                catch (Exception)
                {

                }
                _y = 20 * i + (50 + 100);

            }

            for (int i = c.Bside.Length; i < c.Bside.Length*2; i++)
            {
                //XRect rect = new XRect(40, 22 * i + _y, 118, 20);
                //gfx.DrawRectangle(XBrushes.SeaShell, rect);

                XRect rect = new XRect(40, 22 * i + (80), 120, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rect);
                //tf.Alignment = ParagraphAlignment.Left;

                XRect rectNameLabel = new XRect(42, 22 * i + (80), 118, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rectNameLabel);

                XRect rectEquipe = new XRect(42, 22 * i + (80) + 12, 118, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);

                XRect rectEquipeLabel = new XRect(44, 22 * i + (80) + 12, 112, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);


                try
                {
                    tf.DrawString(c.Bside[i-c.Bside.Length].name.ToString(), NameFont, XBrushes.Black, rectNameLabel, XStringFormats.TopLeft);
                    tf.DrawString(c.Bside[i-c.Bside.Length].team.ToString(), EquipeFont, XBrushes.Black, rectEquipeLabel, XStringFormats.TopLeft);
                }
                catch (Exception)
                {

                }
                //_y += 20 * i;
            }

            /*_y += -18;
            for (int i = 0; i < c.Bside.Length; i++)
            {
                //XRect rect = new XRect(40, 22 * i + _y, 118, 20);
                //gfx.DrawRectangle(XBrushes.SeaShell, rect);

                XRect rect = new XRect(40, 22 * i + _y, 118, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rect);
                //tf.Alignment = ParagraphAlignment.Left;

                XRect rectNameLabel = new XRect(42, 22 * i + _y, 118, 20);
                gfx.DrawRectangle(XBrushes.SeaShell, rectNameLabel);

                XRect rectEquipe = new XRect(42, 22 * i + _y+12, 116, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);

                XRect rectEquipeLabel = new XRect(44, 22 * i + _y+12, 112, 8);
                gfx.DrawRectangle(XBrushes.White, rectEquipe);


                try
                {
                    tf.DrawString(c.Bside[i].name.ToString(), NameFont, XBrushes.Black, rectNameLabel, XStringFormats.TopLeft);
                    tf.DrawString(c.Bside[i].team.ToString(), EquipeFont, XBrushes.Black, rectEquipeLabel, XStringFormats.TopLeft);
                }
                catch (Exception)
                {

                }
                //_y += 20 * i;
            }*/

            try
            {
                // Save the document...
                string date = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");  
                string filename = txtBelt.Text +" "+txtWeight.Text +" "+ date + ".pdf";
                Console.WriteLine(filename);    
                document.Save(filename);
                // ...and start a viewer.
                Process.Start(filename);
            }
            catch
            {
                //
            }
        }

        void CreateSmallBlock(XGraphics gfx, XTextFormatter tf, XFont font,  int x, int y)
        {
            XRect r = new XRect(x, y, 80, 20);
            gfx.DrawRectangle(XBrushes.SeaShell, r);
            tf.DrawString("", font, XBrushes.Black, r, XStringFormats.TopLeft);
        }

        private void ckAbs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAbs.CheckState.ToString() == "Checked")
            {
                txtWeight.Enabled = false;
            }
            else
                txtWeight.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*public Competitor[] AddList(string[,] data)
        {
            Competitor[] cs;

            for(int i = 0; i < data.Length; i++)
            {
                List<Competitor> list = new List<Competitor>();
                Competitor a = new Competitor(data[i][0], data[i][1]);
                list.Add(a);
                cs = list.ToArray();
            }

            return cs;
        }*/
    }
}

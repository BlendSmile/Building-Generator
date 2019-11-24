using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Drawing.Imaging;

namespace BuildingGenerator
{
    //good luck trying to understand this codes! Dont have time to polish/make it understandable it, that's why i make it open source, so everyone who
    //have time can polish it. Thank you! And again good luck!
    //codes by: Blend_Smile aka. blend_UwU aka. Muhammad Alif Vardha    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;

        //when the form load
        private void Form1_Load(object sender, EventArgs e)
        {
            //set the color as default so it doesnt go black when the user start the application (for more understanding, delete this codes and see wut happen next)
            RoofColor.Color = Color.Red;
            HouseColor.Color = Color.Orange;
            WindowsColor.Color = Color.LightBlue;
            PilarColor.Color = Color.Brown;
            DoorColor.Color = Color.SaddleBrown;
        }

        private void Preview_Paint(object sender, PaintEventArgs e)
        {
            //main drawing function
            #region mainDraw
            // Create a Bitmap image in memory and set its CompositingMode
            bmp = new Bitmap(300, 300, PixelFormat.Format32bppArgb);
            Graphics gBmp = Graphics.FromImage(bmp);
            gBmp.CompositingMode = CompositingMode.SourceCopy;

            //draw the house based on control       

            #region setColor
            //sets the colors
            Brush pilarBrush = new SolidBrush(PilarColor.Color);
            Brush baseBrush = new SolidBrush(HouseColor.Color);
            Brush windowsBrush = new SolidBrush(WindowsColor.Color);
            Brush roofBrush = new SolidBrush(RoofColor.Color);
            Brush doorBrush = new SolidBrush(DoorColor.Color);
            #endregion


            #region HouseMain

            gBmp.FillRectangle(baseBrush, 150 - widthBar.Value * 5 / 2 /*to make the square always centered when it resized*/, 150 - heightBar.Value * 5 / 2, widthBar.Value * 5, heightBar.Value * 5); //make the house base as square
            #endregion

            #region drawWindows
            //draw the windows between pillars

            if (windowsValue.Value == 1)//set the windows to be 2 (in)
            {
                gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 2 / 3 + 3 /*to make the windows x position always follows the main house width*/ - windowsWidth.Value * 2 / 2 /*make it centered when resized*/, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 2 / 3 - 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows

                for (int i = 0; i < windowsYValue.Value; i++)
                {
                    gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 2 / 3 + 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                    gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 2 / 3 - 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                }
            }
            if (windowsValue.Value == 2)//set the windows to  be 2 (out)
            {
                gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows            
                for (int i = 0; i < windowsYValue.Value; i++)
                {
                    gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                    gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows                        
                }
            }
            if (windowsValue.Value == 3)//set the windows to be 4 (in and out)
            {
                gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 2 / 3 + 3 /*to make the windows x position always follows the main house width*/ - windowsWidth.Value * 2 / 2 /*make it centered when resized*/, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows            
                gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 2 / 3 - 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2 + 3, windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows                                                                        

                for (int i = 0; i < windowsYValue.Value; i++)
                {
                    gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 2 / 3 + 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2);
                    gBmp.FillRectangle(windowsBrush, 150 - widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows
                    gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows            
                    gBmp.FillRectangle(windowsBrush, 150 + widthBar.Value * 5 / 2 / 3 - 3 - windowsWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / windowsHeight.Value * 2 + 3 * (i + (i * windowsHeight.Value)), windowsWidth.Value * 2, windowsHeight.Value * 2); //make the windows                                                                                                  
                }
            }
            #endregion

            #region drawDoor
            gBmp.FillRectangle(doorBrush, 150 - doorWidth.Value * 5 / 2 - widthBar.Value * 4 / 3 + 2, 160 + heightBar.Value * 2 - doorYPos.Value / 5 - doorHeight.Value * 2, doorWidth.Value * 5 + widthBar.Value * 5 / 2, doorHeight.Value * 2); //draw the door                                                           
            #endregion

            #region drawPilar
            //the pilar value must be even number, 1 = 2, 2 = 4, 3 = 6...

            if (PilarValue.Value == 1)//adust the pilar value to be 2
            {
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2 /*make it centered when resized*/, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
            }
            if (PilarValue.Value == 2)//adust the pilar value to be 4
            {
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
            }
            if (PilarValue.Value == 3)//adust the pilar value to be 6
            {
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 - widthBar.Value * 5 / 2 / 8 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 / 2 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar                
                gBmp.FillRectangle(pilarBrush, 150 + widthBar.Value * 5 / 2 / 8 - PilarWidth.Value * 2 / 2, 150 - heightBar.Value * 5 / 2, PilarWidth.Value * 2, heightBar.Value * 5); //make the pilar                
            }
            #endregion

            #region drawRoof            
            gBmp.FillRectangle(roofBrush, 150 - roofWidthDown.Value * 5 / 2 - widthBar.Value * 4 / 3 /*to make the square always centered when it resized*/, 150 + roofYPos.Value * 2 - heightBar.Value * 5 / 2, roofWidthDown.Value * 5 + widthBar.Value * 5 / 2, roofHeight.Value * 2); //draw the bottom line of the roof            
            gBmp.FillRectangle(roofBrush, 150 - roofWidthUp.Value * 5 / 2 - widthBar.Value * 4 / 3, 150 - roofHeight.Value * 2 + roofYPos.Value * 2 - heightBar.Value * 5 / 2, roofWidthUp.Value * 5 + widthBar.Value * 5 / 2, roofHeight.Value * 2); //draw the upper line of the roof                                                            

            #endregion

            //preview the bitmap in a picturebox
            e.Graphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
            #endregion
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if(exportFormat.Text == "PNG")
            {
                bmp.Save(@fileDir.Text + fileName.Text + ".png", ImageFormat.Png); 
            }
            if (exportFormat.Text == "Jpeg")
            {
                bmp.Save(@fileDir.Text + fileName.Text + ".jpg", ImageFormat.Jpeg);
            }
            if (exportFormat.Text == "Bitmap")
            {
                bmp.Save(@fileDir.Text + fileName.Text + ".bmp", ImageFormat.Bmp);
            }
        }

        //every tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            //refresh the preview pic every tick
            Preview.Refresh();
            //set the color of color preview same as the main colors
            ColorPrevHouse.BackColor = HouseColor.Color;
            ColorPrevPilar.BackColor = PilarColor.Color;
            ColorPrevWindows.BackColor = WindowsColor.Color;
            colorPrevRoof.BackColor = RoofColor.Color;
            doorColorPrev.BackColor = DoorColor.Color;
        }
 
        #region setColor
        //show color dialog when button is pressed
        private void button1_Click(object sender, EventArgs e)
        {            
            HouseColor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PilarColor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsColor.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RoofColor.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DoorColor.ShowDialog();
        }
        #endregion

    }
}

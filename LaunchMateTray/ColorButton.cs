using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchMateTray
{

    public class ColorButton : Button
    {
        public Color BtnColor = Color.Black;

        public ColorButton() : base()
        {
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            ColorDialog clrDlg = new ColorDialog();
            clrDlg.Color = BtnColor;
            clrDlg.AllowFullOpen = true;
            clrDlg.AnyColor = true;
            clrDlg.SolidColorOnly = true;

            int clr = BtnColor.R;
            clr = (clr << 8) + BtnColor.G;
            clr = (clr << 8) + BtnColor.B;

            clrDlg.CustomColors = new int[] { clr };
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                BtnColor = clrDlg.Color;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            base.OnPaint(e);
            Rectangle r = e.ClipRectangle;
            Rectangle r2 = r;
            r2.Inflate(new Size(-1, -1));

            e.Graphics.DrawRectangle(Pens.Black,r);
            e.Graphics.DrawRectangle(Pens.White, r2);

            e.Graphics.FillRectangle(new SolidBrush(BtnColor),r2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchMateTray
{
    public class LMTColorTable : ProfessionalColorTable
    {
        protected ColorSettings? colors;

        public LMTColorTable(ColorSettings inputClrs)
        {
            colors = inputClrs;
            UseSystemColors = false;
        }

        public void SetColorSettings(ColorSettings inputClrs)
        {
            colors = inputClrs;
        }

        public override Color MenuBorder
        {
            
            get {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr); 
            }
        }
        public override Color MenuItemBorder
        {
            get {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }
        public override Color MenuItemSelected
        {
            get {
                int clr = Int32.Parse(colors != null ? colors["selectclr"] : LaunchMateTraySettings.defaultColors["selectclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }
        public override Color ToolStripDropDownBackground
        {
            get {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                int clr = Int32.Parse(colors != null ? colors["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
                return Color.FromArgb(clr);
            }
        }
    }
    public class LMTContextMenuRenderer: ToolStripProfessionalRenderer
    {
        protected ColorSettings? colors;

        public LMTContextMenuRenderer(ColorSettings inputClrs) : base(new LMTColorTable(inputClrs))
        {
            colors = inputClrs;
        }

        public void SetColorSettings(ColorSettings inputClrs)
        {
            colors = inputClrs;
            ((LMTColorTable)ColorTable).SetColorSettings(inputClrs);
        }

        protected override void OnRenderMenuItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                int clr = Int32.Parse(colors != null ? colors["selectclr"] : LaunchMateTraySettings.defaultColors["selectclr"], NumberStyles.AllowHexSpecifier);
                Color selClr = Color.FromArgb(clr); 
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(selClr), rectangle);
                e.Graphics.DrawRectangle(new Pen(selClr), rectangle);
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        protected override void OnRenderItemText(System.Windows.Forms.ToolStripItemTextRenderEventArgs e)
        {
            String clrKey = "textclr";
            if (e.Item != null && e.Item.Selected) { clrKey = "seltextclr"; }
            int clr = Int32.Parse(colors != null ? colors[clrKey] : LaunchMateTraySettings.defaultColors[clrKey], NumberStyles.AllowHexSpecifier);
            Color txtClr = Color.FromArgb(clr);
            e.Item.ForeColor = txtClr;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            String clrKey = e.Item.Selected ? "seltextclr" : "textclr";
            int clr = Int32.Parse(colors != null ? colors[clrKey] : LaunchMateTraySettings.defaultColors[clrKey], NumberStyles.AllowHexSpecifier);
            Color txtClr = Color.FromArgb(clr);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
            r.Inflate(-2, -6);
            e.Graphics.DrawLines(new Pen(txtClr), new Point[]{
            new Point(r.Left, r.Top),
            new Point(r.Right, r.Top + r.Height /2),
            new Point(r.Left, r.Top+ r.Height)});
        }

    }

    public class LaunchMateTrayContextMenuStrip: ContextMenuStrip
    {
        public LaunchMateTrayContextMenuStrip(ColorSettings inputClrs)
        {
            Renderer = new LMTContextMenuRenderer(inputClrs);
        }

        public void SetColorSettings(ColorSettings inputClrs)
        {
            ((LMTContextMenuRenderer)Renderer).SetColorSettings(inputClrs);
        }
    }
}

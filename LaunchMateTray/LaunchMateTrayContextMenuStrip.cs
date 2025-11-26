using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchMateTray
{
    public class LMTColorTable : ProfessionalColorTable
    {
        public LMTColorTable()
        {
            this.UseSystemColors = false;
        }
        public override Color MenuBorder
        {
            get { return Color.Black; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }
        public override Color MenuItemSelected
        {
            get { return Color.DarkGray; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.Black; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.Black; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.Black; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.Black; }
        }
    }
    public class LMTContextMenuRenderer: ToolStripProfessionalRenderer
    {
        public LMTContextMenuRenderer() : base(new LMTColorTable())
        { 
        }

        protected override void OnRenderMenuItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(Brushes.DarkSlateGray, rectangle);
                e.Graphics.DrawRectangle(Pens.DarkSlateGray, rectangle);
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        protected override void OnRenderItemText(System.Windows.Forms.ToolStripItemTextRenderEventArgs e)
        {
            e.Item.ForeColor = Color.White;
            base.OnRenderItemText(e);
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
            r.Inflate(-2, -6);
            //var penClr = e.Item != null && e.Item.Selected ? Pens.Black : Pens.White;
            e.Graphics.DrawLines(Pens.White, new Point[]{
            new Point(r.Left, r.Top),
            new Point(r.Right, r.Top + r.Height /2),
            new Point(r.Left, r.Top+ r.Height)});
        }

    }

    public class LaunchMateTrayContextMenuStrip: ContextMenuStrip
    {
        public LaunchMateTrayContextMenuStrip()
        {
            this.Renderer = new LMTContextMenuRenderer();
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YourNamespace
{
    public class CustomTextBox : TextBox
    {
        private int _cornerRadius = 15;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
                path.AddArc(new Rectangle(this.Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
                path.AddArc(new Rectangle(this.Width - _cornerRadius, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
                path.AddArc(new Rectangle(this.Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
                path.AddArc(new Rectangle(this.Width - _cornerRadius, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Visual_Storyline.Characters.Characterfield_options
{
    public partial class CustomButton : Control
    {
        public new string Text
        {
            get { return base.Text; }
            set
            {
                if (value == base.Text)
                    return;

                base.Text = value;

                Invalidate();
            }
        }
        public new bool Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; Invalidate(); }
        }
        public new Point Location
        {
            get { return base.Location; }
            set { base.Location = value; Invalidate(); }
        }
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = value;
            }
        }

        public CustomButton()
        {
            InitializeComponent();
            ResizeRedraw = true;
            AutoSize = true;
            SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Visible == true)
            {
                Graphics gfx = pe.Graphics;
                Rectangle rec = ClientRectangle;
                gfx.FillRectangle(new SolidBrush(Parent.BackColor), rec);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;

                DrawRoundedRectangle(gfx, rec, 20, 2, new Pen(Color.Black, 0.1f), Color.LightSteelBlue);

                Font font = new Font(base.Font.FontFamily, base.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                gfx.DrawString(Text, font, new SolidBrush(Color.Black), new RectangleF(rec.Left, rec.Top, rec.Width, rec.Height), format);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

        }

        private void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius1, int CornerRadius2, Pen DrawPen, Color FillColor)
        {
            int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
            Bounds = Rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X - 1, Bounds.Y - 1, CornerRadius1, CornerRadius1, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius2, Bounds.Y - 1, CornerRadius2, CornerRadius2, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius1, Bounds.Y + Bounds.Height - CornerRadius1, CornerRadius1, CornerRadius1, 0, 90);
            gfxPath.AddArc(Bounds.X - 1, Bounds.Y + Bounds.Height - CornerRadius2, CornerRadius2, CornerRadius2, 90, 90);
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(FillColor), gfxPath);
            gfx.DrawPath(DrawPen, gfxPath);
        }

        /// <summary>
        /// Method that forces the control to resize itself when in AutoSize following
        /// a change in its state that affect the size.
        /// </summary>
        private void ResizeForAutoSize()
        {
            if (this.AutoSize)
                this.SetBoundsCore(this.Left, this.Top, this.Width, this.Height, BoundsSpecified.Size);
        }

        /// <summary>
        /// Calculate the required size of the control if in AutoSize.
        /// </summary>
        /// <returns>Size.</returns>
        private Size GetAutoSize()
        {
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                Size size = Size.Round(graphics.MeasureString(Text, new Font(base.Font.FontFamily, base.Font.Size, FontStyle.Regular, GraphicsUnit.Point)));
                size.Height += 4;
                size.Width += 6;
                return size;
            }
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which
        /// a control can be fitted.
        /// </summary>
        public override Size GetPreferredSize(Size proposedSize)
        {
            return GetAutoSize();
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.AutoSize && (specified & BoundsSpecified.Size) != 0)
            {
                Size size = GetAutoSize();

                width = size.Width;
                height = size.Height;
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoPelu
{
    public class RoundedButton : Panel
    {
        private int borderRadius = 21;
        private Color gradientStart = Color.FromArgb(241, 123, 35);
        private Color gradientEnd = Color.FromArgb(244, 206, 47);
        private Color borderColor = Color.FromArgb(200, 200, 200);
        private Color focusBorderColor = Color.FromArgb(241, 123, 35);
        private string text = "Button";
        private bool isHovered = false;
        private bool isPressed = false;

        public new event EventHandler Click;

        // Properties for compatibility with Button
        public FlatStyle FlatStyle { get; set; } = FlatStyle.Standard;
        public bool UseStyleColors { get; set; } 
        public bool UseVisualStyleBackColor { get; set; } = true;
        public DialogResult DialogResult { get; set; } = DialogResult.None;

        public RoundedButton()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(200, 42);
            this.Cursor = Cursors.Hand;
            this.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.ForeColor = Color.White;

            this.MouseEnter += (s, e) => { isHovered = true; this.Invalidate(); };
            this.MouseLeave += (s, e) => { isHovered = false; isPressed = false; this.Invalidate(); };
            this.MouseDown += (s, e) => { isPressed = true; this.Invalidate(); };
            this.MouseUp += (s, e) => { 
                isPressed = false; 
                this.Invalidate();
                if (this.ClientRectangle.Contains(e.Location))
                    Click?.Invoke(this, EventArgs.Empty);
            };
        }

        public override string Text
        {
            get => text;
            set { text = value; this.Invalidate(); }
        }

        public Color GradientStart
        {
            get => gradientStart;
            set { gradientStart = value; this.Invalidate(); }
        }

        public Color GradientEnd
        {
            get => gradientEnd;
            set { gradientEnd = value; this.Invalidate(); }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                // Update gradients to match the solid color request
                // We make standard buttons standard gradient, but specific colors custom
                if (value != Control.DefaultBackColor && value != Color.White && value != Color.Transparent)
                {
                     GradientStart = value;
                     GradientEnd = ControlPaint.Dark(value, 0.05f); // Subtle difference
                }
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Adjust rect for border
            RectangleF rect = new RectangleF(1f, 1f, this.Width - 2f, this.Height - 2f);
            Color parentBg = this.Parent?.BackColor ?? Color.White;

            // Clear corners
            using (SolidBrush clearBrush = new SolidBrush(parentBg))
            {
                g.FillRectangle(clearBrush, this.ClientRectangle);
            }

            using (GraphicsPath path = CreateRoundedPath(rect, borderRadius))
            {
                // Colors based on state
                Color start = gradientStart;
                Color end = gradientEnd;
                Color border = borderColor;

                if (isPressed)
                {
                    start = ControlPaint.Dark(gradientStart, 0.2f);
                    end = ControlPaint.Dark(gradientEnd, 0.2f);
                }
                else if (isHovered)
                {
                    start = ControlPaint.Light(gradientStart, 0.1f);
                    end = ControlPaint.Light(gradientEnd, 0.1f);
                    border = focusBorderColor;
                }

                // Fill
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, start, end, 0f))
                {
                    g.FillPath(brush, path);
                }

                // Border
                using (Pen pen = new Pen(border, 2f))
                {
                     pen.Alignment = PenAlignment.Center;
                     g.DrawPath(pen, path);
                }

                // Text
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g, text, this.Font, Rectangle.Round(rect), this.ForeColor, flags);
            }
        }

        private GraphicsPath CreateRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}

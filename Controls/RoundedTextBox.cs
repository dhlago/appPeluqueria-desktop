using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoPelu
{
    public class RoundedTextBox : Panel
    {
        private TextBox textBox;
        private Color borderColor = Color.FromArgb(200, 200, 200);
        private Color focusBorderColor = Color.FromArgb(241, 123, 35);
        private bool isFocused = false;

        public RoundedTextBox()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Size = new Size(300, 32);
            this.MinimumSize = new Size(50, 28);

            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.BackColor = Color.White;
            textBox.Enter += (s, e) => { isFocused = true; this.Invalidate(); };
            textBox.Leave += (s, e) => { isFocused = false; this.Invalidate(); };

            this.Controls.Add(textBox);
            PositionTextBox();
            this.Resize += (s, e) => PositionTextBox();
        }

        public string PlaceholderText
        {
            get => textBox.PlaceholderText;
            set => textBox.PlaceholderText = value;
        }

        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public char PasswordChar
        {
            get => textBox.PasswordChar;
            set => textBox.PasswordChar = value;
        }

        public bool UseSystemPasswordChar
        {
            get => textBox.UseSystemPasswordChar;
            set => textBox.UseSystemPasswordChar = value;
        }

        public bool Multiline
        {
            get => textBox.Multiline;
            set => textBox.Multiline = value;
        }

        public int MaxLength
        {
            get => textBox.MaxLength;
            set => textBox.MaxLength = value;
        }

        public event EventHandler TextChanged
        {
            add => textBox.TextChanged += value;
            remove => textBox.TextChanged -= value;
        }

        public new event KeyPressEventHandler KeyPress
        {
            add => textBox.KeyPress += value;
            remove => textBox.KeyPress -= value;
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                if (textBox != null) textBox.Font = value;
                PositionTextBox();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (textBox != null) textBox.ForeColor = value;
            }
        }

        public ScrollBars ScrollBars
        {
            get => textBox.ScrollBars;
            set => textBox.ScrollBars = value;
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                if (textBox != null) textBox.BackColor = value;
                this.Invalidate();
            }
        }

        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        public new bool Enabled
        {
            get => base.Enabled;
            set
            {
                base.Enabled = value;
                if (textBox != null)
                {
                    textBox.Enabled = value;
                    textBox.BackColor = value ? Color.White : Color.FromArgb(240, 240, 240);
                }
                this.BackColor = value ? Color.White : Color.FromArgb(240, 240, 240);
                this.Invalidate();
            }
        }


        private int paddingRight = 10;
        public int PaddingRight
        {
            get => paddingRight;
            set { paddingRight = value; PositionTextBox(); }
        }

        private void PositionTextBox()
        {
            // Center vertically with better precision
            int verticalOffset = (this.Height - textBox.Height) / 2;
            int horizontalOffset = 10;
            
            textBox.Location = new Point(horizontalOffset, verticalOffset);
            textBox.Width = this.Width - horizontalOffset - paddingRight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Reduce radius slightly for better look on small height
            int borderRadius = Math.Min(this.Height / 2, 12);
            
            // Adjust rect to ensure border fits fully within control (Pen Width 2f -> 1px inset)
            RectangleF rect = new RectangleF(1f, 1f, this.Width - 2f, this.Height - 2f);
            
            Color parentBg = this.Parent?.BackColor ?? Color.White;

            using (SolidBrush clearBrush = new SolidBrush(parentBg))
            {
                g.FillRectangle(clearBrush, this.ClientRectangle);
            }

            using (GraphicsPath path = CreateRoundedPath(rect, borderRadius))
            {
                using (SolidBrush bgBrush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(bgBrush, path);
                }

                Color currentBorder = isFocused ? focusBorderColor : borderColor;
                using (Pen pen = new Pen(currentBorder, 2f))
                {
                    pen.Alignment = PenAlignment.Center; // Important for border to stay within path
                    g.DrawPath(pen, path);
                }
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

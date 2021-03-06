using Microsoft.Xna.Framework;

namespace MonoForce.Controls
{
    public class Label : Control
    {
        /// <summary>
        /// Indicates how the label's text is aligned.
        /// </summary>
        public virtual Alignment Alignment
        {
            get { return alignment; }
            set { alignment = value; }
        }

        /// <summary>
        /// Indicates if the label's text should be truncated with "..." if it's too large.
        /// </summary>
        public virtual bool Ellipsis
        {
            get { return ellipsis; }
            set { ellipsis = value; }
        }

        /// <summary>
        /// Indicates if the font should be bold
        /// </summary>
        public bool Bold
        {
            get { return bold; }
            set
            {
                bold = value;
                InitFontSize();
            }
        }

        /// <summary>
        /// Indicates if a shadow should be rendered.
        /// </summary>
        public bool Shadow { get; set; }

        /// <summary>
        /// Size of the font
        /// </summary>
        public FontSize Font
        {
            get { return font; }
            set
            {
                font = value;
                InitFontSize();
            }
        }

        /// <summary>
        /// Indicates how the label's text is aligned.
        /// </summary>
        private Alignment alignment = Alignment.MiddleLeft;

        private bool bold;

        /// <summary>
        /// Indicates if the text should be truncated with "..."
        /// </summary>
        private bool ellipsis = true;

        private FontSize font = FontSize.Default8;

        public Label(Manager manager) : base(manager)
        {
            CanFocus = false;
            Passive = true;
            Width = 64;
            Height = 16;
        }

        /// <summary>
        /// Initializes the skin
        /// </summary>
        protected internal override void InitSkin()
        {
            base.InitSkin();
            InitFontSize();
        }

        private void InitFontSize()
        {
            var m = Bold ? 10 : 0;
            var f = ((int) Font) + m;
            Skin.Layers[0].Text.Font.Resource = Manager.Skin.Fonts[f].Resource;
        }

        public override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime)
        {
            //base.DrawControl(renderer, rect, gameTime);
            var s = new SkinLayer(Skin.Layers[0]);
            s.Text.Alignment = alignment;

            if (Shadow)
            {
                textColor = Color.Black;
                rect.X += 1;
                rect.Y += 1;
                renderer.DrawString(this, s, Renderer.StripFormattedText(Text), rect, true, 0, 0, ellipsis, false);

                rect.X -= 1;
                rect.Y -= 1;
                textColor = Color.White;
            }
            renderer.DrawString(this, s, Text, rect, true, 0, 0, ellipsis, DrawFormattedText);
        }
    }

    /// <summary>
    /// Font size (Name = Size)
    /// </summary>
    public enum FontSize
    {
        Default6 = 0,
        Default8 = 1,
        Default9 = 2,
        Default10 = 3,
        Default11 = 4,
        Default12 = 5,
        Default13 = 6,
        Default14 = 7,
        Default20 = 8,
        Default32 = 9
    }
}
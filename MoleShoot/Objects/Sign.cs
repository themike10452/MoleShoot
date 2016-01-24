using System.Drawing;
using MoleShoot.Wrappers;

namespace MoleShoot.Objects
{
    public class Sign : BitmapWrapper
    {
        private Rectangle _hitRectangle;
        public bool IsHit;

        public Sign() : base(Resources.Sign)
        {
            _hitRectangle = new Rectangle
            {
                Width = Resources.Sign.Width - 10,
                Height = (int)(Resources.Sign.Height * 0.48)
            };
        }

        public override void Update(int x, int y)
        {
            base.Update(x, y);
            _hitRectangle.X = Left + 5;
            _hitRectangle.Y = Top - 1;
        }

        public bool Hit(int x, int y)
        {
            bool hit = _hitRectangle.Contains(x, y);

            if (hit)
            {
                IsHit = true;
                Bitmap bullethole = Resources.BulletHole;
                Graphics g = Graphics.FromImage(this.Bitmap);
                g.DrawImage(bullethole, x - Left - bullethole.Width / 2, y - Top - bullethole.Height / 2, bullethole.Width, bullethole.Height);
            }

            return hit;
        }
    }
}

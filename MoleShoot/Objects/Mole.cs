using System.Drawing;
using MoleShoot.Wrappers;

namespace MoleShoot.Objects
{
    public class Mole : BitmapWrapper
    {
        private Rectangle _hitRectangle;
        public bool IsHit;

        public Mole() : base(Resources.Mole)
        {
            _hitRectangle = new Rectangle
            {
                Width = 40,
                Height = 40
            };
        }

        public override void Update(int x, int y)
        {
            base.Update(x, y);
            _hitRectangle.X = Left + 25;
            _hitRectangle.Y = Top - 1;
        }

        public bool Hit(int x, int y)
        {
            bool hit = _hitRectangle.Contains(x, y);

            if (hit)
            {
                IsHit = true;
                Bitmap blood = Resources.Blood;
                Graphics g = Graphics.FromImage(this.Bitmap);
                g.DrawImage(blood, x - Left - blood.Width / 2, y - Top - blood.Height / 2, blood.Width, blood.Height);
            }

            return hit;
        }
    }
}

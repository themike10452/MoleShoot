using System;
using System.Drawing;

namespace MoleShoot.Wrappers
{
    public class BitmapWrapper : IDisposable
    {
        protected Bitmap Bitmap { get; }
        protected int Top;
        protected int Left;

        private bool _disposed;
        private bool _disposing;

        public BitmapWrapper(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public virtual void Update(int x, int y)
        {
            Left = x;
            Top = y;
        }

        public void Draw(Graphics g, int x, int y)
        {
            this.Update(x, y);
            this.Draw(g);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Bitmap, Left, Top, Bitmap.Width, Bitmap.Height);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool dispose)
        {
            if (_disposing || _disposed)
                return;

            _disposing = true;

            if (dispose)
            {
                Bitmap.Dispose();
            }

            _disposed = true;
        }
    }
}

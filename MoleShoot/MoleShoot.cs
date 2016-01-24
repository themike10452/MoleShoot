using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using MoleShoot.Objects;

namespace MoleShoot
{
    public partial class MoleShoot : Form
    {
        private readonly Stream[] _hitSounds = { Resources.hit1, Resources.hit2 };
        private readonly Stream[] _missSounds = { Resources.miss1, Resources.miss2, Resources.miss3, Resources.miss4 };

        private Mole _mole;
        private Sign _sign;

        private int _curX;
        private int _curY;

        private int __tick_count = 0;
        private int __last_hit_tick;

        public MoleShoot()
        {
            InitializeComponent();

            _mole = new Mole();
            _sign = new Sign();

            GameLoop.Start();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            __tick_count++;

            if (_mole.IsHit && (__tick_count - __last_hit_tick) >= 10)
            {
                _mole.Dispose();
                _mole = new Mole();
            }

            _sign.Update(550, 155);
            _mole.Update(240, 250);

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            _sign.Draw(graphics);
            _mole.Draw(graphics);

#if DEBUG
            const TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
            Font font = new Font("Consolas", 12, FontStyle.Regular);
            TextRenderer.DrawText(graphics, $"X:{_curX} Y:{_curY}", font, new Rectangle(0, 0, Width, 30), SystemColors.ControlText, flags);
#endif
        }

        private void MoleShoot_MouseMove(object sender, MouseEventArgs e)
        {
            _curX = e.X;
            _curY = e.Y;
        }

        private void MoleShoot_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mole.Hit(e.X, e.Y))
            {
                __last_hit_tick = __tick_count;

                using (SoundPlayer player = new SoundPlayer(_hitSounds[new Random().Next(0, _hitSounds.Length)]))
                {
                    player.Stream.Position = 0;
                    player.Play();
                }
            }
            else if (_sign.Hit(e.X, e.Y))
            {
                using (SoundPlayer player = new SoundPlayer(Resources.hitwood))
                {
                    player.Stream.Position = 0;
                    player.Play();
                }
            }
            else
            {
                using (SoundPlayer player = new SoundPlayer(_missSounds[new Random().Next(0, _missSounds.Length)]))
                {
                    player.Stream.Position = 0;
                    player.Play();
                }
            }


        }

        private void MoleShoot_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Resources.ic_crosshair.Handle);
        }
    }
}

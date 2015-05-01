using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using imgruber.Properties;

namespace imgruber
{
    public class Screenshot
    {
        private Point _mousedownPoint = Point.Empty;
        private NotifyIcon _ni;
        private TaskTrayApplicationContext _context;
        private Rectangle _rect = Rectangle.Empty;
        private Form _ssField;
        private string _url = string.Empty;

        public string Take(object sender, EventArgs e, TaskTrayApplicationContext ctx)
        {
            _context = ctx;
            _ni = ctx.notifyIcon;
            _ssField = new Form();
            _ssField.BackColor = Color.AliceBlue;
            _ssField.TransparencyKey = _ssField.BackColor;
            _ssField.ControlBox = false;
            _ssField.MaximizeBox = false;
            _ssField.MinimizeBox = false;
            _ssField.FormBorderStyle = FormBorderStyle.None;
            _ssField.WindowState = FormWindowState.Maximized;
            _ssField.MouseDown += ss_MouseDown;
            _ssField.MouseMove += ss_MouseMove;
            _ssField.Paint += ss_Paint;
            _ssField.MouseUp += ss_MouseUp;
            _ssField.Cursor = Cursors.Cross;

            _ssField.Show();

            return _url;
        }

        private void ss_MouseDown(object sender, MouseEventArgs e)
        {
            _mousedownPoint = e.Location;
        }

        private void ss_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Point mm = e.Location;
            _rect = new Rectangle(Math.Min(_mousedownPoint.X, mm.X), Math.Min(_mousedownPoint.Y, mm.Y),
                Math.Abs(_mousedownPoint.X - mm.X), Math.Abs(_mousedownPoint.Y - mm.Y));
            _ssField.Invalidate();
        }

        private void ss_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Black, 2.0f);
            pen.DashPattern = new[] {4.0F, 2.0F};
            e.Graphics.DrawRectangle(pen, _rect);
        }

        private void ss_MouseUp(object sender, MouseEventArgs e)
        {
            _ssField.Hide();
            var bmp = new Bitmap(_rect.Width, _rect.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(_rect.Location, Point.Empty, _rect.Size,
                    CopyPixelOperation.SourceCopy);

                try
                {
                    string link = ImgurUploader.Upload(bmp);
                    _url = link;
                    _ni.BalloonTipTitle = Resources.Imgruber_says_;
                    _ni.BalloonTipText = Resources.Screenshot_uploaded_to_Imgur__link_copied_to_clipboard__ +
                                         Environment.NewLine + link;
                    _ni.BalloonTipIcon = ToolTipIcon.Info;
                    _ni.ShowBalloonTip(300);


                    if (_context.configWindow.TweetThisCB.Checked)
                    {
                        string tweetString =
                            "https://twitter.com/intent/tweet?original_referer=http%3A%2F%2Fjarena3.github.io%2Fimgruber%2F&share_with_retweet=never&text=" +
                            link + " " + _context.configWindow.TweetPrependTB.Text + " " +
                            "&tw_p=tweetbutton";
                        Process.Start(new ProcessStartInfo(tweetString));
                    }

                    string tlink = link.Remove(7, 2);
                    tlink = tlink.Remove(tlink.Length - 4, 4);

                    switch (_context.configWindow.LinkCodeCOMBO.SelectedIndex)
                    {
                        case (0):
                            link = tlink;
                            break;
                        case (1):
                            break;
                        case (2):
                            link = "[Imgur](" + link + ")";
                            break;
                        case (3):
                            link = "<a href=\"" + tlink + "\"><img src=\"" + link +
                                   "\" title=\"source: imgur.com\" /></a>";
                            break;
                        case (4):
                            link = "[img]" + link + "[/img]";
                            break;
                        case (5):
                            link = "[url=" + tlink + "][img]" + link + "[/img][/url]";
                            break;
                    }

                    Clipboard.SetText(link);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    _ni.BalloonTipTitle = Resources.Imgruber_says_;
                    _ni.BalloonTipText = Resources.Something_went_terribly_wrong__Are_you_sure_you_re_connected_to_the_internet_;
                    _ni.BalloonTipIcon = ToolTipIcon.Error;
                    _ni.ShowBalloonTip(300);
                }
            }

            Cursor.Current = Cursors.Default;
            _ssField.Close();
        }
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace imgruber
{
    public class Screenshot
    {
        private Point MD = Point.Empty;
        private Form ssField;
        private Rectangle rect = Rectangle.Empty;
        private NotifyIcon _ni;
        private string url = string.Empty;
        private TaskTrayApplicationContext context;

        public string Take(object sender, EventArgs e, TaskTrayApplicationContext ctx)
        {
            context = ctx;
            _ni = ctx.notifyIcon;
            ssField = new Form();
            ssField.BackColor = Color.AliceBlue;
            ssField.TransparencyKey = ssField.BackColor;
            ssField.ControlBox = false;
            ssField.MaximizeBox = false;
            ssField.MinimizeBox = false;
            ssField.FormBorderStyle = FormBorderStyle.None;
            ssField.WindowState = FormWindowState.Maximized;
            ssField.MouseDown += ss_MouseDown;
            ssField.MouseMove += ss_MouseMove;
            ssField.Paint += ss_Paint;
            ssField.MouseUp += ss_MouseUp;
            ssField.Cursor = Cursors.Cross;

            ssField.Show();

            return url;
        }

        private void ss_MouseDown(object sender, MouseEventArgs e)
        {
            MD = e.Location;
        }

        private void ss_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Point MM = e.Location;
            rect = new Rectangle(Math.Min(MD.X, MM.X), Math.Min(MD.Y, MM.Y),
                Math.Abs(MD.X - MM.X), Math.Abs(MD.Y - MM.Y));
            ssField.Invalidate();
        }

        private void ss_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2.0f);
            pen.DashPattern = new float[] { 4.0F, 2.0F };
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void ss_MouseUp(object sender, MouseEventArgs e)
        {
            ssField.Hide();
            Screen scr = Screen.AllScreens[0];
            var bmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CopyFromScreen(rect.Location, Point.Empty, rect.Size,
                    CopyPixelOperation.SourceCopy);

                try
                {
                    var link = ImgurUploader.Upload(bmp);
                    url = link;
                    _ni.BalloonTipTitle = "Imgruber says:";
                    _ni.BalloonTipText = "Screenshot uploaded to Imgur, link copied to clipboard: "+Environment.NewLine+link;
                    _ni.BalloonTipIcon = ToolTipIcon.Info;
                    _ni.ShowBalloonTip(300);

                    
                    if (context.configWindow.TweetThisCB.Checked)
                    {
                        string tweetString =
                            "https://twitter.com/intent/tweet?original_referer=http%3A%2F%2Fjarena3.github.io%2Fimgruber%2F&share_with_retweet=never&text=" +
                            link + " " + context.configWindow.TweetPrependTB.Text + " " +
                            "&tw_p=tweetbutton";
                        Process.Start(new ProcessStartInfo(tweetString));
                    }

                    var tlink = link.Remove(7, 2);
                    tlink = tlink.Remove(tlink.Length - 4, 4);

                    switch (context.configWindow.LinkCodeCOMBO.SelectedIndex)
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
                    _ni.BalloonTipTitle = "Imgruber says:";
                    _ni.BalloonTipText = "Something went terribly wrong. Are you sure you're connected to the internet?";
                    _ni.BalloonTipIcon = ToolTipIcon.Error;
                    _ni.ShowBalloonTip(300);
                }
            }

            Cursor.Current = Cursors.Default;
            ssField.Close();
        }
    }
}
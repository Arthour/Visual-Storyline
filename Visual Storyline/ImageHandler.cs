using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline
{
    class ImageHandler
    {

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        public static string startComparison(string location, string selectedFile, PictureBox pictureBox)
        {
            if (Directory.Exists(location))
            {
                if (Directory.GetFiles(location) != null)
                {
                    Image selPic = ImageFast.FromFile(selectedFile);
                    Bitmap selBM = new Bitmap(selPic);
                    try
                    {
                        string[] files = Directory.GetFiles(location);
                        foreach (string pic in files)
                        {
                            try
                            {
                                Image curPic = ImageFast.FromFile(pic);
                                Bitmap curBM = new Bitmap(curPic);
                                Console.WriteLine("Comparing " + pic + " and " + selectedFile);

                                if (selPic.Width == curPic.Width && selPic.Height == curPic.Height)
                                {
                                    if (compare(selBM, curBM) == true)
                                    {
                                        Console.WriteLine("Match found");
                                        load(location, pic, pictureBox);
                                        return Path.GetFileName(pic);
                                    }
                                }
                            }
                            catch (Exception)
                            { }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    { }
                    catch (Exception)
                    { }
                }

            }
            Directory.CreateDirectory(location);
            return picNotExisting(location, selectedFile, pictureBox);
        }

        private static bool compare(Bitmap b1, Bitmap b2)
        {
            Console.WriteLine("Comparison started");
            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bd1scan0 = bd1.Scan0;
                IntPtr bd2scan0 = bd2.Scan0;

                int stride = bd1.Stride;
                int len = stride * b1.Height;

                Console.WriteLine(memcmp(bd1scan0, bd2scan0, len) == 0);

                return memcmp(bd1scan0, bd2scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }

        private static string picNotExisting(string location, string sourceFile, PictureBox pictureBox)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            File.Copy(sourceFile, Path.Combine(location, GuidString));

            load(location, GuidString, pictureBox);
            return GuidString;
        }

        public static void load(string location, string fileName, PictureBox pictureBox, PictureBoxSizeMode SizeMode = PictureBoxSizeMode.Zoom)
        {
            Image pic = ImageFast.FromFile(Path.Combine(location, fileName));
            pictureBox.Image = pic;
            pictureBox.SizeMode = SizeMode;
            pictureBox.BackColor = Color.Black;
        }

        public void cleanUp()
        {

        }
    }
}

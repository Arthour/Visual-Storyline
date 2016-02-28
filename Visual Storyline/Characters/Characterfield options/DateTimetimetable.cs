using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Visual_Storyline.Characterfield_options
{
    public partial class DateTimetimetable : Form
    {
        internal int ytm, mtd, dth, htm, mts;

        public DateTimetimetable(int ytm, int mtd, int dth, int htm, int mts)
        {
            InitializeComponent();
            month.Text = ytm.ToString();
            day.Text = mtd.ToString();
            hour.Text = dth.ToString();
            minute.Text = htm.ToString();
            second.Text = mts.ToString();

            Recalculate();

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                tb.MinimumSize = new Size(50, 23);
                tb.MaximumSize = new Size(50, 23);

            }
        }

        private void Recalculate(object sender, EventArgs e)
        {
            if(sender != null)
                Recalculate(sender);
        }

        private void Recalculate(object input = null)
        {
            long temp;

            if (input != null)
            {
                var tb = input as TextBox;
                if(tb.Text == "" || tb.Text == "0")
                    tb.Text = "1";
            }

            temp = Convert.ToInt64(minute.Text) * Convert.ToInt64(second.Text);
            hourtosecond.Text = temp.ToString();
            temp = Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text);
            daytominute.Text = temp.ToString();
            temp = Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text) * Convert.ToInt64(second.Text);
            daytosecond.Text = temp.ToString();
            temp = Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text);
            monthtohour.Text = temp.ToString();
            temp = Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text);
            monthtominute.Text = temp.ToString();
            temp = Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text) * Convert.ToInt64(second.Text);
            monthtosecond.Text = temp.ToString();
            temp = Convert.ToInt64(month.Text) * Convert.ToInt64(day.Text);
            yeartoday.Text = temp.ToString();
            temp = Convert.ToInt64(month.Text) * Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text);
            yeartohour.Text = temp.ToString();
            temp = Convert.ToInt64(month.Text) * Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text);
            yeartominute.Text = temp.ToString();
            temp = Convert.ToInt64(month.Text) * Convert.ToInt64(day.Text) * Convert.ToInt64(hour.Text) * Convert.ToInt64(minute.Text) * Convert.ToInt64(second.Text);
            yeartosecond.Text = temp.ToString();

            foreach(TextBox textbox in Controls.OfType<TextBox>())
            {
                if (textbox.Font.Size > 0)
                {
                    while (textbox.Width - 9 < System.Windows.Forms.TextRenderer.MeasureText(textbox.Text, new Font(textbox.Font.FontFamily, textbox.Font.Size, textbox.Font.Style)).Width)
                    {
                        textbox.Font = new Font(textbox.Font.FontFamily, textbox.Font.Size - 0.5f, textbox.Font.Style);
                    }
                }
                if (textbox.Font.Size < 9)
                {
                    while (textbox.Width - 9 > System.Windows.Forms.TextRenderer.MeasureText(textbox.Text, new Font(textbox.Font.FontFamily, textbox.Font.Size, textbox.Font.Style)).Width)
                    {
                        textbox.Font = new Font(textbox.Font.FontFamily, textbox.Font.Size + 0.5f, textbox.Font.Style);
                    }
                }

                if (textbox.Font.Size > 9)
                    textbox.Font = new Font(textbox.Font.FontFamily, 9, textbox.Font.Style);

                textbox.MinimumSize = new Size(50, 23);
                textbox.MaximumSize = new Size(50, 23);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            ytm = Convert.ToInt32(month.Text);
            mtd = Convert.ToInt32(day.Text);
            dth = Convert.ToInt32(hour.Text);
            htm = Convert.ToInt32(minute.Text);
            mts = Convert.ToInt32(second.Text);

            this.Dispose();
        }
    }
}

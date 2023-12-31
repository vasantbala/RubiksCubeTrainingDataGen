using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RubiksCubeTrainingDataGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(imgSavePath.Text))
            {
                MessageBox.Show($"{imgSavePath.Text} does not exist.");
                return;
            }

            if (!Directory.Exists(Path.Combine(imgSavePath.Text, "training", "solved")))
            {
                Directory.CreateDirectory(Path.Combine(imgSavePath.Text, "training", "solved"));
            }

            if (!Directory.Exists(Path.Combine(imgSavePath.Text, "training", "unsolved")))
            {
                Directory.CreateDirectory(Path.Combine(imgSavePath.Text, "training", "unsolved"));
            }

            if (!Directory.Exists(Path.Combine(imgSavePath.Text, "test", "solved")))
            {
                Directory.CreateDirectory(Path.Combine(imgSavePath.Text, "test", "solved"));
            }

            if (!Directory.Exists(Path.Combine(imgSavePath.Text, "test", "unsolved")))
            {
                Directory.CreateDirectory(Path.Combine(imgSavePath.Text, "test", "unsolved"));
            }

            GenerateImages(new[] { Color.Blue, Color.Yellow, Color.Red}, Path.Combine(imgSavePath.Text,"training"));
            GenerateImages(new[] { Color.Green, Color.Orange, Color.Brown }, Path.Combine(imgSavePath.Text,"test"));

            MessageBox.Show("Finished generating both training and test data.");
        }


        private void GenerateImages(IReadOnlyList<Color> colors, string savePath)
        {
            //var colors = new Color[] { Color.Blue, Color.Yellow, Color.Red, Color.Green, Color.Orange, Color.White };
            //var colors = new Color[] { Color.Green, Color.Orange, Color.Brown };


            int fileCounter = 0;
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        var bitmap = new Bitmap(300, 300, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        var graphics = Graphics.FromImage(bitmap);
                        var pen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);

                        for (var a = 0; a < 3; a++)
                        {
                            DrawRow(graphics, a, new SolidBrush(colors[i]), new SolidBrush(colors[j]),
                                new SolidBrush(colors[k]));
                        }

                        graphics.DrawRectangle(pen, new Rectangle(new Point(0, 0), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(0, 100), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(0, 200), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(100, 0), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(100, 100), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(100, 200), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(200, 0), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(200, 100), new Size(100, 100)));
                        graphics.DrawRectangle(pen, new Rectangle(new Point(200, 200), new Size(100, 100)));

                        fileCounter++;

                        var imagePath = (i == j && j == k) ? Path.Combine(savePath, "solved", $"{fileCounter}.jpg") : Path.Combine(savePath, "unsolved", $"{fileCounter}.jpg");
                        bitmap.Save(imagePath);
                        //bitmap.Save(Path.Combine(savePath, $"{fileCounter}.jpg"));
                    }
                }
            }
        }


        private void DrawRow(Graphics graphics, int rowIndex, Brush cell1, Brush cell2, Brush cell3)
        {
            var pen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);

            var blueBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Blue));

            if (rowIndex == 0)
            {
                graphics.FillRectangle(cell1, new Rectangle(new Point(0, 0), new Size(100, 100)));
                graphics.FillRectangle(cell2, new Rectangle(new Point(100, 0), new Size(100, 100)));
                graphics.FillRectangle(cell3, new Rectangle(new Point(200, 0), new Size(100, 100)));
            }
            else if (rowIndex == 1)
            {
                graphics.FillRectangle(cell1, new Rectangle(new Point(0, 100), new Size(100, 100)));
                graphics.FillRectangle(cell2, new Rectangle(new Point(100, 100), new Size(100, 100)));
                graphics.FillRectangle(cell3, new Rectangle(new Point(200, 100), new Size(100, 100)));
            }
            else if (rowIndex == 2)
            {
                graphics.FillRectangle(cell1, new Rectangle(new Point(0, 200), new Size(100, 100)));
                graphics.FillRectangle(cell2, new Rectangle(new Point(100, 200), new Size(100, 100)));
                graphics.FillRectangle(cell3, new Rectangle(new Point(200, 200), new Size(100, 100)));
            }


        }
    }
}
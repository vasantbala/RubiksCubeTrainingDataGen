using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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


            //var colors = new Color[] { Color.Blue, Color.Yellow, Color.Red, Color.Green, Color.Orange, Color.White };
            var colors = new Color[] { Color.Green, Color.Orange, Color.Brown };


            int fileCounter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            
            for(int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Bitmap bitmap = new Bitmap(300, 300, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        Pen pen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);

                        for (int a = 0; a < 3; a++)
                        {
                            DrawRow(graphics, a, new SolidBrush(colors[i]), new SolidBrush(colors[j]),
                                new SolidBrush(colors[k]));

                            //stringBuilder.AppendLine($"Row {a}: {i} {j} {k}");
                            
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
                        bitmap.Save($"C:\\temp\\rubiks\\test\\{fileCounter}.png");    
                    }
                }
            }
        }


        private void DrawRow(Graphics graphics, int rowIndex, Brush cell1, Brush cell2, Brush cell3)
        {  
            Pen pen = new Pen(Color.FromKnownColor(KnownColor.Black), 2);

            var blueBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Blue));

            if(rowIndex == 0) 
            {
                graphics.FillRectangle(cell1, new Rectangle(new Point(0, 0), new Size(100, 100)));
                graphics.FillRectangle(cell2, new Rectangle(new Point(100, 0), new Size(100, 100)));
                graphics.FillRectangle(cell3, new Rectangle(new Point(200, 0), new Size(100, 100)));
            }
            else if(rowIndex == 1)
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
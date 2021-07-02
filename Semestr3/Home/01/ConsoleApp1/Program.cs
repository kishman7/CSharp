using System;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int width, height;
            Console.WriteLine("Enter Form Width");
            width = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Form Height");
            height = Int32.Parse(Console.ReadLine());

            byte r, g, b;
            Console.Write("Enter Color (0-255) > \n R>");
            r = byte.Parse(Console.ReadLine());
            Console.Write(" G>");
            g = byte.Parse(Console.ReadLine());
            Console.Write(" B>");
            b = byte.Parse(Console.ReadLine());

            int buttonWidth, buttonHeight;
            Console.WriteLine("Enter Button Width");
            buttonWidth = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Button Height");
            buttonHeight = Int32.Parse(Console.ReadLine());

            var form = new Form
            {
                BackColor = Color.FromArgb(r, g, b),
                Width = width,
                Height = height
            };

            var button = new Button
            {
                Text = "Click",
                Width = buttonWidth,
                Top = height / 2 - (buttonHeight/2),
                Left = width / 2 - (buttonWidth/2),
                Height = buttonHeight
            };
            button.Click += Button_Click;

            form.Controls.Add(button);

            form.ShowDialog();
        }

        static int text = 0;

        static Random random = new Random();
        private static void Button_Click(object sender, EventArgs e)
        {
            (sender as Button).Parent.Text = "Count: " + ++text;
            (sender as Button).BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace stega
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            string message = Console.ReadLine();
            Image imageOriginal = Image.FromFile(fileName);
            WriteMessage(message, imageOriginal, fileName);
            Image newImage = Image.FromFile("stega." + fileName);
            ReadMessage(newImage);
            Console.ReadLine();
        }

        public static void WriteMessage(string message, Image imageOriginal, string fileName)
        {
            int counter = 0;
            int j = 0;
            int i = 0; 
            Bitmap bm = new Bitmap(imageOriginal);         
            foreach (char item in message)
            {
                Color c = bm.GetPixel(j, i);
                Color setPix = Color.FromArgb(c.R, c.G, Convert.ToByte(message[counter]));
                bm.SetPixel(j, i, setPix);
                    if (j < bm.Width - 1) { j++; }
                    else if (i < bm.Height - 1) { i++; }
                    counter++;
            }

            Color messageLength = bm.GetPixel(bm.Width - 1, bm.Height - 1);
            Color setML = Color.FromArgb(messageLength.R, messageLength.G, Convert.ToByte(message.Length));
            bm.SetPixel(bm.Width - 1,bm. Height - 1, setML);
            bm.Save("stega." + fileName);
        }

        public static void ReadMessage(Image newImage)
        {
            int i = 0;
            int j = 0;
            Bitmap bmp = new Bitmap(newImage);
            Color getLength = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
            int messageLength = Convert.ToInt32(getLength.B);
            for (int text = 0; text < messageLength; text++)
            {
                Color c = bmp.GetPixel(j, i);
                Console.Write(Convert.ToChar(c.B));
                if (j < bmp.Width - 1) { j++; }
                else if (i < bmp.Height - 1) { i++; }
            }
        }
    }
}

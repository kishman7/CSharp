using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    class GameFild : IEnumerable
    {
        public int FilddWidth { set; get; }
        public int FildHeight { set; get; }

        public IPixels[][] PixelsFild;
        public GameFild( int height, int width)
        {
            FilddWidth = width;
            FildHeight = height;
            PixelsFild = new IPixels[height][];
        }

        public void GenerateFild()
        {
            for (int i =0; i< FildHeight; i++)
                PixelsFild[i] = new IPixels[FilddWidth];

            BorderPixel.BildBorder(PixelsFild);
            UserPixel.BildUserPixel(PixelsFild);
            CommonPixel.BildCommonPixel(PixelsFild);
        }
        public bool CheckMove(IMoving moving, int newY, int newX)
        {
            if (PixelsFild[newY][newX].Сollision == IPixels.Сollisions.Impassable)
                return false;

            if (moving.MType == typeof(Spider))
                if (PixelsFild[newY][newX].Сollision == IPixels.Сollisions.None)
                    return true;
                else
                    return false;

            return true;
        }

        public IPixels ReplacePixel(IPixels replasePixel, Type NewType)
        {
            if (NewType == typeof(WebPixel))
                PixelsFild[replasePixel.Y][replasePixel.X] = new WebPixel(replasePixel.X, replasePixel.Y);
            else if (NewType == typeof(UserPixel))
                PixelsFild[replasePixel.Y][replasePixel.X] = new UserPixel(replasePixel.X, replasePixel.Y);
            else if (NewType == typeof(CommonPixel))
                PixelsFild[replasePixel.Y][replasePixel.X] = new CommonPixel(replasePixel.X, replasePixel.Y);
            
            return PixelsFild[replasePixel.Y][replasePixel.X];
        }

        public void HelloNeighbor(List<CommonPixel> commonPixels, List<CommonPixel> resultPixel, CommonPixel pixel)
        {
            List<int[]> vs = pixel.GetNeighborsIndex();

            foreach (int[] p in vs)
                if (PixelsFild[p[0]][p[1]].GetType() == typeof(CommonPixel) && commonPixels.Remove((CommonPixel)PixelsFild[p[0]][p[1]]))
                {
                    resultPixel.Add((CommonPixel)PixelsFild[p[0]][p[1]]);
                    HelloNeighbor(commonPixels, resultPixel, (CommonPixel)PixelsFild[p[0]][p[1]]);
                }
        }

        public List<CommonPixel> GetAllFreePixels()
        {
            List<CommonPixel> pixels1 = new();

            foreach (IPixels[] em in PixelsFild)
                foreach (IPixels pixels in em)
                    if (pixels.GetType() == typeof(CommonPixel))
                        pixels1.Add((CommonPixel)pixels);
            return pixels1;
        }

        public int GetCountFreePixels()
        {
            int i = 0;
            foreach (IPixels[] em in PixelsFild)
                foreach (IPixels pixels in em)
                    if (pixels.GetType() == typeof(CommonPixel))
                        i++;
            return i;
        }

        public CommonPixel GetFirstFreePixel()
        {
            foreach (IPixels[] em in PixelsFild)
                foreach (IPixels pixels in em)
                    if (pixels.GetType() == typeof(CommonPixel))
                        return (CommonPixel)pixels;
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IPixels[] em in PixelsFild)
                foreach (IPixels pixels in em)
                    yield return pixels;
        }
    }
}

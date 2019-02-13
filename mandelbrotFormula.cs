public class MandelbrotFormulas
{
    public void GET()
    {
        //THIS CODE WAS PULLED FROM https://www.codeproject.com/Articles/1177443/Mandelbrot-Set-With-Csharp
        for (double y = yMin; y < yMax; y += xyStep.y) {

            int xPix = 0;

            for (double x = xMin; x < xMax; x += xyStep.x) {

                ComplexPoint c = new ComplexPoint(x, y);

                ComplexPoint zk = new ComplexPoint(0, 0);

                int k = 0;

                do {

                    zk = zk.doCmplxSqPlusConst(c);

                    modulusSquared = zk.doMoulusSq();

                    k++;

                } while ((modulusSquared <= 4.0) && (k < kMax));



                if (k < kMax) {

                    if (k == kLast) {

                        color = colorLast;

                    } else {

                        color = colourTable.GetColour(k);

                        colorLast = color;

                    }



                    if (xyPixelStep == 1) {

                        if ((xPix < myBitmap.Width) && (yPix >= 0)) {
                            myBitmap.SetPixel(xPix, yPix, color);
                        }
                    } else {
                        for (int pX = 0; pX < xyPixelStep; pX++) {

                            for (int pY = 0; pY < xyPixelStep; pY++) {

                                if (((xPix + pX) < myBitmap.Width) && ((yPix - pY) >= 0)) {
                                    myBitmap.SetPixel(xPix + pX, yPix - pY, color);
                                }
                            }
                        }
                    }
                }
                xPix += xyPixelStep;
            }
            yPix -= xyPixelStep;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikovaKostka3
{
    class MaticeID
    {
		//parametr
		private BodID[,] maticeID = new BodID[3,3];

        //konstruktor 1 hotove kostky
        public MaticeID(int strana)
        {
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++) { maticeID[x, y] = new BodID(strana, x, y); }
			}
        }

        //vystup 1
		public BodID OutB(int aBodX, int aBodY) { return maticeID[aBodX, aBodY]; }

		//vystup 2
		public BodID OutB(int aBod)
		{
			int y = aBod / 3;
			int x = aBod - y * 3;
			return maticeID[x, y];
		}

		//z matice do vektoru od do v matici
		/*public VektorID MV(int aOd, int aDo)
		{
			BodID[] b1=new BodID[3];
			float y1 = aOd / 3;
			float x1 = aOd - y1 * 3;
			float y2 = aDo / 3;
			float x2 = aDo - y2 * 3;
			float x = (x2 - x1) / 2;
			float y = (y2 - y1) / 2;
			
			for (int bod = 0; bod < 3; bod++)
			{
				int ox = (int)(x1 + x * bod);
				int oy = (int)(y1 + y * bod);
				b1[bod] = maticeID[(int)(x1 + x * bod), (int)(y1 + y * bod)];
			}

			return new VektorID(b1);
		}*/

		//z matice do vektoru
		public VektorID MV() { return new VektorID(maticeID[0, 0], maticeID[1, 0], maticeID[2, 0]); }

		//z vektoru do matice od do v matici
		/*public void VM(VektorID aVektor, int aOd, int aDo)
		{
			float y1 = aOd / 3;
			float x1 = aOd - y1 * 3;
			float y2 = aDo / 3;
			float x2 = aDo - y2 * 3;
			float x = (x2 - x1) / 2;
			float y = (y2 - y1) / 2;

			for (int bod = 0; bod < 3; bod++)
			{
				int ox = (int)(x1 + x * bod);
				int oy = (int)(y1 + y * bod);
				maticeID[(int)(x1 + x * bod),(int)(y1 + y * bod)] = aVektor.OutB(bod);
			}
		}*/

		//z vektoru do matice
		public void VM(VektorID aVektor)
		{
			maticeID[0, 0] = aVektor.OutB(0);
			maticeID[1, 0] = aVektor.OutB(1);
			maticeID[2, 0] = aVektor.OutB(2);
		}

		//rotace plochy strany aktualni matice 
		public void RotaceStranyR()
		{
			BodID[] bod = new BodID[2];
			
			bod[1] = maticeID[1, 0];
			bod[0] = maticeID[0, 0];

			maticeID[1, 0] = maticeID[2, 1];
			maticeID[0, 0] = maticeID[2, 0];

			maticeID[2, 1] = maticeID[1, 2];
			maticeID[2, 0] = maticeID[2, 2];

			maticeID[1, 2] = maticeID[0, 1];
			maticeID[2, 2] = maticeID[0, 2];

			maticeID[0, 1] = bod[1];
			maticeID[0, 2] = bod[0];
			
		}

		//rotace plochy strany aktualni matice 
		public void RotaceStranyL()
		{
			BodID[] bod = new BodID[2];

			bod[0] = maticeID[0, 0];
			bod[1] = maticeID[1, 0];

			maticeID[0, 0] = maticeID[0, 2];
			maticeID[1, 0] = maticeID[0, 1];

			maticeID[0, 2] = maticeID[2, 2];
			maticeID[0, 1] = maticeID[1, 2];

			maticeID[2, 2] = maticeID[2, 0];
			maticeID[1, 2] = maticeID[2, 1];

			maticeID[2, 0] = bod[0];
			maticeID[2, 1] = bod[1];
		}
		

    }
}

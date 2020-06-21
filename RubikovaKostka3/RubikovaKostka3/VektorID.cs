using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikovaKostka3
{
    class VektorID
    {
		//parametr
        private BodID[] vektorID=new BodID[3];

		//konstruktor 1
		public VektorID(BodID aBod0, BodID aBod1, BodID aBod2)
		{
			vektorID[0] = aBod0;
			vektorID[1] = aBod1;
			vektorID[2] = aBod2;
		}

		//konstrukor 2
		public VektorID(BodID[] aBody){vektorID = aBody;}

        //vystup
        public BodID OutB(int aBodX) {  return vektorID[aBodX]; }

    }
}

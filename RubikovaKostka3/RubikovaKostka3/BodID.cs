using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikovaKostka3
{
    class BodID
    {
        //parametr
        private int idStrana;
        private int idBodX;
		private int idBodY;

        //konstruktor
		public BodID(int aStrana, int aBodX,int aBodY) 
		{
			idStrana = aStrana;
			idBodX = aBodX;
			idBodY = aBodY;
		}

        //vystupy
        public int IDStr { get { return idStrana; } }
        public int IDBodX { get { return idBodX; } }
		public int IDBodY { get { return idBodY; } }
    }
}

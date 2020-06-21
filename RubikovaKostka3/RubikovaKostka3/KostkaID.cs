using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikovaKostka3
{
    class KostkaID
    {
		//parametr
		MaticeID[] kostkaID = new MaticeID[6];

        //konstrukor hotove kostky
        public KostkaID()
        {
            for (int strana = 0; strana < 6; strana++)
            {
                kostkaID[strana] = new MaticeID(strana);
            }
        }

        //vystup 1
        public MaticeID OutM(int strana) { return kostkaID[strana]; }

		//vystup 2
		public int OutIK(int aStrana = 0, int aBodX = 0, int aBodY = 0, int aID = 0)
		{
			int y1 = 0;
			BodID p1 = kostkaID[aStrana].OutB(aBodX, aBodY);

			switch (aID)
			{
				case 0: y1 = p1.IDStr; break;
				case 1: y1 = p1.IDBodX; break;
				case 2: y1 = p1.IDBodY; break;
				case 3: y1 = p1.IDBodX + 3 * p1.IDBodY; break;
			}
			return y1;
		}

		//vystup 3
		public string OutSK(int aStrana, int aBodX, int aBodY)
		{
			string t1 = "";

			t1 += Convert.ToString(aBodX);
			t1 += ",";
			t1 += Convert.ToString(aBodY);
			t1 += ";";
			t1 += Convert.ToString(aStrana);
			t1 += ";\n";
			t1 += Convert.ToString(OutIK(aStrana, aBodX, aBodY, 1));
			t1 += ",";
			t1 += Convert.ToString(OutIK(aStrana, aBodX, aBodY, 2));
			t1 += ";";
			t1 += Convert.ToString(OutIK(aStrana, aBodX, aBodY, 3));
			t1 += ";";

			return t1;
		}

		//z matice do vektoru od do v matici strany 0 defaultne
		//public VektorID MV(int aX, int aY, int aStrana = 0) { return kostkaID[aStrana].MV(aY, aY); }

		//z matice do vektoru strany 0 defaultne
		public VektorID MV(int aStrana = 0) { return kostkaID[aStrana].MV(); }

		//z vektoru do matice od do v matici strany 0 defaultne
		//public void VM(VektorID aVektor, int aX, int aY, int aStrana = 0) { kostkaID[aStrana].VM(aVektor, aX, aY); }

		//z vektoru do matice strany 0 defaultne
		public void VM(VektorID aVektor, int aStrana = 0) { kostkaID[aStrana].VM(aVektor); }

		//rotace plochy strany 0 defaultne
		public void RotaceStranyR(int aStrana = 0) { kostkaID[aStrana].RotaceStranyR(); }

		//rotace plochy strany 0 defaultne
		public void RotaceStranyL(int aStrana = 0) { kostkaID[aStrana].RotaceStranyL(); }

		//rotace R hrany strany 0 + rotace strany 0
		public void RotaceHranyR()
		{
			VektorID vektor;

			RotaceStranyR(4);
			RotaceStranyL(2);
			RotaceStranyR(5);
			RotaceStranyR(5);

			vektor = MV(3);
			VM(MV(4), 3);
			VM(MV(5), 4);
			VM(MV(2), 5);
			VM(vektor, 2);

			RotaceStranyL(4);
			RotaceStranyR(2);
			RotaceStranyL(5);
			RotaceStranyL(5);

			RotaceStranyR(0);//!!!
		}

		//rotace L hrany strany 0 + rotace strany 0
		public void RotaceHranyL()
		{
			VektorID vektor;

			RotaceStranyR(4);
			RotaceStranyL(2);
			RotaceStranyR(5);
			RotaceStranyR(5);

			vektor = MV(3);
			VM(MV(2), 3);
			VM(MV(5), 2);
			VM(MV(4), 5);
			VM(vektor, 4);

			RotaceStranyL(4);
			RotaceStranyR(2);
			RotaceStranyL(5);
			RotaceStranyL(5);

			RotaceStranyL(0);//!!!
		}

		//rotace R kostky strany 0
		public void RotaceKostkyR()
		{
			MaticeID matice;

			matice = kostkaID[2];
			kostkaID[2] = kostkaID[3];
			kostkaID[3] = kostkaID[4];
			kostkaID[4] = kostkaID[5];
			kostkaID[5] = matice;

			RotaceStranyR(0);
			RotaceStranyL(1);
			RotaceStranyR(2);
			RotaceStranyR(3);
			RotaceStranyR(4);
			RotaceStranyR(5);
		}

		//rotace L kostky strany 0
		public void RotaceKostkyL()
		{
			MaticeID matice;

			matice = kostkaID[2];
			kostkaID[2] = kostkaID[5];
			kostkaID[5] = kostkaID[4];
			kostkaID[4] = kostkaID[3];
			kostkaID[3] = matice;

			RotaceStranyL(0);
			RotaceStranyR(1);
			RotaceStranyL(2);
			RotaceStranyL(3);
			RotaceStranyL(4);
			RotaceStranyL(5);
		}

		//posunuti R kostky strany 0
		public void PosunutiKostkyR()
		{
			MaticeID matice;

			matice = kostkaID[1];
			kostkaID[1] = kostkaID[2];
			kostkaID[2] = kostkaID[0];
			kostkaID[0] = kostkaID[4];
			kostkaID[4] = matice;

			RotaceStranyL(3);
			RotaceStranyR(5);
		}

		//posunuti L kostky strany 0
		public void PosunutiKostkyL()
		{
			MaticeID matice;

			matice = kostkaID[4];
			kostkaID[4] = kostkaID[0];
			kostkaID[0] = kostkaID[2];
			kostkaID[2] = kostkaID[1];
			kostkaID[1] = matice;

			RotaceStranyR(3);
			RotaceStranyL(5);
		}

		//posunuti A kostky V strany 0
		public void PosunutiKostkyA()
		{
			RotaceKostkyL();
			PosunutiKostkyL();
			RotaceKostkyR();
		}

		//posunuti V kostky V strany 0
		public void PosunutiKostkyV()
		{
			RotaceKostkyR();
			PosunutiKostkyL();
			RotaceKostkyL();
		}

		public void Makro(string kod )
		{
			switch (kod)
			{
				case "SR":
					PosunutiKostkyA();
					RotaceHranyR();
					PosunutiKostkyV();
					break;
				case "SL":
					PosunutiKostkyA();
					RotaceHranyL();
					PosunutiKostkyV();
					break;
				case "RK":
					PosunutiKostkyL();
					RotaceHranyL();
					PosunutiKostkyR();
					break;
				case "RN":
					PosunutiKostkyL();
					RotaceHranyR();
					PosunutiKostkyR();
					break;
				case "LK":
					PosunutiKostkyR();
					RotaceHranyR();
					PosunutiKostkyL();
					break;
				case "LN":
					PosunutiKostkyR();
					RotaceHranyL();
					PosunutiKostkyL();
					break;
				case "CR": RotaceHranyR(); break;
				case "CL": RotaceHranyL(); break;
				case "PK":
					//LN
					PosunutiKostkyR();
					RotaceHranyL();
					PosunutiKostkyL();
					//RN
					PosunutiKostkyL();
					RotaceHranyR();
					PosunutiKostkyR();
					//
					PosunutiKostkyV();
					break;
				case "PN":
					//LK
					PosunutiKostkyR();
					RotaceHranyR();
					PosunutiKostkyL();
					//RK
					PosunutiKostkyL();
					RotaceHranyL();
					PosunutiKostkyR();
					//
					PosunutiKostkyA();
					break;
			}
		}

		public void LVL21()
		{
			/*
			1.Spodní stěnou kostky otočit vlevo.
			2.Pravou boční stěnou posuneme k sobě. 
			3.Spodní stěnou kostky otočíme vpravo. 
			4.Pravou boční stěnou posuneme nahoru. 
			5.Čelní stěnou otočíme vlevo. 
			6.Pravou boční stěnou otočíme nahoru. 
			7.Čelní stranou otočíme vpravo. 
			8.Pravou boční stěnou otočíme k sobě. 
			*/
			string[] makro = new string[8] { "SL", "RK", "SR", "RN", "CL", "RN", "CR", "RK" };
			foreach (string x in makro) { Makro(x); }
		}

		public void LVL22() 
		{
			/*
			1.Spodní stěnou kostky otočit vpravo. 
			2.Levou boční stěnou posuneme k sobě. 
			3.Spodní stěnou kostky otočíme vlevo. 
			4.Levou boční stěnou posuneme nahoru. 
			5.Čelní stěnou otočíme vpravo. 
			6.Levou boční stěnou otočíme nahoru. 
			7.Čelní stranou otočíme vlevo. 
			8.Levou boční stěnou otočíme k sobě. 
			*/
			string[] makro = new string[8] { "SR", "LK", "SL", "LN", "CR", "LN", "CL", "LK" };
			foreach (string x in makro) { Makro(x); }
		}

		public void LVL31()
		{
			/*
			1.Pravou boční stěnou k sobě. 
			2.Spodní stěnou vlevo. 
			3.Pravou boční stěnou nahoru. 
			4.Spodní stěnou vpravo. 
			5.Pravou boční stěnou nahoru. 
			6.Čelní stěnou vlevo. 
			7.Pravou boční stěnou k sobě. 
			8.Čelní stěnou vpravo. 
			9.Spodní stěnou vlevo. 
			*/
			string[] makro = new string[9] { "RK", "SL", "RN", "SR", "RN", "CL", "RK", "CR", "SL" };
			foreach (string x in makro) { Makro(x); }
		}

		public void LVL32()
		{
			/*
			1.Pravou boční stěnu k sobě.
			2.Spodní podstavou 2 X doprava. 
			3.Pravou boční stěnou nahoru. 
			4.Spodní podstavou doprava. 
			5.Pravou boční stěnou k sobě. 
			6.Spodní podstavou doprava. 
			7.Pravou boční stěnou nahoru. 
			8.Levou boční stěnou k sobě. 
			9.Spodní podstavou 2 X vlevo. 
			10.Levou boční stěnou nahoru. 
			11.Spodní podstavou vlevo. 
			12.Levou boční stěnou k sobě. 
			13.Spodní podstavou vlevo. 
			14.Levou boční stěnou nahoru. 
			*/
			string[] makro = new string[16] { "RK", "SR", "SR", "RN", "SR", "RK", "SR", "RN", "LK", "SL", "SL", "LN", "SL", "LK", "SL", "LN" };
			foreach (string x in makro) { Makro(x); }
		}

		public void LVL33()
		{
			/*
			1.Prostředním sloupcem k sobě.	PK
			2.Spodní řadou vpravo.			SR
			3.Prostředním sloupcem nahoru.	PN
			4.Spodní řadou 2x vlevo.		SL SL
			5.Prostředním sloupcem k sobě.  PK
			6.Spodní řadou vpravo.			SR
			7.Prostředním sloupcem nahoru.	PN
			*/
			string[] makro = new string[8] { "PK", "SR", "PN", "SL", "SL", "PK", "SR", "PN" };
			foreach (string x in makro) { Makro(x); }
		}

		public void LVL34()
		{
			/*
			1.Pravou boční stěnou k sobě. 
			2.Spodní podstavou doleva. 
			3.Pravou boční stěnou nahoru. 
			4.Spodní podstavou doprava. 
			5.Levou boční stěnou k sobě. 
			6.Spodní podstavou doprava. 
			7.Levou boční stěnou nahoru. 
			8.Spodní podstavou 2x vlevo. 
			9.Pravou boční stěnou k sobě. 
			10.Spodní podstavou vpravo. 
			11.Pravou boční stěnou nahoru.
			12.Spodní podstavou doprava.
			13.Levou boční stěnou k sobě. 
			14.Spodní podstavou doleva. 
			15.Levou boční stěnou nahoru.
			*/
			string[] makro = new string[16] { "RK", "SL", "RN", "SR", "LK","SR","LN", "SL", "SL", "RK", "SR", "RN", "SR", "LK", "SL", "LN" };
			foreach (string x in makro) { Makro(x); }
		}

		public void NewGame()
		{
			Random rnd = new Random();

			for (int i = 0; i < 100; i++)
			{
				switch ((int)rnd.Next(0,13))
				{
					case 0: RotaceHranyR(); break;
					case 1: PosunutiKostkyA(); break;
					case 2: PosunutiKostkyR(); break;
					case 3: RotaceKostkyR(); break;
					case 4: LVL21(); break;
					case 5: LVL22(); break;
					case 6: LVL31(); break;
					case 7: LVL32(); break;
					case 8: LVL33(); break;
					case 9: LVL34(); break;
					case 10: RotaceHranyL(); break;
					case 11: PosunutiKostkyV(); break;
					case 12: PosunutiKostkyL(); break;
					case 13: RotaceKostkyL(); break;
				}
			}
		}
    }
}

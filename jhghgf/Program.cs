using System;
using System.Collections.Generic;

namespace jhghgf
{
	public class Kurs
	{
		public string Naziv { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja { get; set; }
		public TimeSpan VremePocetka { get; set; }
		public TimeSpan Trajanje { get; set; }
		public bool[] DaniUNedelji = new bool[7];

		public bool ProveraDatuma(DateTime datum)
		{
			if (datum.Date >= DatumPocetka.Date && datum.Date <= DatumKraja)
			{
				switch (datum.DayOfWeek)
				{
					case DayOfWeek.Monday:
						if (DaniUNedelji[0])
							return true;
						break;
					case DayOfWeek.Tuesday:
						if (DaniUNedelji[1])
							return true;
						break;
					case DayOfWeek.Wednesday:
						if (DaniUNedelji[2])
							return true;
						break;
					case DayOfWeek.Thursday:
						if (DaniUNedelji[3])
							return true;
						break;
					case DayOfWeek.Friday:
						if (DaniUNedelji[4])
							return true;
						break;
					case DayOfWeek.Saturday:
						if (DaniUNedelji[5])
							return true;
						break;
					case DayOfWeek.Sunday:
						if (DaniUNedelji[6])
							return true;
						break;
				}
			}
			return false;
		}
		public bool ProveraVremena(TimeSpan vreme)
			=> vreme >= VremePocetka && vreme <= VremePocetka + Trajanje;

		public bool ProveraVremena(DateTime vreme)
			=> ProveraDatuma(vreme) && ProveraVremena(vreme.TimeOfDay);
		
	}

	class Program
	{
		static void Main(string[] args)
		{
			Kurs k1 = new();
			k1.Naziv = "Engleski";
			k1.DatumPocetka = DateTime.Parse("10/1/2021");
			k1.DatumKraja = DateTime.Parse("10/31/2021");
			k1.VremePocetka = new(17, 0, 0);
			k1.Trajanje = new(1, 30, 0);
			k1.DaniUNedelji[0] = true;
			k1.DaniUNedelji[2] = true;
			k1.DaniUNedelji[4] = true;

			if (k1.ProveraVremena(DateTime.Parse("10/26/2021").AddHours(17)))
				Console.WriteLine("Ima predavanje!");

			/*for (int i = 0; i <= (k1.DatumKraja - k1.DatumPocetka).Days; i++)
			{
				Console.Write($"Datum: {k1.DatumPocetka.AddDays(i)} -- kurs:");
				if (k1.ProveraDatuma(k1.DatumPocetka.AddDays(i)))
					Console.WriteLine("X");
				else
					Console.WriteLine();
			}*/
		}
	}
}

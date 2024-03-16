using System;

namespace Vjezba.Model;

public class Profesor : Osoba
{
	public string Odjel { get; set; }
	public Zvanje Zvanje { get; set; }
	public DateTime DatumIzbora { get; set; }

	public int KolikoDoReizbora()
	{
		int trajanjeZvanja = Zvanje == Zvanje.Asistent ? 4 : 5;

		return trajanjeZvanja - (DateTime.Now.Year - DatumIzbora.Year);
	}
}

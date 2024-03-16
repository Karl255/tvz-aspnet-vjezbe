using System;

namespace Vjezba.Model;

public class Osoba
{
	public string Ime { get; set; }
	public string Prezime { get; set; }

	private string _oib;
	public string OIB {
		get => _oib;
		set => _oib = value.IsNDigits(11) ? value : throw new InvalidOperationException();
	}

	private string _jmbg;
	public string JMBG {
		get => _jmbg;
		set => _jmbg = value.IsNDigits(13) ? value : throw new InvalidOperationException();
	}

	public DateTime DatumRodjenja
	{
		get
		{
			var dan = JMBG.Substring(0, 2);
			var mjesec = JMBG.Substring(2, 2);
			var godina = JMBG.Substring(4, 3);

			return new(int.Parse(godina) + 1000, int.Parse(mjesec), int.Parse(dan));
		}
	}
}

using System;

namespace Vjezba.Model;

public class Student : Osoba
{
	private string _jmbag;
	public string JMBAG
	{
		get => _jmbag;
		set => _jmbag = value.IsNDigits(10) ? value : throw new InvalidOperationException();
	}

	public decimal Prosjek { get; set; }
	public int BrPolozeno { get; set; }
	public int ECTS { get; set; }
}

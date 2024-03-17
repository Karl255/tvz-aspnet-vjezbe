using System;
using System.Collections.Generic;
using System.Linq;

namespace Vjezba.Model;

public record Fakultet
{
	public List<Osoba> Osobe { get; set; } = [];

	public int KolikoProfesora() => Osobe.Count(o => o is Profesor);
	public int KolikoStudenata() => Osobe.Count(o => o is Student);

	public Student DohvatiStudenta(string jmbag) => Osobe.OfType<Student>().FirstOrDefault(student => student.JMBAG == jmbag);
	public IEnumerable<Profesor> DohvatiProfesore() => Osobe.OfType<Profesor>().OrderBy(p => p.DatumIzbora);

	public IEnumerable<Student> DohvatiStudente91() => Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year > 1991);
	public IEnumerable<Student> DohvatiStudente91NoLinq()
	{
		foreach (var osoba in Osobe)
		{
			if (osoba is Student student && student.DatumRodjenja.Year > 1991)
			{
				yield return student;
			}
		}
	}

	public IEnumerable<Student> StudentiNeTvzD() => Osobe.OfType<Student>().Where(s => !s.JMBAG.StartsWith("0246") && s.Prezime.StartsWith('D'));

	public List<Student> DohvatiStudente91List() => Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year > 1991).ToList();

	public Student NajboljiProsjek(int godina) => Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year == godina).MaxBy(s => s.Prosjek);

	public IEnumerable<Student> StudentiGodinaOrdered(int godina) => Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year == godina).OrderByDescending(s => s.Prosjek);

	public IEnumerable<Profesor> SviProfesori(bool ascending)
	{
		var profesori = Osobe.OfType<Profesor>();

		if (ascending)
		{
			return profesori.OrderBy(p => p.Prezime).ThenBy(p => p.Ime);
		}
		else
		{
			return profesori.OrderByDescending(p => p.Prezime).ThenByDescending(p => p.Ime);
		}
	}

	public int KolikoProfesoraUZvanju(Zvanje zvanje) => Osobe.OfType<Profesor>().Count(p => p.Zvanje == zvanje);

	private static readonly List<Zvanje> NeaktivniZvanje = [Zvanje.Predavac, Zvanje.VisiPredavac];

	public IEnumerable<Profesor> NeaktivniProfesori(int minPredmeta) => Osobe.OfType<Profesor>().Where(p => NeaktivniZvanje.Contains(p.Zvanje) && p.Predmeti.Count < minPredmeta);
}

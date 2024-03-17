﻿using System;
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
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vjezba.Model;

public record Fakultet
{
	public List<Osoba> Osobe { get; set; } = new();

	public int KolikoProfesora() => Osobe.Count(o => o is Profesor);
	public int KolikoStudenata() => Osobe.Count(o => o is Student);

	public Student DohvatiStudenta(string jmbag) => Osobe.OfType<Student>().FirstOrDefault(student => student.JMBAG == jmbag);
}

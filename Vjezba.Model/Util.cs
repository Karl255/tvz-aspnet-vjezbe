using System.Linq;

namespace Vjezba.Model;

internal static class Util
{
	public static bool IsNDigits(this string value, int digitCount) => value.Length == digitCount && value.All(char.IsDigit);
}

namespace Vjezba.Web.Models;

public record FAQViewModel(List<(string, string)> QuestionsAndAnswers, int? Selected);

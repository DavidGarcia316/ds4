Dictionary<String, string> paisesYCapitales = new Dictionary<String, string>();
{
    { "Francia", "Paris"},
    { "España", "Madrid"},
    { "Italia", "Roma"}
};

foreach (KeyValuePair<string, string> par in paisesYCapitales)
{
    Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");
}
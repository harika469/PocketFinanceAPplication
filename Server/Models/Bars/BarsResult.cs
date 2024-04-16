using System.Text.Json.Serialization;

namespace FinanceApp.Server.Models.Bars;

public class BarsResult
{
    public BarsResult(decimal v, double vw, double o, double c, double h, double l, decimal t, int n)
    {
        V = v;
        Vw = vw;
        O = o;
        C = c;
        H = h;
        L = l;
        T = t;
        N = n;
    }

    [JsonPropertyName("v")] public decimal V { get; set; }

    [JsonPropertyName("vw")] public double Vw { get; set; }

    [JsonPropertyName("o")] public double O { get; set; }

    [JsonPropertyName("c")] public double C { get; set; }

    [JsonPropertyName("h")] public double H { get; set; }

    [JsonPropertyName("l")] public double L { get; set; }

    [JsonPropertyName("t")] public decimal T { get; set; }

    [JsonPropertyName("n")] public int N { get; set; }
}
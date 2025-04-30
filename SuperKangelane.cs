using OOP;
using System;

public class SuperKangelane : Kangelane, IPaastja
{
    public double Osavus { get; private set; }

    // Конструктор
    public SuperKangelane(string nimi, string asukoht)
        : base(nimi, asukoht)
    {
        Random rand = new Random();
        Osavus = Math.Round(rand.NextDouble() * 4 + 1, 2); // от 1.00 до 5.00 (не включая 5.0)
    }

    public override int Paasta(int ohus)
    {
        double päästmiseProtsent = 95 + Osavus;
        return (int)Math.Round(ohus * (päästmiseProtsent / 100));
    }

    public override string Vormiriietus()
    {
        return $"{Nimi} kannab futuristlikku superkangelase kostüümi!";
    }

    public override string Tervitus()
    {
        return $"⚡ Mina olen {Nimi}! Õiglus võidab!";
    }

    public override string MissiooniStaatus()
    {
        return $"{Nimi} on hetkel missioonil, kuid võib reageerida hädaolukorrale.";
    }

    public override string ToString()
    {
        return base.ToString() + $" (Superkangelane, Osavus: {Osavus})";
    }
}

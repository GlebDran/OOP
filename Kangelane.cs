using OOP;
using System;

public class Kangelane : IPaastja
{
    private string nimi;
    private string asukoht;

    // Конструктор
    public Kangelane(string nimi, string asukoht)
    {
        this.nimi = nimi;
        this.asukoht = asukoht;
    }

    // Свойства
    public string Nimi
    {
        get { return nimi; }
        set { nimi = value; }
    }

    public string Asukoht
    {
        get { return asukoht; }
        set { asukoht = value; }
    }

    // Методы
    public virtual int Paasta(int ohus)
    {
        return (int)Math.Round(ohus * 0.95);
    }

    public virtual string Vormiriietus()
    {
        return $"{nimi} kannab klassikalist kangelase kostüümi.";
    }

    public virtual string Tervitus()
    {
        return $"Tere! Mina olen {nimi}, sinu kaitsja!";
    }

    public virtual string MissiooniStaatus()
    {
        return $"{nimi} on saadaval.";
    }

    public override string ToString()
    {
        return $"Kangelane: {nimi}, Asukoht: {asukoht}";
    }
}

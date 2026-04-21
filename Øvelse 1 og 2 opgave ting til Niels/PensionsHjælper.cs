namespace Øvelse_1_og_2_opgave_ting_til_Niels;

public static class PensionsHjælper
{
    public const int Pensionsalder = 67;

    public static int BeregnAlder(DateOnly fødselsdato, DateOnly dagsDato)
    {
        int alder = dagsDato.Year - fødselsdato.Year;

        if (dagsDato < fødselsdato.AddYears(alder))
        {
            alder--;
        }

        return alder;
    }

    public static int BeregnÅrTilPension(DateOnly fødselsdato, DateOnly dagsDato)
    {
        int alder = BeregnAlder(fødselsdato, dagsDato);
        return Math.Max(Pensionsalder - alder, 0);
    }
}

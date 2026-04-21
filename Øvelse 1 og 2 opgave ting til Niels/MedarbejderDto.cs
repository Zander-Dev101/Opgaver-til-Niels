namespace Øvelse_1_og_2_opgave_ting_til_Niels;

public sealed class MedarbejderDto
{
    public required string Fornavn { get; set; }
    public required string Efternavn { get; set; }
    public required DateOnly Fødselsdato { get; set; }
    public required Køn Køn { get; set; }
    public required Afdeling Afdeling { get; set; }
}

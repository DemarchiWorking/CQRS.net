namespace Two.Api.Models;

public class ListaEnum
{
    public string Descricao { get; set; }
    public string Valor { get; set; }

    public ListaEnum(string descricao, string valor)
    {
        Descricao = descricao;
        Valor = valor;
    }
}
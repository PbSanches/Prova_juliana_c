using System;
using System.ComponentModel.DataAnnotations;

public class Veiculo
{
    public int IdVeiculo { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    [Range(1890, int.MaxValue, ErrorMessage = """O ano deve ser maior que 1930.""")]
    public int Ano { get; set; }

    [Required]
    public string Placa { get; set; }

    [Required]
    public string Modelo { get; set; }

    [Required]
    public string Marca { get; set; }

    [Required]
    public string Cor { get; set; }
}

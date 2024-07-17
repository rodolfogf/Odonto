using Odonto.Models;
using System.ComponentModel.DataAnnotations;

namespace Odonto.Data.Dtos;

public class UpdatePacienteDto
{
    [Required(ErrorMessage = "O nome do paciente é obrigatório")]
    [StringLength(60,ErrorMessage = "O tamanho máximo para o nome é de 60 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória")]
    [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
    public DateTime DataNascimento { get; set; }
    [Required]
    [EnumDataType(typeof(Genero))]
    public Genero Genero { get; set; }
    public bool Pcd { get; set; }
    [Required(ErrorMessage = "O número de telefone é obrigatório")]
    [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Digite apenas números")]
    public string Telefone { get; set; }
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Formato inválido de CEP")]
    public string Cep { get; set; }
    /*[EmailAddress]
    public string Email { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cpf { get; set; }*/
}

namespace PsicoOnline.UI.Models;

public class PacienteModel
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O nome do paciente é obrigatório.")]
    [StringLength(300, ErrorMessage = "O nome do paciente deve ter no máximo 300 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime DataNascimento { get; set; }

    private int _idade;

    public int GetIdade()
    {
        SetIdade();

        return _idade;
    }

    private void SetIdade()
    {
        var idade = DateTime.Now.Year - DataNascimento.Year;

        if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
        {
            idade--;
        }

        _idade = idade;
    }

    [StringLength(11, ErrorMessage = "O telefone do paciente deve ter no máximo 11 caracteres.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "O telefone do paciente só deve conter números.")]
    public string Telefone { get; set; }

    public char Genero { get; set; }
}
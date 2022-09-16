namespace PsicoOnline.UI.Models;

public class PacienteModel
{
    public int Id { get; set; }

    public string Nome { get; set; }

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

    public string Telefone { get; set; }

    public char Genero { get; set; }
}
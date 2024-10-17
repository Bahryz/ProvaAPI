using Aluno2.Models;

public class Folha
{
    public int FolhaId { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal ImpostoIrrf { get; set; }
    public decimal ImpostoInss { get; set; }
    public decimal ImpostoFgts { get; set; }
    public decimal SalarioLiquido { get; set; }
    
    public Funcionario? FuncionarioFolha { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrudDocker.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    // Pode ser "Income" (Receita) ou "Expense" (Despesa)
    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = string.Empty; 
}
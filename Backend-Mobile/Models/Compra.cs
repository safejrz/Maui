using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetKubernetes.Models;

public class Compra {
    [Key]
    [Required]
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public int Cantidad { get; set; }
   
    [Column(TypeName = "decimal(18,4)")]
    public decimal ProductoPrecio { get; set; }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiRestCurso.Validation;

namespace ApiRestCurso.Modelo
{
    [Table("tb_produtos")]
    public class Produtos: IValidatableObject 
    {
        [Key]
        public int ProdId { get; set; }

        //[Required(ErrorMessage ="O nome é obrigatóri0")]
        //[MaxLength(80,ErrorMessage ="Tamanho maxi 80 caracteres")]

        //[PrimeiraLetraMaiuscula]
        public String Nome { get; set; }

        [Required(ErrorMessage ="Descrição obrigatória")]
        public String Descricao { get; set; }

        public String Preco { get; set; }

        [StringLength(maximumLength: 1, ErrorMessage ="Campo de ser preenchido com no minimo um caracter e no máximo 100", MinimumLength = 1)]
        public String ImagemUrl { get; set; }

        public int Estoque { get; set; }

        public DateTime DtCadastro { get; set; }

        public Categoria categoria { get; set; }

        public int CategoriaId { get; set; }

        [Range(1, 10,ErrorMessage ="Não eceitamos pesos acima de 10kg")]
        [RegularExpression("[0-9]{1,2}",ErrorMessage = "Peso de ser informar com valor numerico")]
        public int peso { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nome[0].ToString() != Nome[0].ToString().ToUpper())
            {
                yield return new ValidationResult("Nome invalido", new[] {nameof(this.Nome)});
            }

            if(Estoque <= 10)
            {
                yield return new ValidationResult("Não aceitamos estoque abaixo de 10", new[] { nameof(this.Estoque)});
            }
        }


    }
}

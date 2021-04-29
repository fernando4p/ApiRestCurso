using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCurso.Modelo
{   
    [Table("tb_categoria")]
    public class Categoria
    {
        public Categoria()
        {
            produtos = new Collection<Produtos>();
        }
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        public String ImagemUrl { get; set; }

        [Required]
        public String Nome { get; set; }

        public ICollection<Produtos> produtos { get; set; }

        
    }
}

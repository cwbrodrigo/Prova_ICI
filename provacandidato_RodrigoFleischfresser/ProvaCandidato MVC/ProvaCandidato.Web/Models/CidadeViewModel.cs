using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaCandidato.Models
{
    public class CidadeViewModel
    {
        public CidadeViewModel()
        {
            CidadeViewModels = new List<CidadeViewModel>();
        }
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 letras e no máximo 50")]
        [Required]
        public string Nome { get; set; }

        public List<CidadeViewModel> CidadeViewModels { get; set; }
    }
}
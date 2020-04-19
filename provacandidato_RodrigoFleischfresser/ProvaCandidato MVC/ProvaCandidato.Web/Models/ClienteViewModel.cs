using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaCandidato.Models
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteViewModels = new List<ClienteViewModel>();
        }
        public int Codigo { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 letras e no máximo 50")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

        public List<ClienteViewModel> ClienteViewModels { get; set; }
    }
}
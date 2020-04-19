using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProvaCandidato.Data.Custom.DateCheck;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 letras e no máximo 50")]
        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [CurrentDate(ErrorMessage = "A data não pode ser maior que a data atual")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Cidade obrigatória")]
        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        public bool Ativo { get; set; }


    }
}
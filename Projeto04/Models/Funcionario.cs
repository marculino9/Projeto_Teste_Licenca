﻿using Projeto02.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto02.Models
{
    public class Funcionario : EntityBase
    {
        [Required(ErrorMessage = "O nome é obrigatória")] //Nome do funcionario
        public string Nome { get; set; }
        [Required] //Equipe
        public virtual Equipe Equipe { get; set; }
        [Required(ErrorMessage = "A equipe é obrigatória")]
        public int EquipeId { get; set; }
        [Required] //Cargo
        public virtual Cargo Cargo { get; set; }
        [Required(ErrorMessage = "* Cargo é obrigatório")]
        public int CargoId { get; set; }
        [Required(ErrorMessage = "O nome da maquina é obrigatória")] //Nome do computador do funcionario
        public string Maquina { get; set; }
        [Required]
        public int CodigoVerificacao { get; set; } //AQUI
        [Required]
        public virtual IList<Usuario> Usuarios { get; set; } 
        [Required(ErrorMessage ="* Tipo de perfil é obrigatório")]
        public TipoPerfil TipoPerfil { get; set; }
    }
}
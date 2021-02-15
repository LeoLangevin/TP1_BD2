using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetsORM.Entites
{
    [Table("CLIENT")]
    public class Client
    {
        #region Propriétés
        [Key]
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string NomClient { get; set; }

        [Required]
        public int NoEnregistrement { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Rue { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Ville { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string CodePostal { get; set; }

        public decimal? Telephone { get; set; }
        #endregion Propriétés

        #region Propriétés de navigation 

        //public virtual Projet Projet { get; set; }
        public virtual ICollection<Projet> Projets { get; set; }
        #endregion Propriétés de navigation 

        #region Constructeur
        public Client()
        {
            Projets = new List<Projet>();
        }
        #endregion Constructeur
    }
}

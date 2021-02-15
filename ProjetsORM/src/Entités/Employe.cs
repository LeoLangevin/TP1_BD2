using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetsORM.Entites
{
    [Table("EMPLOYE")]
    public class Employe
    {
        #region Propriétés
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short NoEmploye { get; set; }

        [Required]
        public decimal NAS { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Nom { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Prenom { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateEmbauche { get; set; }

        public decimal? Salaire { get; set; }

        public decimal? TelephoneBureau { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Adresse { get; set; }

        public short? NoSuperviseur { get; set; }

        #endregion Propriétés

        #region Propriétés de navigation

        public virtual ICollection<Projet> Projets { get; set; }

        [ForeignKey("NoSuperviseur")]
        public virtual Employe Superviseur { get; set; }

        #endregion Propriétés de navigation

        #region Constructeur

        public Employe()
        {
            Projets = new List<Projet>();
        }
        #endregion Constructeur

    }
}


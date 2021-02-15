using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetsORM.Entites
{
    [Table("PROJET")]
    public class Projet
    {
        #region Propriétés
        
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string NomProjet { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string NomClient { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateDebut { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateFin { get; set; }

        [Required]
        public short NoGestionnaire { get; set; }

        public int? NoContactClient { get; set; }

        #endregion Propriétés

        #region Propriétés de navigation 

        [ForeignKey("NomClient")]
        public virtual Client Client { get; set; }

        [ForeignKey("NoGestionnaire")]
        public virtual Employe Employe { get; set; }
        #endregion Propriétés de navigation 

        #region Constructeur
        #endregion Constructeur
    }
}

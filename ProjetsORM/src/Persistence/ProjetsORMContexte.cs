using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetsORM.Entites;

namespace ProjetsORM.Persistence
{
    public class ProjetsORMContexte : DbContext
    {
        #region Propriétés DBSet
        #endregion Propriétés DBSet

         #region Constructeur
        public ProjetsORMContexte(DbContextOptions<ProjetsORMContexte> options) : base(options)
        {
        }
        #endregion Constructeur


        #region Configuration modèle
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*** Entité Client ***/
            //Clé unique




            /*** Entité Employe ***/
            //Clé unique


            //Lien vers Employé: "Superviseur"




            /*** Entité Projet ***/
            //Clé primaire


            //Lien vers Client


            //Lienvers Employé¸: "Gestionnaire"


            //Lien vers Employé: "Contact_Client"


        }
        #endregion  Configuration modèle
    }
}

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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Employe> Employes { get; set; }

        public virtual DbSet<Projet> Projets { get; set; }

        public virtual DbSet<Client> Clients { get; set; }


        #endregion Constructeur


        #region Configuration modèle
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*** Entité Client ***/
            //Clé unique
            builder.Entity<Client>()
                .HasIndex(u => u.NoEnregistrement)
                .IsUnique();

            builder.Entity<Client>()
                 .HasIndex(u => u.NomClient)
                 .IsUnique();

            /*** Entité Employe ***/
            //Clé unique
            builder.Entity<Employe>()
               .HasIndex(u => u.NAS)
               .IsUnique();

            //Lien vers Employé: "Superviseur"
            builder.Entity<Employe>()
                 .HasIndex(u => u.NoSuperviseur)
                 .IsUnique();

            builder.Entity<Employe>()
                .HasOne(e => e.Superviseur)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            /*** Entité Projet ***/
            //Clé primaire
            builder.Entity<Projet>()
                .HasKey(pk => new { pk.NomProjet, pk.NomClient });

            builder.Entity<Projet>()
                .HasOne(projet => projet.Client)
                .WithMany(client => client.Projets)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Projet>()
                .HasOne(projet => projet.Employe)
                .WithMany(employ => employ.Projets)
                .OnDelete(DeleteBehavior.Restrict);
            //Lien vers Client
            builder.Entity<Projet>()
                .HasKey(projet => new { projet.NomClient });

            //Lien vers Employé¸: "Gestionnaire"


            //Lien vers Employé: "Contact_Client"


        }
        #endregion  Configuration modèle
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjetsORM.AccesDonnees
{
    public class EFEmployeRepositoryTest
    {
        private EFEmployeRepository repoEmploye;

        private void CreerContexteEtReposDeTests()
        {
            var builder = new DbContextOptionsBuilder<ProjetsORMContexte>();
            builder.UseInMemoryDatabase(databaseName: "client_db1");   // Database en mémoire
            var contexte = new ProjetsORMContexte(builder.Options);
            repoEmploye = new EFEmployeRepository(contexte);
        }

        [Fact] // LE TESTE MARCHE QUAND ON LE START TOUT SEUL MAIS CHEQUER AVEC LE PROF PARCE QUE QUAND ON FAIS LES TESTS EN GANG IL MARCHE PAS
        public void AjouterEmploye_DoitAjouterEmploye()
        {

            CreerContexteEtReposDeTests();
            Employe empl1123 = new Employe { NAS = 1, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            
            repoEmploye.AjouterEmploye(empl1123);

            Assert.Equal(empl1123, repoEmploye.ObtenirEmployee(empl1123.NoEmploye));
            /* */
        }

        [Fact]
        public void RechercherTousEmployes_DoitRetournerListDesEmployes()
        {

            CreerContexteEtReposDeTests();
            Employe empl1 = new Employe() { NAS = 1, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            Employe empl2 = new Employe() { NAS = 2, Nom = "Lea", Prenom = "Brocard", DateEmbauche = Convert.ToDateTime("2002-12-19") };
            Employe empl3 = new Employe() { NAS = 3, Nom = "Pea", Prenom = "Water", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            Employe empl4 = new Employe() { NAS = 4, Nom = "Sea", Prenom = "Wet", DateEmbauche = Convert.ToDateTime("2002-12-19") };
            Employe empl5 = new Employe() { NAS = 5, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2100-10-24") };

            List<Employe> yuh = new List<Employe>();
            repoEmploye.AjouterEmploye(empl1);
            repoEmploye.AjouterEmploye(empl2);
            repoEmploye.AjouterEmploye(empl3);
            repoEmploye.AjouterEmploye(empl4);
            repoEmploye.AjouterEmploye(empl5);

            yuh.Add(empl1);
            yuh.Add(empl2);
            yuh.Add(empl3);
            yuh.Add(empl4);
            yuh.Add(empl5);

            Assert.Equal(yuh, repoEmploye.RechercherTousEmployes());
        }
        [Fact]
        public void RechercherEmployesParNom_DoitRetournerListDesEmployes()
        {

            CreerContexteEtReposDeTests();
            Employe empl1 = new Employe() { NAS = 1, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            Employe empl2 = new Employe() { NAS = 2, Nom = "Lea", Prenom = "Brocard", DateEmbauche = Convert.ToDateTime("2002-12-19") };
            Employe empl3 = new Employe() { NAS = 3, Nom = "Pea", Prenom = "Water", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            Employe empl4 = new Employe() { NAS = 4, Nom = "Sea", Prenom = "Wet", DateEmbauche = Convert.ToDateTime("2002-12-19") };
            Employe empl5 = new Employe() { NAS = 5, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2100-10-24") };

            List<Employe> yuh = new List<Employe>();
            repoEmploye.AjouterEmploye(empl1);
            repoEmploye.AjouterEmploye(empl2);
            repoEmploye.AjouterEmploye(empl3);
            repoEmploye.AjouterEmploye(empl4);
            repoEmploye.AjouterEmploye(empl5);

            yuh.Add(empl1);
            yuh.Add(empl5);

            Assert.Equal(yuh, repoEmploye.RechercherEmployesParNom("Leo", "Langevin"));
            /* */
        }
    }
}

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
            builder.UseInMemoryDatabase(databaseName: "employe_db");   // Database en mémoire
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
        }

        [Fact]
        public void RechercherTousSuperviseurs_DoitRetournerListDesSuperviseurs()
        {
            CreerContexteEtReposDeTests();
            Employe empl1 = new Employe() { NAS = 1, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2000-10-24"), NoSuperviseur = 1 };
            Employe empl2 = new Employe() { NAS = 2, Nom = "Lea", Prenom = "Brocard", DateEmbauche = Convert.ToDateTime("2002-12-19"), NoSuperviseur = 2 };
            Employe empl3 = new Employe() { NAS = 3, Nom = "Pea", Prenom = "Water", DateEmbauche = Convert.ToDateTime("2000-10-24") };
            Employe empl4 = new Employe() { NAS = 4, Nom = "Sea", Prenom = "Wet", DateEmbauche = Convert.ToDateTime("2002-12-19") };
            Employe empl5 = new Employe() { NAS = 5, Nom = "Leo", Prenom = "Langevin", DateEmbauche = Convert.ToDateTime("2100-10-24") };
            List<Employe> expectedSuperviseurs = new List<Employe>() { empl1, empl2 };
            repoEmploye.AjouterEmploye(empl1);
            repoEmploye.AjouterEmploye(empl2);
            repoEmploye.AjouterEmploye(empl3);
            repoEmploye.AjouterEmploye(empl4);
            repoEmploye.AjouterEmploye(empl5);

            ICollection<Employe> actualSuperviseurs = repoEmploye.RechercherTousSuperviseurs();

            Assert.Equal(expectedSuperviseurs, actualSuperviseurs);
        }

        [Fact]
        public void ObtenirEmployesSupervises_DoitRetournerListDesEmployesSupervises()
        {
            CreerContexteEtReposDeTests();
            Employe superEmpl1 = new Employe() { NAS = 10, Nom = "HAHA", Prenom = "Non", DateEmbauche = Convert.ToDateTime("2001-10-24") };
            Employe superEmpl2 = new Employe() { NAS = 20, Nom = "Xnine", Prenom = "Oui", DateEmbauche = Convert.ToDateTime("2003-12-19") };
            Employe superEmpl3 = new Employe() { NAS = 30, Nom = "SaMarche", Prenom = "pas", DateEmbauche = Convert.ToDateTime("2005-10-24"), NoSuperviseur = 3 };
            Employe superEmpl4 = new Employe() { NAS = 40, Nom = "Jose", Prenom = "Allah", DateEmbauche = Convert.ToDateTime("2006-12-19")};
            Employe superEmpl5 = new Employe() { NAS = 50, Nom = "Dan", Prenom = "Akbahr", DateEmbauche = Convert.ToDateTime("2107-03-21") };
            superEmpl1.Superviseur = superEmpl3;
            superEmpl2.Superviseur = superEmpl3;
            repoEmploye.AjouterEmploye(superEmpl1);
            repoEmploye.AjouterEmploye(superEmpl2);
            repoEmploye.AjouterEmploye(superEmpl3);
            repoEmploye.AjouterEmploye(superEmpl4);
            repoEmploye.AjouterEmploye(superEmpl5);
            List<Employe> expectedSuperviseurs = new List<Employe>() { superEmpl1, superEmpl2 };

            ICollection<Employe> actualSuperviseurs = repoEmploye.ObtenirEmployesSupervises((short)superEmpl3.NoSuperviseur);

            Assert.Equal(expectedSuperviseurs, actualSuperviseurs);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetsORM.EntiteDTOs;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using Xunit;

namespace ProjetsORM.AccesDonnees
{
    public class EFProjetRepositoryTest
    {
        private EFProjetRepository repoProjet;
        private EFClientRepository repoClient;

        private void CreerContexteEtReposDeTests()
        {
            var builder = new DbContextOptionsBuilder<ProjetsORMContexte>();
            builder.UseInMemoryDatabase(databaseName: "projet_db");   // Database en mémoire
            var contexte = new ProjetsORMContexte(builder.Options);
            repoProjet = new EFProjetRepository(contexte);
            repoClient = new EFClientRepository(contexte);
        }

        [Fact] // LE TESTE MARCHE QUAND ON LE START TOUT SEUL MAIS CHEQUER AVEC LE PROF PARCE QUE QUAND ON FAIS LES TESTS EN GANG IL MARCHE PAS
        public void AjouterProjet_DoitAjouterProjet()
        {
            CreerContexteEtReposDeTests();
            Projet projetX = new Projet { NomProjet = "Fix", NomClient = "Leo", NoGestionnaire = 1 };

            repoProjet.AjouterProjet(projetX);

            Assert.Equal(projetX, repoProjet.ObtenirProjet(projetX.NomProjet, projetX.NomClient));
        }

        [Fact]
        public void ModifierProjet_DoitModifierProjet()
        {
            CreerContexteEtReposDeTests();
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "Leo", NoGestionnaire = 1 };

            repoProjet.AjouterProjet(projet1);
            projet1.NoContactClient = 3;

            repoProjet.ModifierProjet(projet1);

            Assert.Equal(3, projet1.NoContactClient);
        }

        [Fact] 
        public void SupprimerProjet_DoitSupprimerProjet()
        {
            CreerContexteEtReposDeTests();
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "Leo", NoGestionnaire = 1 };

            repoProjet.AjouterProjet(projet1);

            repoProjet.SupprimerProjet(projet1);
            var resultat = repoProjet.ObtenirProjet("Sick", "Leo");

            Assert.Null(resultat);
        }

        [Fact]
        public void ObtenirBudgetTotalPourUnClient_RetourneBudgetTotal()
        {
            CreerContexteEtReposDeTests();
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "WebLab", NoGestionnaire = 1,  Budget = 350 };
            Projet projet2 = new Projet { NomProjet = "Yah", NomClient = "WebLab", NoGestionnaire = 2,  Budget = 250 };
            Projet projet3 = new Projet { NomProjet = "Caller", NomClient = "WebLab", NoGestionnaire = 3, Budget = 100 };

            webLab.Projets.Add(projet1);
            webLab.Projets.Add(projet2);
            webLab.Projets.Add(projet3);
            repoClient.AjouterClient(webLab);

            decimal? resultat = repoProjet.ObtenirBudgetTotalPourUnClient(webLab.NomClient);

            Assert.Equal(700, resultat);
        }

        [Fact]
        public void ObtenirBudgetMoyenPourUnClient_RetourneBudgetMoyenl()
        {
            CreerContexteEtReposDeTests();
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "WebLab", NoGestionnaire = 1, Budget = 200 };
            Projet projet2 = new Projet { NomProjet = "Yah", NomClient = "WebLab", NoGestionnaire = 2, Budget = 50 };
            Projet projet3 = new Projet { NomProjet = "Caller", NomClient = "WebLab", NoGestionnaire = 3, Budget = 350 };
            webLab.Projets.Add(projet1);
            webLab.Projets.Add(projet2);
            webLab.Projets.Add(projet3);
            repoClient.AjouterClient(webLab);
            decimal? expectedResultat = 200;

            decimal? actualResultat = repoProjet.ObtenirBudgetMoyenPourUnClient(webLab.NomClient);

            Assert.Equal(expectedResultat, actualResultat);
        }

        [Fact]
        public void RechercherClientsAvecNombreProjetsEtBudgetTotalEtBudgetMoyen_RetourneCela()
        {
            CreerContexteEtReposDeTests();
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "WebLab", NoGestionnaire = 1, Budget = 200 };
            Projet projet2 = new Projet { NomProjet = "Yah", NomClient = "WebLab", NoGestionnaire = 2, Budget = 50 };
            Projet projet3 = new Projet { NomProjet = "Caller", NomClient = "WebLab", NoGestionnaire = 3, Budget = 350 };
            webLab.Projets.Add(projet1);
            webLab.Projets.Add(projet2);
            webLab.Projets.Add(projet3);
            repoClient.AjouterClient(webLab);
            StatsClient expectedStats = new StatsClient();
            expectedStats.NomClient = "WebLab";
            expectedStats.NombreProjets = 3;
            expectedStats.BudgetTotal = 700;
            expectedStats.BudgetMoyen = 200;


            StatsClient actualResultat = (StatsClient)repoProjet.RechercherClientsAvecNombreProjetsEtBudgetTotalEtBudgetMoyen();

            Assert.Equal(expectedStats, actualResultat);
        }
    }
}

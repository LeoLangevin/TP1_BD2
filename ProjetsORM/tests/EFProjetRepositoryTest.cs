using Microsoft.EntityFrameworkCore;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using Xunit;

namespace ProjetsORM.AccesDonnees
{
    public class EFProjetRepositoryTest
    {
        private EFProjetRepository repoProjet;

        private void CreerContexteEtReposDeTests()
        {
            var builder = new DbContextOptionsBuilder<ProjetsORMContexte>();
            builder.UseInMemoryDatabase(databaseName: "client_db3");   // Database en mémoire
            var contexte = new ProjetsORMContexte(builder.Options);
            repoProjet = new EFProjetRepository(contexte);
        }

        [Fact] // LE TESTE MARCHE QUAND ON LE START TOUT SEUL MAIS CHEQUER AVEC LE PROF PARCE QUE QUAND ON FAIS LES TESTS EN GANG IL MARCHE PAS
        public void AjouterProjet_DoitAjouterProjet()
        {

            CreerContexteEtReposDeTests();
            Projet projetX = new Projet { NomProjet = "Fix", NomClient = "Leo", NoGestionnaire = 1 };

            repoProjet.AjouterProjet(projetX);

            Assert.Equal(projetX, repoProjet.ObtenirProjet(projetX.NomProjet, projetX.NomClient));
            /* */
        }

        [Fact]
        public void ModifierProjet_DoitModifierProjet()
        {

            CreerContexteEtReposDeTests();
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "Leo", NoGestionnaire = 1 };
            Projet projet2 = new Projet { NomProjet = "Reading", NomClient = "Boulier", NoGestionnaire = 20 };

            repoProjet.AjouterProjet(projet1);

            repoProjet.ModifierProjet(projet2);

            Assert.Equal(projet2, repoProjet.ObtenirProjet(projet2.NomProjet, projet2.NomClient));
            /* */
        }

        [Fact] 
        public void SupprimerProjet_DoitSupprimerProjet()
        {

            CreerContexteEtReposDeTests();
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "Leo", NoGestionnaire = 1 };
            Projet projet2 = new Projet { NomProjet = "Reading", NomClient = "Boulier", NoGestionnaire = 20 };

            repoProjet.AjouterProjet(projet1);

            repoProjet.ModifierProjet(projet2);

            Assert.Equal(projet2, repoProjet.ObtenirProjet(projet2.NomProjet, projet2.NomClient));
            /* */
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjetsORM.AccesDonnees
{
    public class EFClientRepositoryTest
    {
        private EFClientRepository repoClient;
        private EFProjetRepository repoProjet;

        private void CreerContexteEtReposDeTests()
        {
            var builder = new DbContextOptionsBuilder<ProjetsORMContexte>();
            builder.UseInMemoryDatabase(databaseName: "client_db");   // Database en mémoire
            var contexte = new ProjetsORMContexte(builder.Options);
            repoClient = new EFClientRepository(contexte);
            repoProjet = new EFProjetRepository(contexte);
        }

        [Fact]
        public void AjouterClient_DoitAjouterClient()
        {
            CreerContexteEtReposDeTests();
            Client coveo = new Client { NomClient = "Coveo", NoEnregistrement = 111, Ville = "Québec", CodePostal = "G3G1G1" };

            repoClient.AjouterClient(coveo);

            Assert.Equal(coveo, repoClient.RechercherClientParNom(coveo.NomClient));
        }

        [Fact]
        public void ObtenirClient_QuandClientExistePas()
        {
            CreerContexteEtReposDeTests();
            string nomClientARechercher = "Coveo";
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client cgi = new Client { NomClient = "CGI", NoEnregistrement = 22100, Ville = "Québec", CodePostal = "G7L1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(cgi);
            repoClient.AjouterClient(spektrum);

            Assert.Throws<ArgumentException>(() => repoClient.ObtenirClient(nomClientARechercher));
            /* */
        }

        [Fact]
        public void ObtenirClient_QuandClientExiste()
        {
            CreerContexteEtReposDeTests();
            string nomClientARechercher = "Coveo";
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client coveo = new Client { NomClient = nomClientARechercher, NoEnregistrement = 1111, Ville = "Québec", CodePostal = "G3G1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(coveo);
            repoClient.AjouterClient(spektrum);

            Client clientTrouve = repoClient.RechercherClientParNom(nomClientARechercher);

            Assert.Equal(coveo, clientTrouve);
            Assert.Same(coveo, clientTrouve);
            /**/
        }

        [Fact]
        public void RechercherClientParVille_QuandAucunClient()
        {
            CreerContexteEtReposDeTests();
            string nomVilleARechercher = "Ste-Catherine";
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client cgi = new Client { NomClient = "CGI", NoEnregistrement = 22100, Ville = "Québec", CodePostal = "G7L1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(cgi);
            repoClient.AjouterClient(spektrum);

            ICollection<Client> clientsTrouves = repoClient.RechercherClientParVille(nomVilleARechercher);

            Assert.Empty(clientsTrouves);
           
        }

        [Fact]
        public void RechercherClientParVille_QuandUnClient()
        {
            CreerContexteEtReposDeTests();
            string nomVilleARechercher = "Québec";
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client cgi = new Client { NomClient = "CGI", NoEnregistrement = 22100, Ville = nomVilleARechercher, CodePostal = "G7L1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            ICollection<Client> clientsQuebec = new List<Client> { cgi };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(cgi);
            repoClient.AjouterClient(spektrum);

            ICollection<Client> clientsTrouves = repoClient.RechercherClientParVille(nomVilleARechercher);

            Assert.Equal(clientsQuebec, clientsTrouves);
        }

        [Fact]
        public void RechercherClientParVille_QuandPlusieursClients()
        {
            CreerContexteEtReposDeTests();
            string nomVilleARechercher = "Québec";
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client cgi = new Client { NomClient = "CGI", NoEnregistrement = 22100, Ville = nomVilleARechercher, CodePostal = "G7L1G1" };
            Client coveo = new Client { NomClient = "Coveo", NoEnregistrement = 1111, Ville = nomVilleARechercher, CodePostal = "G3G1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            Client ubisoft = new Client { NomClient = "Ubisoft", NoEnregistrement = 1111, Ville = "Gaspé", CodePostal = "G3G1G1" };
            Client uLaval = new Client { NomClient = "ULaval", NoEnregistrement = 5400, Ville = nomVilleARechercher, CodePostal = "T5L1V1" };
            ICollection<Client> clientsQuebec = new List<Client> { cgi, coveo, uLaval };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(cgi);
            repoClient.AjouterClient(coveo);
            repoClient.AjouterClient(spektrum);
            repoClient.AjouterClient(ubisoft);
            repoClient.AjouterClient(uLaval);

            ICollection<Client> clientsTrouves = repoClient.RechercherClientParVille(nomVilleARechercher);

            Assert.Equal(clientsQuebec, clientsTrouves);
        }

        [Fact]
        public void ObtenirProjetsPourUnClient_RetourneProjetPourUnClient()
        {
            CreerContexteEtReposDeTests();
            Client webLab = new Client { NomClient = "WebLab", NoEnregistrement = 1100, Ville = "Matane", CodePostal = "G5L1G1" };
            Client cgi = new Client { NomClient = "CGI", NoEnregistrement = 22100, CodePostal = "G7L1G1" };
            Client spektrum = new Client { NomClient = "Spektrum", NoEnregistrement = 5400, Ville = "Lévis", CodePostal = "T5L1V1" };
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "WebLab", NoGestionnaire = 1, Budget = 350 };
            Projet projet2 = new Projet { NomProjet = "Yah", NomClient = "WebLab", NoGestionnaire = 2, Budget = 250 };
            Projet projet3 = new Projet { NomProjet = "Caller", NomClient = "WebLab", NoGestionnaire = 3, Budget = 100 };
            cgi.Projets.Add(projet1);
            cgi.Projets.Add(projet2);
            cgi.Projets.Add(projet3);
            ICollection<Projet> expectedProjets = new List<Projet> { projet1, projet2, projet3 };
            repoClient.AjouterClient(webLab);
            repoClient.AjouterClient(cgi);
            repoClient.AjouterClient(spektrum);

            ICollection<Projet> projetsTrouves = repoClient.ObtenirProjetsPourUnClient(cgi.NomClient);

            Assert.Equal(expectedProjets, projetsTrouves);
        }

        [Fact]
        public void ObtenirProjetsEnCoursPourUnClient_RetourneProjetsEnCoursPourUnClient()
        {
            CreerContexteEtReposDeTests();
            Client coveo = new Client { NomClient = "Coveo", NoEnregistrement = 111, Ville = "Québec", CodePostal = "G3G1G1" };
            Projet projet1 = new Projet { NomProjet = "Sick", NomClient = "WebLab", DateDebut = Convert.ToDateTime("1977-10-10"), DateFin = Convert.ToDateTime("2022-10-21"), NoGestionnaire = 1, Budget = 200 };
            Projet projet2 = new Projet { NomProjet = "Yah", NomClient = "WebLab", DateDebut = Convert.ToDateTime("1977-10-10"), DateFin = Convert.ToDateTime("1988-10-12"), NoGestionnaire = 2, Budget = 50 };
            Projet projet3 = new Projet { NomProjet = "Caller", NomClient = "WebLab", DateDebut = Convert.ToDateTime("1977-10-10"), DateFin = Convert.ToDateTime("2023-10-20"), NoGestionnaire = 3, Budget = 350 };
            ICollection<Projet> expectedResultat = new List<Projet> { projet1, projet3 };
            coveo.Projets.Add(projet1);
            coveo.Projets.Add(projet2);
            coveo.Projets.Add(projet3);
            repoClient.AjouterClient(coveo);

            ICollection<Projet> projetsEnCours = repoClient.ObtenirProjetsEnCoursPourUnClient(coveo.NomClient);

            Assert.Equal(expectedResultat, projetsEnCours);
        }
    }
}

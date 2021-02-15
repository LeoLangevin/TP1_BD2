using ProjetsORM.EntiteDTOs;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetsORM.AccesDonnees
{
    public class EFClientRepository
    {
        #region Propriétés

        private ProjetsORMContexte contexte;

        #endregion Propriétés

        #region Constructeur
        public EFClientRepository(ProjetsORMContexte contexte)
        {
            this.contexte = contexte;
        }
        #endregion Constructeur

        #region Méthodes
        public void AjouterClient(Client client)
        {
            contexte.Clients.Add(client);
            contexte.SaveChanges();
        }
        public Client ObtenirClient(string nomClient)
        {
            Client clientBoy = contexte.Clients.Find(nomClient);
            if (clientBoy != null)
            {
                return clientBoy;
            }
            else
            {
                throw new ArgumentException("Help", nameof(nomClient));
            }
        }

        public ICollection<Client> RechercherClientParVille(string nomVille)
        {
            return contexte.Clients.Where(client => client.Ville == nomVille).ToList();
                                            //.GroupBy(client => client.NomClient)
        }

        public Client RechercherClientParNom(string nomClient)
        {
            return contexte.Clients.Find(nomClient);
        }

        public ICollection<Projet> ObtenirProjetsPourUnClient(string nomClient)
        {
            Client client = contexte.Clients.Find(nomClient);
            if (client != null)
            {
                return client.Projets.ToList();
            }
            else
            {
                return null;
            }
        }

        public ICollection<Projet> ObtenirProjetsEnCoursPourUnClient(string nomClient)
        {
            throw new NotImplementedException();
        }

        public ICollection<StatsClient> RechercherClientsAvecNombreProjetsEtBudgetTotalEtBudgetMoyen()
        {
            throw new NotImplementedException();
        }
    }
    #endregion Méthodes
}

using ProjetsORM.EntiteDTOs;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;

namespace ProjetsORM.AccesDonnees
{
    class EFClientRepository
    {
        #region Propriétés
        #endregion Propriétés

        #region Constructeur
        public EFClientRepository(ProjetsORMContexte contexte)
        {
        }
        #endregion Constructeur

        #region Méthodes
        public void AjouterClient(Client client)
        {
            throw new NotImplementedException();
        }
        public Client ObtenirClient(string nomClient)
        {
            throw new NotImplementedException();
        }

        public ICollection<Client> RechercherClientParVille(string nomVille)
        {
            throw new NotImplementedException();
        }

        public ICollection<Projet> ObtenirProjetsPourUnClient(string nomClient)
        {
            throw new NotImplementedException();
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

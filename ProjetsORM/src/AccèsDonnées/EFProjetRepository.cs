using ProjetsORM.EntiteDTOs;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;

namespace ProjetsORM.AccesDonnees
{
    class EFProjetRepository
    {
        #region Propriétés
        #endregion Propriétés

        #region Constructeur
        public EFProjetRepository (ProjetsORMContexte contexte)
        {
        }
        #endregion Constructeur

        #region Méthodes
        public void AjouterProjet(Projet projet)
        {
            throw new NotImplementedException();
        }

        public Client ObtenirProjet(string nomProjet, string nomClient)
        {
            throw new NotImplementedException();
        }

        public void ModifierProjet(Projet projet)
        {
            throw new NotImplementedException();
        }

        public void SupprimerProjet(Projet projet)
        {
            throw new NotImplementedException();
        }

        public decimal? ObtenirBudgetTotalPourUnClient(string nomClient)
        {
            throw new NotImplementedException();
        }

        public decimal? ObtenirBudgetMoyenPourUnClient(string nomClient)
        {
            throw new NotImplementedException();
        }

        public ICollection<StatsClient> RechercherClientsAvecNombreProjetsEtBudgetTotalEtBudgetMoyen()
        {
            throw new NotImplementedException();

        }
        #endregion Méthodes
    }
}

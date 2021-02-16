using ProjetsORM.EntiteDTOs;
using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetsORM.AccesDonnees
{
    class EFProjetRepository
    {
        #region Propriétés

        private ProjetsORMContexte contexte;

        #endregion Propriétés

        #region Constructeur
        public EFProjetRepository (ProjetsORMContexte contexte)
        {
            this.contexte = contexte;
        }
        #endregion Constructeur

        #region Méthodes
        public void AjouterProjet(Projet projet)
        {
            contexte.Projets.Add(projet);
            contexte.SaveChanges();
        }

        public Projet ObtenirProjet(string nomProjet, string nomClient)
        {
            return contexte.Projets.Find(nomProjet, nomClient);
        }

        public void ModifierProjet(Projet projet)
        {
            contexte.Projets.Update(projet);
            contexte.SaveChanges();
        }

        public void SupprimerProjet(Projet projet)
        {
            contexte.Projets.Remove(projet);
            contexte.SaveChanges();
        }

        public decimal? ObtenirBudgetTotalPourUnClient(string nomClient)
        {
            return contexte.Clients.Find(nomClient).Projets.Where(client => client.Budget != null).Sum(client => client.Budget);
        }

        public decimal? ObtenirBudgetMoyenPourUnClient(string nomClient)
        {
            return contexte.Clients.Find(nomClient).Projets.Where(client => client.Budget != null).Average(client => client.Budget);
        }

        public ICollection<StatsClient> RechercherClientsAvecNombreProjetsEtBudgetTotalEtBudgetMoyen()
        {
            return (ICollection<StatsClient>)contexte.Projets.GroupBy(projet => projet.NomClient).Select(groupe => new
            {
                NomCLient = groupe.Key,
                NombreProjets = groupe.Count(),
                BudgetTotal = ObtenirBudgetTotalPourUnClient(groupe.Key),
                BudgetMoyen = ObtenirBudgetMoyenPourUnClient(groupe.Key)
            }).ToList();
        }
        #endregion Méthodes
    }
}

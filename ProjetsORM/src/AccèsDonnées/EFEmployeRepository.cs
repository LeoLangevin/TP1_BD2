using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetsORM.AccesDonnees
{
    class EFEmployeRepository
    {
        #region Propriétés

        private ProjetsORMContexte contexte;

        #endregion Propriétés

        #region Constructeur
        public EFEmployeRepository(ProjetsORMContexte ctx)
        {
            contexte = ctx;
        }
        #endregion Constructeur

        #region Méthodes

        public void AjouterEmploye(Employe employe)
        {
            contexte.Employes.Add(employe);
            contexte.SaveChanges();
        }

        public Employe ObtenirEmployee(short idEmploye)
        {
            Employe reponse;
            try
            {
                reponse = contexte.Employes.Where(x => x.NoEmploye == idEmploye).First();
            }
            catch (Exception)
            {
                reponse = null;
            }
            return reponse;
        }

        internal void AjouterProjet(Projet projetX)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employe> RechercherTousEmployes()
        {
            return contexte.Employes.ToList();
        }

        public ICollection<Employe> RechercherEmployesParNom(string nom, string prenom)
        {
            return contexte.Employes.Where(x => x.Nom == nom && x.Prenom == prenom).ToList();
        }

        public ICollection<Employe> RechercherTousSuperviseurs()
        {
            //return contexte.Employes.GroupBy(superviseur => superviseur.Superviseur).ToList();

            throw new NotImplementedException();
        }

        public ICollection<Employe> ObtenirEmployesSupervises(short superviseurId)
        {
            throw new NotImplementedException();
        }
        #endregion Méthodes
    }
}

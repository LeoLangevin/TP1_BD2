using ProjetsORM.Entites;
using ProjetsORM.Persistence;
using System;
using System.Collections.Generic;

namespace ProjetsORM.AccesDonnees
{
    class EFEmployeRepository
    {
        #region Propriétés
        #endregion Propriétés

        #region Constructeur
        public EFEmployeRepository(ProjetsORMContexte contexte)
        {
        }
        #endregion Constructeur

        #region Méthodes

        public void AjouterEmploye(Employe employe)
        {
            throw new NotImplementedException();
        }

        public Employe ObtenirEmployee(short idEmploye)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employe> RechercherTousEmployes()
        {
            throw new NotImplementedException();
        }

        public ICollection<Employe> RechercherEmployesParNom(string nom, string prenom)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employe> RechercherTousSuperviseurs()
        {
            throw new NotImplementedException();
        }

        public ICollection<Employe> ObtenirEmployesSupervises(short superviseurId)
        {
            throw new NotImplementedException();
        }
        #endregion Méthodes
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using AspireTestCore.Models;
using AspireTestCore.DTOs;


namespace YourNamespace.Mappers
{
    /// <summary>
    /// Mapper pour convertir entre le modèle FDT et les DTOs
    /// </summary>
    public static class FdtMapper
    {
        // ============================================================================
        // Mapper : Model → Dto (Response)
        // ============================================================================
        
        /// <summary>
        /// Convertit un modèle FDT en DTO de réponse
        /// </summary>
        public static FdtDto ToDto(this FDT model)
        {
            return new FdtDto
            {
                Employe = model.Employe,
                DatePaie = model.DatePaie,
                DateSaisie = model.DateSaisie,
                Produit = model.Produit,
                Client = model.Client,
                DetailProduit = model.DetailProduit,
                ClasseTemps = model.ClasseTemps,
                HreDebut = model.HreDebut,
                HreFin = model.HreFin,
                NbHTravail = model.NbHTravail,
                NbHFacture = model.NbHFacture,
                NoteFDT = model.NoteFDT,
                Duree = model.Duree
            };
        }

        /// <summary>
        /// Convertit une liste de modèles en liste de DTOs
        /// </summary>
        public static List<FdtDto> ToDto(this IEnumerable<FDT> models)
        {
            return models.Select(m => m.ToDto()).ToList();
        }

        // ============================================================================
        // Mapper : Model → ListDto
        // ============================================================================
        
        /// <summary>
        /// Convertit un modèle FDT en DTO simplifié pour liste
        /// </summary>
        public static FdtAffichageListDto ToAffichageListDto(this FDT model)
        {
            return new FdtAffichageListDto
            {
                Employe = model.Employe,
                DateSaisie = model.DateSaisie,
                Client = model.Client,
                Produit = model.Produit,
                DetailProduit = model.DetailProduit,
                ClasseTemps = model.ClasseTemps,
                NbHTravail = model.NbHTravail,
                NoteFDT = model.NoteFDT
            };
        }

        /// <summary>
        /// Convertit une liste de modèles en liste de DTOs simplifiés
        /// </summary>
        public static List<FdtAffichageListDto> ToListDto(this IEnumerable<FDT> models)
        {
            return models.Select(m => m.ToAffichageListDto()).ToList();
        }

        // ============================================================================
        // Mapper : Model → StatistiquesDto
        // ============================================================================
        
        /// <summary>
        /// Calcule les statistiques par employé à partir d'une liste de FDT
        /// </summary>
        public static FdtStatistiquesEmployeDto CalculerStatistiquesEmploye(
            this IEnumerable<FDT> fdts, 
            int employe, 
            string nomEmploye = "")
        {
            var fdtList = fdts.Where(f => f.Employe == employe).ToList();
            
            return new FdtStatistiquesEmployeDto
            {
                Employe = employe,
                NomEmploye = nomEmploye,
                NombreEntrees = fdtList.Count,
                TotalHeuresTravaillees = fdtList.Sum(f => f.NbHTravail),
                TotalHeuresFacturees = fdtList.Sum(f => f.NbHFacture ?? 0),
                HeuresNonFacturees = fdtList.Where(f => f.StatutFact == "0").Sum(f => f.NbHTravail),
                NombreEntreesValidees = fdtList.Count(f => f.StatutFDT != "0"),
                NombreEntreesNonValidees = fdtList.Count(f => f.StatutFDT == "0"),
                PremiereSaisie = fdtList.Any() ? fdtList.Min(f => f.DateSaisie) : DateTime.MinValue,
                DerniereSaisie = fdtList.Any() ? fdtList.Max(f => f.DateSaisie) : DateTime.MinValue
            };
        }

        /// <summary>
        /// Calcule les statistiques par client à partir d'une liste de FDT
        /// </summary>
        public static FdtStatistiquesClientDto CalculerStatistiquesClient(
            this IEnumerable<FDT> fdts, 
            string client)
        {
            var fdtList = fdts.Where(f => f.Client == client).ToList();
            
            return new FdtStatistiquesClientDto
            {
                Client = client,
                NombreEntrees = fdtList.Count,
                TotalHeuresTravaillees = fdtList.Sum(f => f.NbHTravail),
                TotalHeuresFacturees = fdtList.Sum(f => f.NbHFacture ?? 0),
                ProduitsTraites = fdtList
                    .Where(f => !string.IsNullOrEmpty(f.Produit))
                    .Select(f => f.Produit!)
                    .Distinct()
                    .ToList(),
                EmployesAffectes = fdtList
                    .Select(f => f.Employe.ToString())
                    .Distinct()
                    .ToList()
            };
        }

        /// <summary>
        /// Calcule les statistiques par produit à partir d'une liste de FDT
        /// </summary>
        public static FdtStatistiquesProduitDto CalculerStatistiquesProduit(
            this IEnumerable<FDT> fdts, 
            string produit)
        {
            var fdtList = fdts.Where(f => f.Produit == produit).ToList();
            
            return new FdtStatistiquesProduitDto
            {
                Produit = produit,
                Client = fdtList.FirstOrDefault()?.Client ?? "",
                NombreTickets = fdtList
                    .Where(f => !string.IsNullOrEmpty(f.DetailProduit))
                    .Select(f => f.DetailProduit)
                    .Distinct()
                    .Count(),
                TotalHeuresDev = fdtList.Where(f => f.ClasseTemps == "DEV").Sum(f => f.NbHTravail),
                TotalHeuresDebug = fdtList.Where(f => f.ClasseTemps == "DEBUG").Sum(f => f.NbHTravail),
                TotalHeuresSC = fdtList.Where(f => f.ClasseTemps == "SC").Sum(f => f.NbHTravail),
                TotalHeuresAutres = fdtList.Where(f => 
                    f.ClasseTemps != "DEV" && 
                    f.ClasseTemps != "DEBUG" && 
                    f.ClasseTemps != "SC")
                    .Sum(f => f.NbHTravail),
                TotalHeures = fdtList.Sum(f => f.NbHTravail)
            };
        }

    }
}

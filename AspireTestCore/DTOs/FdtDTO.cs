using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.DTOs;

// ============================================================================
// DTO pour LIRE/AFFICHER une entrée FDT (Response)
// ============================================================================

/// <summary>
/// DTO pour la lecture/affichage d'une feuille de temps
/// Contient toutes les informations incluant les champs système
/// </summary>
public class FdtDto
{
    public int Employe { get; set; }
    public DateTime DatePaie { get; set; }
    public DateTime DateSaisie { get; set; }
    public string? Produit { get; set; }
    public string Client { get; set; } = string.Empty;
    public string? DetailProduit { get; set; }
    public string ClasseTemps { get; set; } = string.Empty;
    public TimeSpan HreDebut { get; set; }
    public TimeSpan HreFin { get; set; }
    public double NbHTravail { get; set; }
    public double? NbHFacture { get; set; }
    public string? NoteFDT { get; set; }
    /// <summary>
    /// Durée calculée (HreFin - HreDebut)
    /// </summary>
    public TimeSpan Duree { get; set; }

    /// <summary>
    /// Durée formatée en heures (ex: "3.5 heures")
    /// </summary>
    public string DureeFormatee => $"{Duree.TotalHours:F2} heures";
}

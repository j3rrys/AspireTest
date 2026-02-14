using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.DTOs;
// ============================================================================
// DTO SIMPLIFIÉ pour les listes
// ============================================================================

/// <summary>
/// DTO simplifié pour l'affichage dans une liste
/// Contient uniquement les informations essentielles
/// </summary>
public class FdtAffichageListDto
{
    public int Employe { get; set; }
    public DateTime DateSaisie { get; set; }
    public string Client { get; set; } = string.Empty;
    public string? Produit { get; set; }
    public string? DetailProduit { get; set; }
    public string ClasseTemps { get; set; } = string.Empty;
    public double NbHTravail { get; set; }
    public string? NoteFDT { get; set; }

    /// <summary>
    /// Libellé de la classe de temps
    /// </summary>
    public string ClasseTempsLibelle => ClasseTemps switch
    {
        "DEV" => "Développement",
        "DEBUG" => "Débogage",
        "SC" => "Support Client",
        "RECH" => "Recherche",
        "REQ" => "Réunion",
        "XCF" => "Congé férié",
        _ => ClasseTemps
    };
}

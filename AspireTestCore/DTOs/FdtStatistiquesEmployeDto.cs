using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.DTOs;

// ============================================================================
// DTO pour les STATISTIQUES/RAPPORTS
// ============================================================================

/// <summary>
/// DTO pour les statistiques par employé
/// </summary>
public class FdtStatistiquesEmployeDto
{
    public int Employe { get; set; }
    public string NomEmploye { get; set; } = string.Empty;
    public int NombreEntrees { get; set; }
    public double TotalHeuresTravaillees { get; set; }
    public double TotalHeuresFacturees { get; set; }
    public double HeuresNonFacturees { get; set; }
    public int NombreEntreesValidees { get; set; }
    public int NombreEntreesNonValidees { get; set; }
    public DateTime PremiereSaisie { get; set; }
    public DateTime DerniereSaisie { get; set; }
}


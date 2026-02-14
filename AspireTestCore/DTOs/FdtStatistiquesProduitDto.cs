using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.DTOs;

/// <summary>
/// DTO pour les statistiques par produit
/// </summary>
public class FdtStatistiquesProduitDto
{
    public string Produit { get; set; } = string.Empty;
    public string Client { get; set; } = string.Empty;
    public int NombreTickets { get; set; }
    public double TotalHeuresDev { get; set; }
    public double TotalHeuresDebug { get; set; }
    public double TotalHeuresSC { get; set; }
    public double TotalHeuresAutres { get; set; }
    public double TotalHeures { get; set; }
}
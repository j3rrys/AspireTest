using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.DTOs;

/// <summary>
/// DTO pour les statistiques par client
/// </summary>
public class FdtStatistiquesClientDto
{
    public string Client { get; set; } = string.Empty;
    public int NombreEntrees { get; set; }
    public double TotalHeuresTravaillees { get; set; }
    public double TotalHeuresFacturees { get; set; }
    public List<string> ProduitsTraites { get; set; } = new();
    public List<string> EmployesAffectes { get; set; } = new();
}


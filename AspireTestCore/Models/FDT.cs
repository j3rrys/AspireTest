using System;

namespace AspireTestCore.Models;

/// <summary>
/// Modèle représentant une entrée de feuille de temps (FDT)
/// </summary>
public class FDT
{
    /// <summary>
    /// Identifiant de l'employé
    /// </summary>
    public int Employe { get; set; }

    /// <summary>
    /// Date de paie
    /// </summary>
    public DateTime DatePaie { get; set; }

    /// <summary>
    /// Date de saisie
    /// </summary>
    public DateTime DateSaisie { get; set; }

    /// <summary>
    /// Nom du produit (peut être vide)
    /// </summary>
    public string? Produit { get; set; }

    /// <summary>
    /// Nom du client
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// Détail du produit / Numéro de ticket (peut être vide)
    /// </summary>
    public string? DetailProduit { get; set; }

    /// <summary>
    /// Classe de temps (DEV, DEBUG, SC, RECH, REQ, XCF, etc.)
    /// </summary>
    public string ClasseTemps { get; set; } = string.Empty;

    /// <summary>
    /// Heure de début
    /// </summary>
    public TimeSpan HreDebut { get; set; }

    /// <summary>
    /// Heure de fin
    /// </summary>
    public TimeSpan HreFin { get; set; }

    /// <summary>
    /// Nombre d'heures de travail
    /// </summary>
    public double NbHTravail { get; set; }

    /// <summary>
    /// Nombre d'heures facturées (nullable)
    /// </summary>
    public double? NbHFacture { get; set; }

    /// <summary>
    /// Statut de la feuille de temps (0 = non validé, etc.)
    /// </summary>
    public string StatutFDT { get; set; } = "0";

    /// <summary>
    /// Statut de facturation (0 = non facturé, etc.)
    /// </summary>
    public string StatutFact { get; set; } = "0";

    /// <summary>
    /// Nom de l'usager ayant saisi/modifié l'entrée
    /// </summary>
    public string NomUsager { get; set; } = string.Empty;

    /// <summary>
    /// Date et heure de la dernière mise à jour
    /// </summary>
    public DateTime DateHreMaj { get; set; }

    /// <summary>
    /// Note/commentaire sur la feuille de temps
    /// </summary>
    public string? NoteFDT { get; set; }

    /// <summary>
    /// Numéro de référence d'événement (nullable)
    /// </summary>
    public int? NoRefEvent { get; set; }

    /// <summary>
    /// Propriété calculée : durée totale de l'activité
    /// </summary>
    public TimeSpan Duree => HreFin - HreDebut;

    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public FDT() { }
}

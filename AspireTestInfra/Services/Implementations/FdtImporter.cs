using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspireTestCore.Models;
using ClosedXML.Excel;

namespace AspireTestInfra.Services.Implementations;

/// <summary>
/// Helper pour importer les données de feuille de temps depuis Excel
/// </summary>
public class FdtImporter
{
    public FdtImporter()
    {
    }

    /// <summary>
    /// Importe les données d'une feuille de temps depuis un fichier Excel
    /// </summary>
    /// <param name="filePath">Chemin du fichier Excel</param>
    /// <returns>Liste des entrées de feuille de temps</returns>
    public static List<FDT> ImportFromExcel(string filePath)
    {
        var fdtList = new List<FDT>();

        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1); // Première feuille
            var rows = worksheet.RowsUsed().Skip(1); // Ignorer l'en-tête

            foreach (var row in rows)
            {
                try
                {
                    var fdt = new FDT
                    {
                        Employe = row.Cell(1).GetValue<int>(),
                        DatePaie = row.Cell(2).GetDateTime(),
                        DateSaisie = row.Cell(3).GetDateTime(),
                        Produit = row.Cell(4).GetString(),
                        Client = row.Cell(5).GetString(),
                        DetailProduit = row.Cell(6).GetString(),
                        ClasseTemps = row.Cell(7).GetString(),
                        HreDebut = row.Cell(8).GetTimeSpan(),
                        HreFin = row.Cell(9).GetTimeSpan(),
                        NbHTravail = row.Cell(10).GetValue<double>(),
                        NbHFacture = row.Cell(11).IsEmpty() ? null : row.Cell(11).GetValue<double?>(),
                        StatutFDT = row.Cell(12).GetString(),
                        StatutFact = row.Cell(13).GetString(),
                        NomUsager = row.Cell(14).GetString(),
                        DateHreMaj = row.Cell(15).GetDateTime(),
                        NoteFDT = row.Cell(16).GetString(),
                        NoRefEvent = row.Cell(17).IsEmpty() ? null : row.Cell(17).GetValue<int?>()
                    };

                    fdtList.Add(fdt);
                }
                catch (Exception ex)
                {
                    // Log l'erreur et continuer avec la ligne suivante
                    Console.WriteLine($"Erreur lors de l'import de la ligne {row.RowNumber()}: {ex.Message}");
                }
            }
        }

        return fdtList;
    }

    /// <summary>
    /// Exporte une liste de FDT vers un fichier Excel
    /// </summary>
    /// <param name="fdtList">Liste des entrées à exporter</param>
    /// <param name="filePath">Chemin du fichier de destination</param>
    public static void ExportToExcel(List<FDT> fdtList, string filePath)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("fdt07");

            // En-têtes
            worksheet.Cell(1, 1).Value = "Employe";
            worksheet.Cell(1, 2).Value = "DatePaie";
            worksheet.Cell(1, 3).Value = "DateSaisie";
            worksheet.Cell(1, 4).Value = "Produit";
            worksheet.Cell(1, 5).Value = "Client";
            worksheet.Cell(1, 6).Value = "DetailProduit";
            worksheet.Cell(1, 7).Value = "ClasseTemps";
            worksheet.Cell(1, 8).Value = "HreDebut";
            worksheet.Cell(1, 9).Value = "HreFin";
            worksheet.Cell(1, 10).Value = "NbHTravail";
            worksheet.Cell(1, 11).Value = "NbHFacture";
            worksheet.Cell(1, 12).Value = "StatutFDT";
            worksheet.Cell(1, 13).Value = "StatutFact";
            worksheet.Cell(1, 14).Value = "NomUsager";
            worksheet.Cell(1, 15).Value = "DateHreMaj";
            worksheet.Cell(1, 16).Value = "NoteFDT";
            worksheet.Cell(1, 17).Value = "NoRefEvent";

            // Données
            for (int i = 0; i < fdtList.Count; i++)
            {
                var fdt = fdtList[i];
                int rowNum = i + 2;

                worksheet.Cell(rowNum, 1).Value = fdt.Employe;
                worksheet.Cell(rowNum, 2).Value = fdt.DatePaie;
                worksheet.Cell(rowNum, 3).Value = fdt.DateSaisie;
                worksheet.Cell(rowNum, 4).Value = fdt.Produit;
                worksheet.Cell(rowNum, 5).Value = fdt.Client;
                worksheet.Cell(rowNum, 6).Value = fdt.DetailProduit;
                worksheet.Cell(rowNum, 7).Value = fdt.ClasseTemps;
                worksheet.Cell(rowNum, 8).Value = fdt.HreDebut;
                worksheet.Cell(rowNum, 9).Value = fdt.HreFin;
                worksheet.Cell(rowNum, 10).Value = fdt.NbHTravail;
                worksheet.Cell(rowNum, 11).Value = fdt.NbHFacture;
                worksheet.Cell(rowNum, 12).Value = fdt.StatutFDT;
                worksheet.Cell(rowNum, 13).Value = fdt.StatutFact;
                worksheet.Cell(rowNum, 14).Value = fdt.NomUsager;
                worksheet.Cell(rowNum, 15).Value = fdt.DateHreMaj;
                worksheet.Cell(rowNum, 16).Value = fdt.NoteFDT;
                worksheet.Cell(rowNum, 17).Value = fdt.NoRefEvent;
            }

            // Formatage
            worksheet.Column(2).Style.NumberFormat.Format = "yyyy-MM-dd";
            worksheet.Column(3).Style.NumberFormat.Format = "yyyy-MM-dd";
            worksheet.Column(8).Style.NumberFormat.Format = "hh:mm";
            worksheet.Column(9).Style.NumberFormat.Format = "hh:mm";
            worksheet.Column(15).Style.NumberFormat.Format = "yyyy-MM-dd hh:mm:ss";

            // Auto-ajuster les colonnes
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }
    }
}

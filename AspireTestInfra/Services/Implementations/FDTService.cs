using AspireTestCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AspireTestCore.DTOs;
using YourNamespace.Mappers;
using AspireTestCore.Interfaces;

namespace AspireTestInfra.Services.Implementations;

public class FDTService : IFDTService
{
    private List<FDT> _fdtData;
    public FDTService(string? excelPath)
    {
        if (excelPath == null)
        {
            throw new ArgumentNullException(nameof(excelPath), "Le chemin du fichier Excel ne peut pas être null.");
        }
        _fdtData = FdtImporter.ImportFromExcel(excelPath);
    }
    public Task<List<FdtDto>> GetAllFDTAsync()
    {
        return Task.FromResult(_fdtData.ToDto());
    }

    public Task<List<FdtDto>> GetEmployeFDtAsync(int IdEmploye)
    {
        _fdtData = _fdtData.Where(f => f.Employe == IdEmploye).ToList();
        return Task.FromResult(_fdtData.ToDto());
    }

    public Task<FdtStatistiquesEmployeDto> GetStatistiquesEmployeDtosAsync(int idEmploye)
    {
        return Task.FromResult(_fdtData.CalculerStatistiquesEmploye(idEmploye));
    }
}

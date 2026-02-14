using AspireTestCore.Models;
using AspireTestInfra.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    public Task<List<FDT>> GetAllFDTAsync()
    {
        return Task.FromResult(_fdtData);
    }

    public Task<List<FDT>> GetEmployeFDtAsync(int IdEmploye)
    {
        _fdtData = _fdtData.Where(f => f.Employe == IdEmploye).ToList();
        return Task.FromResult(_fdtData);
    }
}

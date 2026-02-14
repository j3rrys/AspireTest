using AspireTestCore.Models;
using AspireTestInfra.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestInfra.Services.Implementations;

internal class FDTService : IFDTService
{
    private List<FDT> _fdtData;
    public FDTService(string excelPath)
    {
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

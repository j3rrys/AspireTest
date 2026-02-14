using AspireTestCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestInfra.Services.Interfaces;

public interface IFDTService
{
    /// <summary>
    /// Get the FDT (Feuille de Temps) for a specific employee based on their ID. 
    /// This method retrieves the time sheet details for the given employee, including work hours, project information, and other relevant data.
    /// </summary>
    /// <param name="IdEmploye"></param>
    /// <returns>FDT</returns>
    Task<List<FDT>> GetEmployeFDtAsync(int IdEmploye);
    /// <summary>
    /// Get all FDT (Feuille de Temps) records. 
    /// This method retrieves a list of all time sheets, which may include details for multiple employees, projects, and time periods. 
    /// It provides an overview of the time sheet data available in the system.
    /// </summary>
    /// <returns>List<FDT></returns>
    Task<List<FDT>> GetAllFDTAsync();

}

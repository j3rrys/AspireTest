using AspireTestCore.Models;
using AspireTestCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspireTestCore.Interfaces;

public interface IFDTService
{
    /// <summary>
    /// Get the FDT (Feuille de Temps) for a specific employee based on their ID. 
    /// This method retrieves the time sheet details for the given employee, including work hours, project information, and other relevant data.
    /// </summary>
    /// <param name="IdEmploye"></param>
    /// <returns>FDT</returns>
    Task<List<FdtDto>> GetEmployeFDtAsync(int IdEmploye);
    /// <summary>
    /// Get all FDT (Feuille de Temps) records. 
    /// This method retrieves a list of all time sheets, which may include details for multiple employees, projects, and time periods. 
    /// It provides an overview of the time sheet data available in the system.
    /// </summary>
    /// <returns>List<FDT></returns>
    Task<List<FdtDto>> GetAllFDTAsync();
    /// <summary>
    /// Get statistics for a specific employee based on their ID.
    /// </summary>
    /// <param name="idEmploye"></param>
    /// <returns>FdtStatistiquesEmployeDto</returns>
    Task<FdtStatistiquesEmployeDto> GetStatistiquesEmployeDtosAsync(int idEmploye);

}

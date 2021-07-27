using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using TSS.Interfaces.Services;
using TSS.Models;

namespace TSS.Services.Interfaces
{
    public interface IEmployeeRegisterTSSService : IService<RegistroEmpleadoTss>
    {
        byte[] GetXmlFromList(List<RegistroEmpleadoTss> list);
        List<RegistroEmpleadoTss> GetListFromXml(IFormFile file);
        List<RegistroEmpleadoTss> GetListFromDFDL(IFormFile file);
        Task<List<ImportResult>> SaveEmployeesAsync(List<RegistroEmpleadoTss> list);
        Task<bool> EmployeeExistsAsync(string employeeName);
    }
}

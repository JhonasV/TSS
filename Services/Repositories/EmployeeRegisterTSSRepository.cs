using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TSS.Models;
using TSS.Services.Interfaces;

namespace TSS.Services.Repositories
{
    public class EmployeeRegisterTSSRepository : IEmployeeRegisterTSSService
    {
        private readonly ApplicationContext _context;

        public EmployeeRegisterTSSRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<RegistroEmpleadoTss>> GetAllAsync() => await _context.RegistroEmpleadoTsses.ToListAsync();
        public async Task<RegistroEmpleadoTss> GetAsync(int id) => await _context.RegistroEmpleadoTsses.FindAsync(id);

        public async Task SaveAsync(RegistroEmpleadoTss entity)
        {
            await _context.RegistroEmpleadoTsses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public  List<RegistroEmpleadoTss> GetListFromXml(IFormFile file)
        {
        
            XDocument xDocument = new XDocument();
            using (var fileStream = file.OpenReadStream())
            {
                TextReader streamReader = new StreamReader(fileStream);
                xDocument = XDocument.Load(fileStream);
            }

            var employees = xDocument.Descendants("Employee").Select(employee => new RegistroEmpleadoTss
            {
                Id = int.Parse(employee.Element("Id").Value),
                NombreEmpleado = employee.Element("NombreEmpleado").Value,
                CedulaEmpleado = employee.Element("CedulaEmpleado").Value,
                TipoEmpleador = employee.Element("TipoEmpleador").Value,
                RazonSocial = employee.Element("RazonSocial").Value,
                Rnc = employee.Element("Rnc").Value,
                NombreComercial = employee.Element("NombreComercial").Value,
                ActividadComercial = employee.Element("ActividadComercial").Value,
                Calle = employee.Element("Calle").Value,
                No = employee.Element("No").Value,
                Sector = employee.Element("Sector").Value,
                Municipio = employee.Element("Municipio").Value,
                Provincia = employee.Element("Provincia").Value,
                ReferenciaDireccion = employee.Element("ReferenciaDireccion").Value,
                TelefonoEmpresa = employee.Element("TelefonoEmpresa").Value,
                EmailEmpresa = employee.Element("EmailEmpresa").Value
            }).ToList();


            return employees;
        }

        public byte[] GetXmlFromList(List<RegistroEmpleadoTss> list)
        {

            XElement xmlElements =  new XElement("Employees", list.Select(item =>
            new XElement("Employee",
                         new XElement(nameof(item.Id), item.Id),
                         new XElement(nameof(item.NombreEmpleado), item.NombreEmpleado),
                         new XElement(nameof(item.CedulaEmpleado), item.CedulaEmpleado),
                         new XElement(nameof(item.TipoEmpleador), item.TipoEmpleador),
                         new XElement(nameof(item.RazonSocial), item.RazonSocial),
                         new XElement(nameof(item.Rnc), item.Rnc),
                         new XElement(nameof(item.NombreComercial), item.NombreComercial),
                         new XElement(nameof(item.ActividadComercial), item.ActividadComercial),
                         new XElement(nameof(item.Calle), item.Calle),
                         new XElement(nameof(item.No), item.No),
                         new XElement(nameof(item.Sector), item.Sector),
                         new XElement(nameof(item.Municipio), item.Municipio),
                         new XElement(nameof(item.Provincia), item.Provincia),
                         new XElement(nameof(item.ReferenciaDireccion), item.ReferenciaDireccion),
                         new XElement(nameof(item.TelefonoEmpresa), item.TelefonoEmpresa),
                         new XElement(nameof(item.EmailEmpresa), item.EmailEmpresa)
                    ))
                );
            var document = new XDocument(xmlElements);
            var result = string.Empty;
            using (StringWriter writer = new StringWriter())
            {
                document.Save(writer);
                result = writer.ToString();
                result = result.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
            }

            return Encoding.UTF8.GetBytes(result);
        }

        public async Task<List<ImportResult>> SaveEmployeesAsync(List<RegistroEmpleadoTss> list)
        {
            var results = new List<ImportResult>();

            foreach(var employee in list)
            {
                var importResult = new ImportResult();
                try
                {
                    if (await EmployeeExistsAsync(employee.NombreEmpleado))
                    {
                        importResult.Name = employee.NombreEmpleado;
                        importResult.Message = "Ya existe este registro";
                        importResult.Success = false;
                    }
                    else
                    {
                        employee.Id = 0;
                        await this.SaveAsync(employee);
                        importResult.Name = employee.NombreEmpleado;
                        importResult.Message = "Agregado de forma exitosa";
                    }                        
                }
                catch (Exception e)
                {
                    importResult.Success = false;
                    importResult.Message = e.InnerException.Message;
                }
                results.Add(importResult);
            }

            return results;
        }

        public async Task<bool> EmployeeExistsAsync(string employeeName) => await _context.RegistroEmpleadoTsses.Where(e => e.NombreEmpleado.ToLower() == employeeName.ToLower()).AnyAsync();

    }
}

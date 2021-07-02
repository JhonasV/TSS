import React from 'react'
import useEmployees from '../../hooks/Employees';

const EmployeeTable = ({employees, loadingEmployees}) => {

    const renderTbody = () => {

        return employees.map((item) => (
             <tr key={item.id}>
                <td>{item.nombreEmpleado}</td>
                <td>{item.cedulaEmpleado}</td>
                <td>{item.tipoEmpleador}</td>
                <td>{item.razonSocial}</td>
                <td>{item.rnc}</td>
                <td>{item.nombreComercial}</td>
                <td>{item.actividadComercial}</td>
            </tr>
        ))

    }

    return (
    <table className='table table-hover'>
        <thead>
            <tr>
                <th>Nombre Empleado</th>
                <th>Cedula Empleado</th>
                <th>Tipo Empleador</th>
                <th>Razón Social</th>
                <th>RNC</th>
                <th>Nombre Comercial</th>
                <th>Actividad Comercial</th>
            </tr>
        </thead>
        <tbody>
            {loadingEmployees ? "Cargando Listado" : renderTbody()}
        </tbody>
    </table>
    )
}
export default EmployeeTable;
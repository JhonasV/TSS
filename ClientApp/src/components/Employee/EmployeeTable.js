import React from "react";
import { AgGridReact, AgGridColumn } from "ag-grid-react";
import { Table } from "react-bootstrap";

const EmployeeTable = ({ employees }) => {
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
    ));
  };

  return (
    <div className="ag-theme-alpine" style={{ height: 700, width: "100%" }}>
      <AgGridReact rowData={employees}>
        <AgGridColumn field="nombreEmpleado"></AgGridColumn>
        <AgGridColumn field="cedulaEmpleado"></AgGridColumn>
        <AgGridColumn field="tipoEmpleador"></AgGridColumn>
        <AgGridColumn field="razonSocial"></AgGridColumn>
        <AgGridColumn field="rnc"></AgGridColumn>
        <AgGridColumn field="nombreComercial"></AgGridColumn>
        <AgGridColumn field="actividadComercial"></AgGridColumn>
      </AgGridReact>
    </div>
  );
};
export default EmployeeTable;

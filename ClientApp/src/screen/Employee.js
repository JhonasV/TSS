import React, { useState } from "react";
import EmployeeTable from "../components/Employee/EmployeeTable";
import useEmployees from "../hooks/Employees";
import Modal from "../components/Modal";
import ResultTable from "../components/ResultTable";

const baseUrl = "/api/v1/EmployeeRegisterTSS";
function Employee() {
  const { loadingEmployees, employees, fetchEmployees } = useEmployees();
  const [showModal, setShowModal] = useState(false);
  const [importing, setImporting] = useState(false);
  const [importResult, setImportResult] = useState([]);

  const handleImportFile = (file = null) => {
    var formdata = new FormData();
    console.log(file);
    if (file === null) {
      alert("Debe de seleccionar un archivo!");
      return;
    }

    setImporting(true);
    formdata.append("file", file);

    const config = {
      method: "POST",
      headers: { accept: "application/json" },
      body: formdata,
    };

    fetch(`${baseUrl}/import`, config)
      .then((res) => res.json())
      .then((res) => {
        setImportResult(res);
        fetchEmployees();
        setShowModal(!showModal);
      })
      .catch((err) => console.error(err))
      .finally(() => {
        setImporting(false);
      });
  };

  const handlerExportFile = () => {
    setImporting(true);

    fetch(`${baseUrl}/export`)
      .then((res) => res.blob())
      .then((res) => {
        processFile(res);
      })
      .catch((err) => console.error(err))
      .finally(() => setImporting(false));
  };

  const processFile = (fileBlob) => {
    const url = window.URL.createObjectURL(new Blob([fileBlob]));
    const link = document.createElement("a");
    link.href = url;
    link.setAttribute("download", `employees.xml`);
    document.body.appendChild(link);
    link.click();
    link.parentNode.removeChild(link);
  };

  return (
    <div>
      <div className="d-flex mb-3 form-group">
        <button
          className="btn btn-secondary mr-2"
          onClick={(e) => handlerExportFile()}
        >
          Export
        </button>
        {/* <label htmlFor='upload'>
             
                    <input disabled={importing} className='btn btn-primary' value='Import' />  
                </label> */}

        <input
          disabled={importing}
          id="upload"
          type="file"
          onChange={(e) => handleImportFile(e.target.files[0])}
        />
      </div>
      <div>
        <EmployeeTable
          employees={employees}
          loadingEmployees={loadingEmployees}
        />
      </div>
      <Modal
        animation={true}
        show={showModal}
        onHide={() => setShowModal(false)}
      >
        <ResultTable importResult={importResult} />
      </Modal>
    </div>
  );
}

export default Employee;

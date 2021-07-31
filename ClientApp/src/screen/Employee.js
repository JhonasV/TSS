import React, { Suspense, useState } from "react";
// import EmployeeTable from "../components/Employee/EmployeeTable";
import useEmployees from "../hooks/Employees";
import Modal from "../components/Modal";
import ResultTable from "../components/ResultTable";
import { processFile } from "../utils/files";
const EmployeeTable = React.lazy(() =>
  import("../components/Employee/EmployeeTable")
); // Ca
const baseUrl = "/api/v1/EmployeeRegisterTSS";
function Employee() {
  const { employees, fetchEmployees } = useEmployees();
  const [showModal, setShowModal] = useState(false);
  const [importing, setImporting] = useState(false);
  const [importResult, setImportResult] = useState([]);
  const [file, setFile] = useState([]);

  const handleImportFileLayout = () => {
    var formdata = new FormData();

    setImporting(true);
    formdata.append("file", file);

    const config = {
      method: "POST",
      headers: { accept: "application/json" },
      body: formdata,
    };

    fetch(`${baseUrl}/import/dfdl`, config)
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

  return (
    <div>
      <div className="d-flex mb-3 form-group">
        {/* <button
          className="btn btn-secondary mr-2"
          onClick={(e) => handlerExportFile()}
        >
          Export
        </button> */}

        <input
          disabled={importing}
          id="upload layout"
          type="file"
          onChange={(e) => setFile(e.target.files[0])}
        />
        <button
          className="btn btn-secondary mr-2"
          onClick={(e) => handleImportFileLayout()}
        >
          Guardar
        </button>
      </div>
      <Suspense fallback={<h3>Cargando empleados...</h3>}>
        <EmployeeTable employees={employees} />
      </Suspense>
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

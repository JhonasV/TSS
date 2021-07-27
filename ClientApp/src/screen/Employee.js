import React, { useState } from "react";
import EmployeeTable from "../components/Employee/EmployeeTable";
import useEmployees from "../hooks/Employees";
import Modal from "../components/Modal";
import ResultTable from "../components/ResultTable";
import { processFile } from "../utils/files";

const baseUrl = "/api/v1/EmployeeRegisterTSS";
function Employee() {
  const { loadingEmployees, employees, fetchEmployees } = useEmployees();
  const [showModal, setShowModal] = useState(false);
  const [importing, setImporting] = useState(false);
  const [importResult, setImportResult] = useState([]);

  const handleImportFile = (file = null) => {
    var formdata = new FormData();

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

  const handleImportFileLayout = (file = null) => {
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
        <button
          className="btn btn-secondary mr-2"
          onClick={(e) => handlerExportFile()}
        >
          Export
        </button>
        <input
          disabled={importing}
          id="upload"
          type="file"
          onChange={(e) => handleImportFile(e.target.files[0])}
        />

        <input
          disabled={importing}
          id="upload layout"
          type="file"
          onChange={(e) => handleImportFileLayout(e.target.files[0])}
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

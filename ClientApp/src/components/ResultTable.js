import React from "react";
import { Table } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faExclamationCircle,
  faCheckCircle,
} from "@fortawesome/free-solid-svg-icons";
const ResultTable = ({ importResult = [] }) => {
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th></th>
          <th>Nombre</th>
          <th>Mensaje</th>
        </tr>
      </thead>
      <tbody>
        {importResult.map((result, i) => (
          <tr
            style={{ backgroundColor: result.success ? "#7bed9f" : "#ff7f50" }}
            key={i}
          >
            <td>
              <FontAwesomeIcon
                color={result.success ? "#2ed573" : "red"}
                icon={result.success ? faCheckCircle : faExclamationCircle}
              />
            </td>
            <td className="text-color-white">{result.name}</td>
            <td className="text-color-white">{result.message}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default ResultTable;

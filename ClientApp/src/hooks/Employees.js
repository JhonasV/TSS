import React, { useState, useEffect } from "react";

const useEmployees = () => {
  const [employees, setEmployees] = useState([]);
  const fetchEmployees = () => {
    fetch("/api/v1/EmployeeRegisterTSS/list")
      .then((res) => res.json())
      .then((res) => {
        setEmployees(res);
      })
      .catch((err) => alert("Error obteniendo el listado de empleados"));
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  return { employees, fetchEmployees };
};

export default useEmployees;

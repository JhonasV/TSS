import React, {useState, useEffect} from 'react'

const useEmployees = () => {
    const [employees, setEmployees] = useState([]);
    const [loadingEmployees, setLoading] = useState(false);

    const fetchEmployees = () => {
        setLoading(true);
        fetch("/api/v1/EmployeeRegisterTSS/list").then((res) => res.json())
        .then((res) => {
            setEmployees(res);
            
        })
        .catch((err) => alert("Error obteniendo el listado de empleados"))
        .finally(() => setLoading(false));
    }

    useEffect(() => {
        fetchEmployees();
    }, [])

    return {loadingEmployees, employees, fetchEmployees}
}

export default useEmployees

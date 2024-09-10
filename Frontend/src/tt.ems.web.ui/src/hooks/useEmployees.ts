import { useEffect, useState } from "react"
import axios, { AxiosError } from 'axios'
import { IEmployee } from "../types/EmployeeModel"

export function useEmployees() {
    const [employees, setEmployees] = useState<IEmployee[]>([])
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState('')
    
    async function fetchEmployees() {
        try {
            setError('')
            setLoading(true)
            const response = await axios.get<IEmployee[]>('http://localhost:5054/employees')
            setEmployees(response.data)
            setLoading(false)
        }
        catch (e) {
            const error = e as AxiosError
            setLoading(false)
            setError(error.message)
        }
    }

    useEffect(() => {
        fetchEmployees();
        }, [])

    return { employees, loading, error, refreshEmployees: fetchEmployees }
}

import { useState } from "react"
import axios, { AxiosError } from 'axios'
import { IEmployee } from "../types/EmployeeModel"
import { Sex } from "../types/Sex"

interface UseUpsertEmployeeProps {
    employee?: IEmployee
    onCreate: () => void
}

export function useUpsertEmployee({ employee, onCreate }: UseUpsertEmployeeProps) {
    const [firstName, setFirstName] = useState(employee?.firstName || '')
    const [lastName, setLastName] = useState(employee?.lastName || '')
    const [age, setAge] = useState(employee?.age || 18)
    const [sex, setSex] = useState(employee?.sex || Sex.Male.toString())
    const [error, setError] = useState('')

    const submitHandler = async (e: React.FormEvent) => {
        e.preventDefault()
        try {
            setError('')
            if (employee?.id) {
                await axios.put(`http://localhost:5054/employees/${employee.id}`, { firstName, lastName, age, sex })
            } else {
                await axios.post('http://localhost:5054/employees', { firstName, lastName, age, sex })
            }
            onCreate()
        } catch (e) {
            const error = e as AxiosError
            setError((error.response?.data as { message: string })?.message || error.message)
        }
    }

    return {
        firstName,
        setFirstName,
        lastName,
        setLastName,
        age,
        setAge,
        sex,
        setSex,
        error,
        submitHandler,
    }
}
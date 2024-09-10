import { useState } from "react"
import axios, { AxiosError } from 'axios'

interface UseDeleteEmployeeProps {
    ids: string[]
    onDelete: () => void
}

export function useDeleteEmployee({ ids, onDelete }: UseDeleteEmployeeProps) {
    const [error, setError] = useState('')

    const submitHandler = async (e: React.FormEvent) => {
        e.preventDefault()
        try {
            setError('')
            await axios.delete('http://localhost:5054/employees', { data: ids })
            onDelete()
        } catch (e) {
            const error = e as AxiosError
            setError((error.response?.data as { message: string })?.message || error.message)
        }
    }

    return {
        error,
        submitHandler
    }
}

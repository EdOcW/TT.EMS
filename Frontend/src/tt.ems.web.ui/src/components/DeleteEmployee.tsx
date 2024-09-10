import { ErrorMessage } from "./ErrorMessage"
import { useDeleteEmployee } from "../hooks/useDeleteEmployee"

interface IDeleteEmployeeProps {
    ids: string[]
    onDelete: () => void
}

export function DeleteEmployee({ ids, onDelete }: IDeleteEmployeeProps) {
    const { error, submitHandler } = useDeleteEmployee({ ids, onDelete });
    return (
        <form onSubmit={submitHandler} className="space-y-4">
            <label className="block text-lg font-semibold">
                Are you sure you want to delete?
            </label>
            {error && <ErrorMessage message={error} />}
            <div className="flex space-x-4">
                <button 
                    type="submit" 
                    className="py-2 px-4 border bg-red-400 text-white hover:bg-red-500 focus:outline-none focus:ring-2 focus:ring-red-500 rounded"
                >
                    Delete
                </button>
                <button 
                    type="button" 
                    onClick={onDelete}
                    className="py-2 px-4 border bg-gray-300 text-black hover:bg-gray-400 focus:outline-none focus:ring-2 focus:ring-gray-300 rounded"
                >
                    Cancel
                </button>
            </div>
        </form>
    )
}
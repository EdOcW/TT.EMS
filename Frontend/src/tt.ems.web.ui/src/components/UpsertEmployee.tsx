import { ErrorMessage } from "./ErrorMessage"
import { Sex } from "../types/Sex"
import { IEmployee } from "../types/EmployeeModel"
import { useUpsertEmployee } from "../hooks/useUpsertEmployee"

interface UpsertEmployeeProps {
    employee?: IEmployee
    onCreate: () => void
}

export function UpsertEmployee({ employee, onCreate }: UpsertEmployeeProps) {
    const {
        firstName,
        setFirstName,
        lastName,
        setLastName,
        age,
        setAge,
        sex,
        setSex,
        error,
        submitHandler
    } = useUpsertEmployee({ employee, onCreate })

    return (
        <form onSubmit={ submitHandler }>
            <label>First Name:</label>
            <input
                type="text"
                placeholder="First Name"
                className="border py-2 px-4 mb-2 w-full outline-0"
                value={firstName}
                onChange={e => setFirstName(e.target.value)}
            />
            <label>Last Name:</label>
            <input
                type="text"
                placeholder="Last Name"
                className="border py-2 px-4 mb-2 w-full outline-0"
                value={lastName}
                onChange={e => setLastName(e.target.value)}
            />
            <label>Age:</label>
            <input
                type="number"
                placeholder="Age"
                className="border py-2 px-4 mb-2 w-full outline-0"
                value={age}
                onChange={e => setAge(+e.target.value)}
            />
            <label>Sex:</label>
            <select
                name="Sex"
                className="border py-2 px-4 mb-2 w-full outline-0"
                value={sex}
                onChange={e => setSex(e.target.value)}
            >
                {Object.values(Sex).map(sex => (
                        <option key={sex} value={sex}>
                            {sex}
                        </option>
                    ))}
            </select>
            { error && <ErrorMessage message={error}/> }
            <button type="submit" className="py-2 px-4 border bg-blue-400 hover:text-white">
                { employee?.id ? "Edit": "Create" }
            </button>
            <button type="button" onClick={onCreate} className="py-2 px-4 border bg-red-400 hover:text-white">
                Cancel
            </button>
        </form>
    )
}
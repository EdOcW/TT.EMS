import { IEmployee } from "../types/EmployeeModel";

interface EmployeeProps {
  employee: IEmployee
  isSelected: boolean
  onSelectChange: (id: string, isSelected: boolean) => void
  index: number
}

export function Employee({ employee, isSelected, onSelectChange, index }: EmployeeProps) {
  const handleCheckboxChange = () => {
    onSelectChange(employee.id!, !isSelected);
  };

  const backgroundColor = index % 2 === 0 ? 'bg-gray-100' : 'bg-white'

  return (
    <div className={ `border py-2 px-4 rounded flex flex-col items-center mb-2 ${backgroundColor}` }>
      <div className="flex justify-between w-full">
        <input
            type="checkbox"
            checked={isSelected}
            onChange={handleCheckboxChange}
          />
        <p>{ employee.firstName } { employee.lastName }</p>
        <p>{ employee.age } years</p>
        <p>{ employee.sex }</p>
        </div>
      </div>
  )
}
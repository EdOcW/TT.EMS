import { useContext, useState } from "react"
import { UpsertEmployee } from "../components/UpsertEmployee"
import { Employee } from "../components/Employee"
import { ErrorMessage } from "../components/ErrorMessage"
import { Loader } from "../components/Loader"
import { Modal } from "../components/Modal"
import { ModalContext } from "../context/ModalContext"
import { useEmployees } from "../hooks/useEmployees"
import { DeleteEmployee } from "../components/DeleteEmployee"
import { ActionButton } from "../components/ActionButton"
import { ModalType } from "../types/ModalType"

export function EmployeesPage() {
    const { employees, loading, error, refreshEmployees } = useEmployees()
    const { showModal,  openModal, closeModal } = useContext(ModalContext)
    const [ modalType, setModalType ] = useState<ModalType | null>(null)
    const [selectedEmployees, setSelectedEmployees] = useState<{ [key: string]: boolean }>({})
    const [errorMessage, setErrorMessage] = useState<string>("")

    const employeesCount = employees.length

    const selectedIds = employees
        .filter(employee => selectedEmployees[employee.id!])
        .map(employee => employee.id) as string[]

    const handleSelectChange = (id: string, isSelected: boolean) => {
        setSelectedEmployees((prevState) => ({
          ...prevState,
          [id]: isSelected
        }))
      }

    const handleCreate = () => {
        setErrorMessage("")
        closeModal();
        refreshEmployees()
    }

    const handleEdit = () => {
        setErrorMessage("")
        closeModal();
        refreshEmployees()
    }

    const handleDelete = () => {
        setErrorMessage("")
        closeModal();
        refreshEmployees()
    }

    const openCreateModal = () => {
        setErrorMessage("")
        setModalType(ModalType.Create)
        openModal()
    }

    const openEditModal = () => {
        if (selectedIds.length === 1) {
            setErrorMessage("")
            setModalType(ModalType.Update)
            openModal()
        } else {
            setErrorMessage("You must select exactly one employee to edit.")
        }
    }

    const openDeleteModal = () => {
        if (selectedIds.length > 0) {
            setErrorMessage("")
            setModalType(ModalType.Delete)
            openModal();
        } else {
            setErrorMessage("You must select at least one employee to delete.")
        }
    }

    return (
        <div className="container mx-auto max-w-2xl pt-5">
            { loading && <Loader /> }
            { error && <ErrorMessage message = {error} /> }
            { errorMessage && <ErrorMessage message={errorMessage} /> }
            <div className="fixed bottom-5 right-5 flex flex-col gap-2">
                <ActionButton
                    color="bg-green-700"
                    onClick={openCreateModal}
                    text="Add"
                />
                { employeesCount > 0 &&
                    <ActionButton
                        color="bg-blue-700"
                        onClick={openEditModal}
                        text="Edit"
                    />
                }
                { employeesCount > 0 &&
                    <ActionButton
                        color="bg-red-700"
                        onClick={openDeleteModal}
                        text="Delete"
                    />
                }
            </div>
            { employeesCount > 0 
                ? (employees.map((employee, index) => (
                    <Employee
                        key={employee.id}
                        employee={employee}
                        isSelected={!!selectedEmployees[employee.id!]}
                        onSelectChange={handleSelectChange}
                        index={index}
                    />)))
                : (<p className="text-center">No employees</p>)
            }

            { showModal && modalType === ModalType.Create &&
                <Modal title="Create new employee" onClose={ closeModal }>
                    <UpsertEmployee employee= { undefined } onCreate={ handleCreate }/>
                </Modal>
            }
            { showModal && modalType === ModalType.Update && selectedIds.length === 1 &&
                <Modal title="Edit employee" onClose={closeModal}>
                    <UpsertEmployee
                    employee={employees.find((e) => e.id === selectedIds[0])}
                    onCreate={handleEdit}
                    />
                </Modal>
            }
            { showModal && modalType === ModalType.Delete && selectedIds.length > 0 &&
                <Modal title="Delete employee" onClose={closeModal}>
                    <DeleteEmployee ids={selectedIds} onDelete={handleDelete} />
                </Modal>
            }
        </div>
    )
}
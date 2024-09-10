import { createContext, useState } from "react"

interface IModalContext {
    showModal: boolean
    openModal: () => void
    closeModal: () => void
}

export const ModalContext = createContext<IModalContext>( {
        showModal: false,
        openModal: () => {},
        closeModal: () => {}
    });

export const ModalState = ({ children }: {children: React.ReactNode}) => {
    const [showModal, setShowModal] = useState(false)
    const openModal = () => setShowModal(true)
    const closeModal = () => setShowModal(false)

    return (
        <ModalContext.Provider value = {{ showModal, openModal, closeModal }}>
            { children }
        </ModalContext.Provider>
    )
}
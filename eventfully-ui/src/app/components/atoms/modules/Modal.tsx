"use client"
import {ReactNode} from 'react'
import { useState } from 'react'

interface ModalProps {
    isOpen: boolean;
    onClose: () => void;
    children: ReactNode;
}

const Modal: React.FC<ModalProps> = ({ isOpen, onClose, children }) => {
    const [isMounted, setIsMounted] = useState(false)

    if (!isOpen) {
        return null
    }

    const handleTransitionEnd = () => {
        setIsMounted(true)
    }

    return (
        <div className={`modal ${isMounted ? "modal--open" : ""}`} onTransitionEnd={handleTransitionEnd}>
            <div className="modal__overlay" onClick={onClose} />
            <div className="modal__content">
                {children}
            </div>
        </div>
    )
}

export default Modal;
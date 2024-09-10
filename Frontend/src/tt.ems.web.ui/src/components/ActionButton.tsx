interface ActionButtonProps {
    color: string
    onClick: () => void
    text: string
}

export function ActionButton({ color, onClick, text }: ActionButtonProps) {
    return (
        <button
            className={`rounded-full ${color} bg-opacity-75 text-white text-2xl px-10 py-4`}
            onClick={onClick}
        >
            {text}
        </button>
    )
}
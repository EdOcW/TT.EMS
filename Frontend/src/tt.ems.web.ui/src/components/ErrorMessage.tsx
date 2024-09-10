interface ErrorMessageProps {
    message: string
}

export function ErrorMessage({ message }: ErrorMessageProps) {
    return (
        <p className="text-center text-red-600">{message}</p>
    )
}
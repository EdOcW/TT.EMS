import { Link } from "react-router-dom"

export function Navigation() {
    return (
        <nav className="h-[50px] flex justify-between px-5 bg-gray-500 items-center text-white">
            <span className="flex items-center font-bold">Employee Management System</span>
            
            <span>
                <Link to="/" className="mr-5">Employees</Link>
                <Link to="/about">About</Link>
            </span>
        </nav>
    )
}
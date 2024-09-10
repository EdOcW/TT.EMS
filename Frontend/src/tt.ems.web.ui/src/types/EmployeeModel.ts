import { Sex } from "./Sex"

export interface IEmployee {
    id?: string
    firstName: string
    lastName: string
    age: number
    sex: Sex
}
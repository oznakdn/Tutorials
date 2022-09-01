export interface IStudent{
    firstName : string;
    lastName : string;
    age : number;
    course : string;

    fullname : () => string;
    biography: () => void;
}
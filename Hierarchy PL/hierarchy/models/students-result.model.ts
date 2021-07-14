import { Iresult } from "interfaces/iresult";
import { Students } from "./students.model";


export class StudentsResult implements Iresult {
        success:boolean;
        userMessage: string;
        result_set: Students[]= [];
}

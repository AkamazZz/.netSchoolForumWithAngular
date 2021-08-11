import { Iresult } from "interfaces/iresult";
import { Students } from "./students.model";



export class StudentResult implements Iresult {
        success:boolean;
        userMessage: string;
        result_set: Students;
        result_set_dictionary: Map<number, number>;
}

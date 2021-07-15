import { Iresult } from "interfaces/iresult";
import {Faculty} from "models/faculty.model";

export class FacultyResult implements Iresult {
    success: boolean;
    userMessage: string;
    result_set: Faculty[]=[];
}

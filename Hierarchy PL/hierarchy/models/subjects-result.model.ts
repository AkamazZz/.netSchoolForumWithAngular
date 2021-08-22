import { Iresult } from "interfaces/iresult";
import { Subject } from "./subject.model";


export class SubjectsResult implements Iresult {
    success:boolean;
    userMessage: string;
    result_set: Subject[]= [];
    result_set_dictionary: Map<number, number>;

}

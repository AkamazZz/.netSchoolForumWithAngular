import { Iresult } from "interfaces/iresult";
import { Assessment } from "./assessment.model";

export class AssessmentsResult implements Iresult {
    success: boolean;
    userMessage: string;
    result_set: Assessment[]=[];
}

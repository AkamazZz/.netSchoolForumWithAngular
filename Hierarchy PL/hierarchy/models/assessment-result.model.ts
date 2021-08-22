import { Iresult } from "interfaces/iresult";
import { Assessment } from "./assessment.model";

export class AssessmentResult implements Iresult {
    success: boolean;
    userMessage: string;
    result_set: Assessment;
}

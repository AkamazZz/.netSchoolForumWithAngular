import { Iresult } from "interfaces/iresult";
import { Speciality } from "./speciality.model";

export class SpecialityResult implements Iresult {
    success: boolean;
    userMessage: string;
    result_set: Speciality[]=[];

}

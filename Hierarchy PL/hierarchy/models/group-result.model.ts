import { Group } from "./group.model";

export class GroupResult {
    success: boolean;
    userMessage: string;
    result_set:Group[]=[];
}

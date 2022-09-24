import { Stage } from "./stage";

export class Maintenance {
    userId : string;
    description : string;
    createdAt : Date;
    status : boolean;
    stage: Stage[];

    constructor(userId : string, description : string, createdAt : Date,  status : boolean,stage: Stage[]) {
        this.userId = userId;
        this.description = description;
        this.createdAt = createdAt;
        this.status = status;
        this.stage = stage;
    }

}
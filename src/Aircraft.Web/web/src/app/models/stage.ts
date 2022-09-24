export class Stage {
    description : string;
    createdAt : Date;
    status : boolean;
    type: number;
    value: string;
    maintenanceId: string;

    constructor(description : string, createdAt : Date,  type: number, value : string, status : boolean, maintenanceId: string) {
        this.description = description;
        this.createdAt = createdAt;
        this.type = type;
        this.value = value;
        this.status = status;
        this.maintenanceId = maintenanceId;
    }

}
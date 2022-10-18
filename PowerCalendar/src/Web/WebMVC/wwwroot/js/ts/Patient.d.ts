declare class Patient {
    private _application;
    constructor(application: Application);
    GetPatients(): Promise<any>;
}

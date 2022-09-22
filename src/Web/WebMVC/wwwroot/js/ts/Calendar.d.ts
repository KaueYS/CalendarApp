declare class Calendar {
    private _application;
    constructor(application: Application);
    GetEvents(): Promise<any>;
}

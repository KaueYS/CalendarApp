declare class Application {
    private _server;
    get Server(): Server;
    private _patient;
    get Patient(): Patient;
    private _calendar;
    get Calendar(): Calendar;
    constructor();
}

class Application {
    private _server: Server;
    get Server(): Server {
        return this._server;
    }
    private _patient: Patient;
    get Patient(): Patient {
        return this._patient;
    }
    private _calendar: Calendar;
    get Calendar(): Calendar {
        return this._calendar;
    }
    constructor() {
        this._server = new Server(this);
        this._patient = new Patient(this);
        this._calendar = new Calendar(this);
    }
}
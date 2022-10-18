class Application {
    constructor() {
        this._server = new Server(this);
        this._patient = new Patient(this);
        this._calendar = new Calendar(this);
    }
    get Server() {
        return this._server;
    }
    get Patient() {
        return this._patient;
    }
    get Calendar() {
        return this._calendar;
    }
}
//# sourceMappingURL=Application.js.map
class Calendar {
    private _application: Application;
    constructor(application: Application) {
        this._application = application;
    }
    public async GetEvents(): Promise<any> {
        const body = await this._application.Server.Get('/api/Calendar/GetEvents');
        const events = this._application.Server.Deserialize(body);
        return events;
    }
}
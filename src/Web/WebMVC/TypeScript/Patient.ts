class Patient {
    private _application: Application;
    constructor(application: Application) {
        this._application = application;
    }

    public async GetPatients(): Promise<any> {
        const body = await this._application.Server.Get('/api/Core/GetPatients');
        const patients = this._application.Server.Deserialize(body);
        return patients;
    }
}
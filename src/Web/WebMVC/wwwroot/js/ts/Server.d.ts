declare class Server {
    private _application;
    constructor(application: Application);
    private readonly JSON_START;
    private readonly JSON_END;
    private readonly JSON_ARRAY_START;
    private readonly JSON_ARRAY_END;
    Get(endpoint: string): Promise<string>;
    Post(endpoint: string, body: any): Promise<string>;
    private CreateResponse;
    Deserialize(data: string): any;
    IsJson(data: string): boolean;
    private IsJsonInstance;
    private IsJsonArray;
    private SetDefaultHeaders;
    private SetJsonHeaders;
    private EnsureASCII;
    private HasUnicode;
    private ConvertToASCII;
}

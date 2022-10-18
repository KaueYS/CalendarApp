class Server {
    private _application: Application;
    constructor(application: Application) {
        this._application = application;
    }

    private readonly JSON_START = '{';
    private readonly JSON_END = '}';
    private readonly JSON_ARRAY_START = '[';
    private readonly JSON_ARRAY_END = ']';

    public async Get(endpoint: string): Promise<string> {
        const headers = this.SetDefaultHeaders();
        return new Promise<string>((resolve, reject) => {
            const xhr: XMLHttpRequest = new XMLHttpRequest();
            xhr.withCredentials = false; // add Authorize in header
            xhr.onload = async () => {
                resolve(this.CreateResponse(xhr))
            };
            xhr.open('GET', endpoint, true);
            for (let i: number = 0; i < headers.length; i++) {
                const header: [string, string] = headers[i];
                xhr.setRequestHeader(header[0], this.EnsureASCII(header[1]));
            }
            xhr.send(null);
        });
    }
    public async Post(endpoint: string, body: any): Promise<string> {
        const headers = this.SetJsonHeaders();
        return new Promise<string>((resolve, reject) => {
            const xhr: XMLHttpRequest = new XMLHttpRequest();
            xhr.withCredentials = false;
            xhr.onload = async () => {
                resolve(this.CreateResponse(xhr))
            };
            xhr.open('POST', endpoint, true);
            for (let i: number = 0; i < headers.length; i++) {
                const header: [string, string] = headers[i];
                xhr.setRequestHeader(header[0], this.EnsureASCII(header[1]));
            }
            xhr.send(JSON.stringify(body));
        });
    }

    private CreateResponse(xhr: XMLHttpRequest): string {
        return xhr.responseText;
    }

    public Deserialize(data: string): any {
        if (!this.IsJson(data))
            return (data);
        return (JSON.parse(data));
    }

    public IsJson(data: string): boolean {
        return ((this.IsJsonInstance(data)) || (this.IsJsonArray(data)));
    }

    private IsJsonInstance(data: string): boolean {
        if (data === null)
            return (false);
        if (data.length < 2)
            return (false);
        return ((data.substr != null) && (data.substr(0, 1) == this.JSON_START) && (data.substr(data.length - 1, 1) == this.JSON_END));
    }

    private IsJsonArray(data: string): boolean {
        if (data === null)
            return (false);
        if (data.length < 2)
            return (false);
        return ((data.substr != null) && (data.substr(0, 1) == this.JSON_ARRAY_START) && (data.substr(data.length - 1, 1) == this.JSON_ARRAY_END));
    }

    private SetDefaultHeaders(): [string, string][] {
        const headers: [string, string][] = [];
        headers.push(['Content-Type', 'application/x-www-form-urlencoded']); // together withCredentials do not as for CORS
        return headers;
    }

    private SetJsonHeaders(): [string, string][] {
        const headers: [string, string][] = [];
        headers.push(['Content-Type', 'application/json']); // together withCredentials do not as for CORS
        return headers;
    }

    private EnsureASCII(data: string): string {
        if (this.HasUnicode(data))
            return (this.ConvertToASCII(data));
        return (data);
    }

    private HasUnicode(data: string): boolean {
        for (let i = 0; i < data.length; i++) {
            const char: string = data[i];
            const index: number = char.charCodeAt(0);
            if (index > 127)
                return (true);
        }
        return (false);
    }

    private ConvertToASCII(data: string): string {
        let encoded: string = '';
        for (let i = 0; i < data.length; i++) {
            const char: string = data[i];
            const index: number = char.charCodeAt(0);
            encoded += '\\u' + index.toString(16).toUpperCase();
        }
        return (encoded);
    }
}
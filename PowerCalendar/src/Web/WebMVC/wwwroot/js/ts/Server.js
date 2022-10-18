var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class Server {
    constructor(application) {
        this.JSON_START = '{';
        this.JSON_END = '}';
        this.JSON_ARRAY_START = '[';
        this.JSON_ARRAY_END = ']';
        this._application = application;
    }
    Get(endpoint) {
        return __awaiter(this, void 0, void 0, function* () {
            const headers = this.SetDefaultHeaders();
            return new Promise((resolve, reject) => {
                const xhr = new XMLHttpRequest();
                xhr.withCredentials = false;
                xhr.onload = () => __awaiter(this, void 0, void 0, function* () {
                    resolve(this.CreateResponse(xhr));
                });
                xhr.open('GET', endpoint, true);
                for (let i = 0; i < headers.length; i++) {
                    const header = headers[i];
                    xhr.setRequestHeader(header[0], this.EnsureASCII(header[1]));
                }
                xhr.send(null);
            });
        });
    }
    Post(endpoint, body) {
        return __awaiter(this, void 0, void 0, function* () {
            const headers = this.SetJsonHeaders();
            return new Promise((resolve, reject) => {
                const xhr = new XMLHttpRequest();
                xhr.withCredentials = false;
                xhr.onload = () => __awaiter(this, void 0, void 0, function* () {
                    resolve(this.CreateResponse(xhr));
                });
                xhr.open('POST', endpoint, true);
                for (let i = 0; i < headers.length; i++) {
                    const header = headers[i];
                    xhr.setRequestHeader(header[0], this.EnsureASCII(header[1]));
                }
                xhr.send(JSON.stringify(body));
            });
        });
    }
    CreateResponse(xhr) {
        return xhr.responseText;
    }
    Deserialize(data) {
        if (!this.IsJson(data))
            return (data);
        return (JSON.parse(data));
    }
    IsJson(data) {
        return ((this.IsJsonInstance(data)) || (this.IsJsonArray(data)));
    }
    IsJsonInstance(data) {
        if (data === null)
            return (false);
        if (data.length < 2)
            return (false);
        return ((data.substr != null) && (data.substr(0, 1) == this.JSON_START) && (data.substr(data.length - 1, 1) == this.JSON_END));
    }
    IsJsonArray(data) {
        if (data === null)
            return (false);
        if (data.length < 2)
            return (false);
        return ((data.substr != null) && (data.substr(0, 1) == this.JSON_ARRAY_START) && (data.substr(data.length - 1, 1) == this.JSON_ARRAY_END));
    }
    SetDefaultHeaders() {
        const headers = [];
        headers.push(['Content-Type', 'application/x-www-form-urlencoded']);
        return headers;
    }
    SetJsonHeaders() {
        const headers = [];
        headers.push(['Content-Type', 'application/json']);
        return headers;
    }
    EnsureASCII(data) {
        if (this.HasUnicode(data))
            return (this.ConvertToASCII(data));
        return (data);
    }
    HasUnicode(data) {
        for (let i = 0; i < data.length; i++) {
            const char = data[i];
            const index = char.charCodeAt(0);
            if (index > 127)
                return (true);
        }
        return (false);
    }
    ConvertToASCII(data) {
        let encoded = '';
        for (let i = 0; i < data.length; i++) {
            const char = data[i];
            const index = char.charCodeAt(0);
            encoded += '\\u' + index.toString(16).toUpperCase();
        }
        return (encoded);
    }
}
//# sourceMappingURL=Server.js.map
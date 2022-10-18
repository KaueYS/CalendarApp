var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class Patient {
    constructor(application) {
        this._application = application;
    }
    GetPatients() {
        return __awaiter(this, void 0, void 0, function* () {
            const body = yield this._application.Server.Get('/api/Core/GetPatients');
            const patients = this._application.Server.Deserialize(body);
            return patients;
        });
    }
}
//# sourceMappingURL=Patient.js.map
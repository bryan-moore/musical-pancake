class ApiParamNameConverter {

    constructor(param) {
        this.translateParams(param);
    }

    translateParams(paramName) {
        console.log(paramName);
        if (paramName === "") {
            return 'Temperture';
        }
        else {
            return 'unknown param'
        }
    }

}

export default ApiParamNameConverter;
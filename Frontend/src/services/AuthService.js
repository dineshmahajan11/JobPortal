import api from "./api";

const login = async (loginData) => {
    const response = await api.post("/Auth/login", loginData);
    return response.data;
};

const register = async (registerData) => {
    const response = await api.post("/Auth/register", registerData);
    return response.data;
};

const AuthService = {
    login,
    register
};

export default AuthService;
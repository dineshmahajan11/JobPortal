import { createContext, useState } from "react";
import {
    getUser,
    getToken,
    saveAuthData,
    clearAuthData,
} from "../utils/auth";

export const defaultAuthContext = {
    user: null,
    token: null,
    login: () => {},
    logout: () => {},
    isAuthenticated: false,
};

const AuthContext = createContext(defaultAuthContext);

export const AuthProvider = ({ children }) => {
   const [user, setUser] = useState(getUser());
const [token, setToken] = useState(getToken());

    const login = (newToken, newUser) => {
        saveAuthData(newToken, newUser);
        setToken(newToken);
        setUser(newUser);
    };

    const logout = () => {
        clearAuthData();
        setToken(null);
        setUser(null);
    };

    return (
        <AuthContext.Provider
            value={{
                user,
                token,
                login,
                logout,
                isAuthenticated: !!token,
            }}
        >
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
export { AuthContext };
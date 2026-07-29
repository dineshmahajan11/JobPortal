import { createContext, useState, useEffect } from "react";
import {
    getUser,
    getToken,
    saveAuthData,
    clearAuthData
} from "../utils/auth";

export const AuthContext = createContext(null);

function AuthProvider({ children }) {

    // Initialize state from localStorage
    const [user, setUser] = useState(null);
    const [token, setToken] = useState(null);

    // Load user and token when the application starts
    useEffect(() => {
        setUser(getUser());
        setToken(getToken());
    }, []);

    // Login function
    const login = (token, user) => {
        saveAuthData(token, user);

        setToken(token);
        setUser(user);
    };

    // Logout function
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
                isAuthenticated: !!token
            }}
        >
            {children}
        </AuthContext.Provider>
    );
}

export default AuthProvider;
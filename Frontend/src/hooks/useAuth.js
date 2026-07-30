import { useContext } from "react";
import { AuthContext, defaultAuthContext } from "../context/AuthContext";

const useAuth = () => {
    const context = useContext(AuthContext);

    return context ?? defaultAuthContext;
};

export default useAuth;
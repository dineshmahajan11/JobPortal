import { useContext } from "react";
import { AuthContext } from "../context/AuthContext.jsx";
import { defaultAuthContext } from "../context/authContext";

const useAuth = () => {
    const context = useContext(AuthContext);

    return context ?? defaultAuthContext;
};

export default useAuth;
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import AuthService from "../../services/AuthService";
import useAuth from "../../hooks/useAuth";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();
    const { login } = useAuth();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await AuthService.login({
                email,
                password
            });

            console.log("Login Success:", response);

            login(
                response.data.token,
                response.data.user
            );

            alert(response.message);

            // Redirect based on role
            if (response.data.user.role === "Recruiter") {
                navigate("/recruiter/dashboard");
            }
            else if (response.data.user.role === "JobSeeker") {
                navigate("/jobseeker/dashboard");
            }
        }
        catch (error) {
            console.error(error);

            if (error.response) {
                alert(error.response.data.message);
            }
            else {
                alert("Unable to connect to server.");
            }
        }
    };

    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-5">
                    <div className="card shadow">
                        <div className="card-body">

                            <h2 className="text-center mb-4">
                                Login
                            </h2>

                            <form onSubmit={handleLogin}>

                                <div className="mb-3">
                                    <label className="form-label">
                                        Email
                                    </label>

                                    <input
                                        type="email"
                                        className="form-control"
                                        placeholder="Enter Email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        required
                                    />
                                </div>

                                <div className="mb-3">
                                    <label className="form-label">
                                        Password
                                    </label>

                                    <input
                                        type="password"
                                        className="form-control"
                                        placeholder="Enter Password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        required
                                    />
                                </div>

                                <button
                                    type="submit"
                                    className="btn btn-primary w-100">
                                    Login
                                </button>

                            </form>

                            <p className="text-center mt-3">
                                Don't have an account?{" "}
                                <Link to="/register">
                                    Register
                                </Link>
                            </p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;
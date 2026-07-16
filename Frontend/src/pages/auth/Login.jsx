import { Link } from "react-router-dom";

function Login() {
    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-5">

                    <div className="card shadow">
                        <div className="card-body">

                            <h2 className="text-center mb-4">
                                Login
                            </h2>

                            <form>

                                <div className="mb-3">
                                    <label className="form-label">
                                        Email
                                    </label>

                                    <input
                                        type="email"
                                        className="form-control"
                                        placeholder="Enter email"
                                    />
                                </div>

                                <div className="mb-3">
                                    <label className="form-label">
                                        Password
                                    </label>

                                    <input
                                        type="password"
                                        className="form-control"
                                        placeholder="Enter password"
                                    />
                                </div>

                                <button
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
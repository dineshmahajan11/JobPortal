//import { useState } from "react";
import { Link } from "react-router-dom";

function Register() {
    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-6">

                    <div className="card shadow">
                        <div className="card-body">

                            <h2 className="text-center mb-4">
                                Register
                            </h2>

                            <form>

                                <div className="mb-3">
                                    <label className="form-label">
                                        Full Name
                                    </label>

                                    <input
                                        type="text"
                                        className="form-control"
                                        placeholder="Enter full name"
                                    />
                                </div>

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

                                <div className="mb-3">
                                    <label className="form-label">
                                        Role
                                    </label>

                                    <select className="form-select">
                                        <option value="">
                                            Select Role
                                        </option>

                                        <option value="JobSeeker">
                                            Job Seeker
                                        </option>

                                        <option value="Recruiter">
                                            Recruiter
                                        </option>
                                    </select>
                                </div>

                                <button
                                    className="btn btn-success w-100">
                                    Register
                                </button>

                            </form>

                            <p className="text-center mt-3">
                                Already have an account?{" "}
                                <Link to="/login">
                                    Login
                                </Link>
                            </p>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
}

export default Register;
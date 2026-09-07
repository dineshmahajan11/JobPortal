import { NavLink } from "react-router-dom";
import useAuth from "../../hooks/useAuth";

function Sidebar() {
    const { user } = useAuth();
    const isRecruiter = user?.role === "Recruiter";

    return (
        <div
            className="bg-dark text-white p-3"
            style={{
                width: "250px",
                minHeight: "100vh"
            }}
        >
            <h4 className="mb-4">Job Portal</h4>

            <ul className="nav flex-column">

                <li className="nav-item mb-2">
                    <NavLink
                        to={isRecruiter ? "/recruiter/dashboard" : "/jobseeker/dashboard"}
                        className="nav-link text-white"
                    >
                        Dashboard
                    </NavLink>
                </li>

                {isRecruiter ? <li className="nav-item mb-2">
                    <NavLink
                        to="/recruiter/jobs"
                        className="nav-link text-white"
                    >
                        Manage Jobs
                    </NavLink>
                </li> : <li className="nav-item mb-2">
                    <NavLink to="/jobseeker/jobs" className="nav-link text-white">Find Jobs</NavLink>
                </li>}

                {isRecruiter ? <li className="nav-item mb-2">
                    <NavLink
                        to="/recruiter/applications"
                        className="nav-link text-white"
                    >
                        Applications
                    </NavLink>
                </li> : <li className="nav-item mb-2">
                    <NavLink to="/jobseeker/applications" className="nav-link text-white">My Applications</NavLink>
                </li>}

                {!isRecruiter && <li className="nav-item mb-2">
                    <NavLink to="/jobseeker/saved" className="nav-link text-white">Saved Jobs</NavLink>
                </li>}

                <li className="nav-item">
                    <NavLink to={isRecruiter ? "/recruiter/profile" : "/jobseeker/profile"} className="nav-link text-white">Profile</NavLink>
                </li>

            </ul>
        </div>
    );
}

export default Sidebar;
import { NavLink } from "react-router-dom";

function Sidebar() {
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
                        to="/recruiter/dashboard"
                        className="nav-link text-white"
                    >
                        Dashboard
                    </NavLink>
                </li>

                <li className="nav-item mb-2">
                    <NavLink
                        to="/recruiter/jobs"
                        className="nav-link text-white"
                    >
                        Manage Jobs
                    </NavLink>
                </li>

                <li className="nav-item mb-2">
                    <NavLink
                        to="/recruiter/applications"
                        className="nav-link text-white"
                    >
                        Applications
                    </NavLink>
                </li>

                <li className="nav-item">
                    <NavLink
                        to="/recruiter/profile"
                        className="nav-link text-white"
                    >
                        Profile
                    </NavLink>
                </li>

            </ul>
        </div>
    );
}

export default Sidebar;
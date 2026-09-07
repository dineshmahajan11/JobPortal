import useAuth from "../../hooks/useAuth";

function TopNavbar() {
    const { user, logout } = useAuth();

    const handleLogout = () => {
        logout();
        window.location.href = "/login";
    };

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-white border-bottom shadow-sm px-4">

            <div className="container-fluid">

                <h5 className="mb-0">
                    Dashboard
                </h5>

                <div className="ms-auto d-flex align-items-center">

                    <span className="me-3">
                        Welcome, <strong>{user?.fullName}</strong>
                    </span>

                    <button
                        className="btn btn-outline-danger btn-sm"
                        onClick={handleLogout}
                    >
                        Logout
                    </button>

                </div>

            </div>

        </nav>
    );
}

export default TopNavbar;
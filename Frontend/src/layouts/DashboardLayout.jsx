import { Outlet } from "react-router-dom";

import Sidebar from "../components/common/Sidebar";
import TopNavbar from "../components/common/TopNavbar";

function DashboardLayout() {
    return (
        <div className="d-flex">

            {/* Sidebar */}
            <Sidebar />

            {/* Main Content */}
            <div
                className="flex-grow-1"
                style={{
                    backgroundColor: "#f8f9fa",
                    minHeight: "100vh"
                }}
            >
                {/* Top Navbar */}
                <TopNavbar />

                {/* Page Content */}
                <div className="p-4">
                    <Outlet />
                </div>
            </div>

        </div>
    );
}

export default DashboardLayout;
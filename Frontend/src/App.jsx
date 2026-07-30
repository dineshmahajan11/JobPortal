import { BrowserRouter, Routes, Route } from "react-router-dom";

import Login from "./pages/auth/Login";
import Register from "./pages/auth/Register";

import RecruiterDashboard from "./pages/recruiter/Dashboard";
import JobSeekerDashboard from "./pages/jobseeker/Dashboard";

import ProtectedRoute from "./routes/ProtectedRoute";
import DashboardLayout from "./layouts/DashboardLayout";

function App() {
    return (
        <BrowserRouter>
            <Routes>

                {/* Public Routes */}
                <Route path="/" element={<Login />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />

                {/* Recruiter Routes */}
                <Route
                    element={
                        <ProtectedRoute allowedRoles={["Recruiter"]} />
                    }
                >
                    <Route element={<DashboardLayout />}>
                        <Route
                            path="/recruiter/dashboard"
                            element={<RecruiterDashboard />}
                        />
                    </Route>
                </Route>

                {/* Job Seeker Routes */}
                <Route
                    element={
                        <ProtectedRoute allowedRoles={["JobSeeker"]} />
                    }
                >
                    <Route element={<DashboardLayout />}>
                        <Route
                            path="/jobseeker/dashboard"
                            element={<JobSeekerDashboard />}
                        />
                    </Route>
                </Route>

            </Routes>
        </BrowserRouter>
    );
}

export default App;
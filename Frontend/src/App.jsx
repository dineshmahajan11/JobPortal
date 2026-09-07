import { BrowserRouter, Routes, Route } from "react-router-dom";

import Login from "./pages/auth/Login";
import Register from "./pages/auth/Register";

import RecruiterDashboard from "./pages/recruiter/Dashboard";
import JobSeekerDashboard from "./pages/jobseeker/Dashboard";
import JobSeekerJobs from "./pages/jobseeker/Jobs";
import JobSeekerApplications from "./pages/jobseeker/Applications";
import SavedJobs from "./pages/jobseeker/SavedJobs";
import RecruiterJobs from "./pages/recruiter/Jobs";
import RecruiterApplications from "./pages/recruiter/Applications";
import Profile from "./pages/Profile";

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
                        <Route path="/recruiter/jobs" element={<RecruiterJobs />} />
                        <Route path="/recruiter/applications" element={<RecruiterApplications />} />
                        <Route path="/recruiter/profile" element={<Profile />} />
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
                        <Route path="/jobseeker/jobs" element={<JobSeekerJobs />} />
                        <Route path="/jobseeker/applications" element={<JobSeekerApplications />} />
                        <Route path="/jobseeker/saved" element={<SavedJobs />} />
                        <Route path="/jobseeker/profile" element={<Profile />} />
                    </Route>
                </Route>

            </Routes>
        </BrowserRouter>
    );
}

export default App;
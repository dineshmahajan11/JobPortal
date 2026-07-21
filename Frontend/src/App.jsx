import { BrowserRouter, Routes, Route } from "react-router-dom";

import Login from "./pages/auth/Login";
import Register from "./pages/auth/Register";

import RecruiterDashboard from "./pages/recruiter/Dashboard";
import JobSeekerDashboard from "./pages/jobseeker/Dashboard";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />

                <Route path="/login" element={<Login />} />

                <Route path="/register" element={<Register />} />

                <Route
                    path="/recruiter/dashboard"
                    element={<RecruiterDashboard />}
                />

                <Route
                    path="/jobseeker/dashboard"
                    element={<JobSeekerDashboard />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
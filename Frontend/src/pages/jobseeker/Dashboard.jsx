import { useEffect, useState } from "react";
import getDashboard from "../../services/dashboardService";

function Stat({ label, value }) {
    return <div className="col-md-3"><div className="card shadow-sm h-100"><div className="card-body"><small className="text-muted">{label}</small><h2 className="mt-2 mb-0">{value}</h2></div></div></div>;
}

function JobSeekerDashboard() {
    const [data, setData] = useState(null);
    const [error, setError] = useState("");

    useEffect(() => { getDashboard("JobSeeker").then(setData).catch(() => setError("Could not load your dashboard.")); }, []);

    if (error) return <div className="alert alert-danger">{error}</div>;
    if (!data) return <p>Loading dashboard...</p>;

    return <div><div className="mb-4"><h2>Good to see you</h2><p className="text-muted">Track your job search from one place.</p></div><div className="row g-3"><Stat label="Applied jobs" value={data.appliedJobs} /><Stat label="Saved jobs" value={data.savedJobs} /><Stat label="Shortlisted" value={data.shortlistedJobs} /><Stat label="Resume" value={data.resumeUploaded ? "Uploaded" : "Missing"} /></div></div>;
}

export default JobSeekerDashboard;
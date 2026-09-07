import { useEffect, useState } from "react";
import getDashboard from "../../services/dashboardService";

function Stat({ label, value }) {
    return <div className="col-md-3"><div className="card shadow-sm h-100"><div className="card-body"><small className="text-muted">{label}</small><h2 className="mt-2 mb-0">{value}</h2></div></div></div>;
}

function RecruiterDashboard() {
    const [data, setData] = useState(null);
    const [error, setError] = useState("");

    useEffect(() => { getDashboard("Recruiter").then(setData).catch(() => setError("Could not load your dashboard.")); }, []);

    if (error) return <div className="alert alert-danger">{error}</div>;
    if (!data) return <p>Loading dashboard...</p>;

    return <div><div className="mb-4"><h2>Recruiter overview</h2><p className="text-muted">Keep your hiring pipeline moving.</p></div><div className="row g-3"><Stat label="Jobs posted" value={data.totalJobs} /><Stat label="Applications" value={data.totalApplications} /><Stat label="Pending" value={data.pendingApplications} /><Stat label="Shortlisted" value={data.shortlistedApplications} /></div></div>;
}

export default RecruiterDashboard;
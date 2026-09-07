import { useEffect, useState } from "react";
import { getMyApplications } from "../../services/jobService";

function Applications() {
    const [applications, setApplications] = useState([]);
    useEffect(() => { getMyApplications().then(setApplications).catch(() => setApplications([])); }, []);
    return <div><h2 className="mb-4">My applications</h2><div className="table-responsive"><table className="table align-middle"><thead><tr><th>Job</th><th>Status</th><th>Applied</th></tr></thead><tbody>{applications.map((item) => <tr key={item.id ?? item.applicationId}><td>{item.job?.title ?? item.jobTitle ?? "Application"}</td><td><span className="badge text-bg-secondary">{item.status}</span></td><td>{item.appliedDate ? new Date(item.appliedDate).toLocaleDateString() : "-"}</td></tr>)}</tbody></table></div>{applications.length === 0 && <p className="text-muted">You have not applied to any jobs yet.</p>}</div>;
}
export default Applications;

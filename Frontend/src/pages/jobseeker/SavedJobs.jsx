import { useEffect, useState } from "react";
import { getSavedJobs, removeSavedJob } from "../../services/jobService";

function SavedJobs() {
    const [jobs, setJobs] = useState([]);
    const [error, setError] = useState("");
    const load = () => getSavedJobs().then(setJobs).catch(() => setError("Could not load saved jobs."));
    useEffect(load, []);
    const remove = async (id) => { try { await removeSavedJob(id); setJobs(jobs.filter((job) => job.id !== id)); } catch { setError("Could not remove this job."); } };
    return <div><h2 className="mb-4">Saved jobs</h2>{error && <div className="alert alert-danger">{error}</div>}<div className="row g-3">{jobs.map((job) => <div className="col-lg-6" key={job.id}><div className="card shadow-sm"><div className="card-body"><h5>{job.title}</h5><p className="text-muted">{job.companyName} · {job.location}</p><button className="btn btn-outline-danger btn-sm" onClick={() => remove(job.id)}>Remove</button></div></div></div>)}</div>{jobs.length === 0 && <p className="text-muted">No saved jobs yet.</p>}</div>;
}
export default SavedJobs;

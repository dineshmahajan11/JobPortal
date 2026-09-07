import { useEffect, useState } from "react";
import { applyToJob, getJobs, saveJob } from "../../services/jobService";

function Jobs() {
    const [jobs, setJobs] = useState([]);
    const [keyword, setKeyword] = useState("");
    const [location, setLocation] = useState("");
    const [message, setMessage] = useState("");
    const [error, setError] = useState("");

    const loadJobs = async () => {
        try {
            const result = await getJobs({ keyword, location });
            setJobs(result.items ?? result ?? []);
        } catch { setError("Could not load jobs. Please try again."); }
    };
    useEffect(() => {
        let active = true;
        getJobs().then((result) => {
            if (active) setJobs(result.items ?? result ?? []);
        }).catch(() => {
            if (active) setError("Could not load jobs. Please try again.");
        });
        return () => { active = false; };
    }, []);

    const run = async (action, success) => {
        try { await action(); setMessage(success); setError(""); } catch (requestError) { setError(requestError.response?.data?.message || "Request failed."); }
    };

    return <div><div className="d-flex justify-content-between align-items-center mb-4"><div><h2>Find your next role</h2><p className="text-muted mb-0">Search opportunities from the job board.</p></div></div><form className="row g-2 mb-4" onSubmit={(event) => { event.preventDefault(); loadJobs(); }}><div className="col-md-5"><input className="form-control" placeholder="Job title or keyword" value={keyword} onChange={(event) => setKeyword(event.target.value)} /></div><div className="col-md-4"><input className="form-control" placeholder="Location" value={location} onChange={(event) => setLocation(event.target.value)} /></div><div className="col-md-3"><button className="btn btn-primary w-100">Search jobs</button></div></form>{message && <div className="alert alert-success">{message}</div>}{error && <div className="alert alert-danger">{error}</div>}<div className="row g-3">{jobs.map((job) => <div className="col-lg-6" key={job.id}><div className="card h-100 shadow-sm"><div className="card-body"><h5>{job.title}</h5><p className="text-muted mb-2">{job.companyName} · {job.location}</p><p>{job.description}</p><strong>${job.salary}</strong><div className="mt-3 d-flex gap-2"><button className="btn btn-primary" onClick={() => run(() => applyToJob(job.id), "Application submitted.")}>Apply</button><button className="btn btn-outline-secondary" onClick={() => run(() => saveJob(job.id), "Job saved.")}>Save</button></div></div></div></div>)}</div>{jobs.length === 0 && <p className="text-muted">No jobs found.</p>}</div>;
}

export default Jobs;

import { useEffect, useState } from "react";
import { createJob, deleteJob, getRecruiterJobs } from "../../services/jobService";

const emptyJob = { title: "", description: "", companyName: "", location: "", salary: "" };

function Jobs() {
    const [jobs, setJobs] = useState([]);
    const [form, setForm] = useState(emptyJob);
    const [error, setError] = useState("");
    const [message, setMessage] = useState("");
    const load = () => getRecruiterJobs().then(setJobs).catch(() => setError("Could not load your jobs."));
    useEffect(load, []);
    const submit = async (event) => { event.preventDefault(); try { await createJob({ ...form, salary: Number(form.salary) }); setForm(emptyJob); setMessage("Job published."); load(); } catch (requestError) { setError(requestError.response?.data?.message || "Could not publish job."); } };
    const remove = async (id) => { try { await deleteJob(id); setJobs(jobs.filter((job) => job.id !== id)); } catch { setError("Could not delete job."); } };
    return <div><h2>Manage jobs</h2><div className="row g-4 mt-1"><div className="col-lg-5"><div className="card shadow-sm"><div className="card-body"><h5 className="mb-3">Publish a job</h5>{message && <div className="alert alert-success">{message}</div>}{error && <div className="alert alert-danger">{error}</div>}<form onSubmit={submit}>{[["title","Title"],["companyName","Company"],["location","Location"],["salary","Salary"]].map(([name, label]) => <div className="mb-3" key={name}><label className="form-label">{label}</label><input className="form-control" type={name === "salary" ? "number" : "text"} value={form[name]} onChange={(event) => setForm({ ...form, [name]: event.target.value })} required /></div>)}<div className="mb-3"><label className="form-label">Description</label><textarea className="form-control" rows="4" value={form.description} onChange={(event) => setForm({ ...form, description: event.target.value })} required /></div><button className="btn btn-primary w-100">Publish job</button></form></div></div></div><div className="col-lg-7"><h5>Published jobs</h5>{jobs.map((job) => <div className="card shadow-sm mb-3" key={job.id}><div className="card-body d-flex justify-content-between"><div><h5>{job.title}</h5><p className="text-muted mb-0">{job.companyName} · {job.location}</p></div><button className="btn btn-outline-danger btn-sm align-self-center" onClick={() => remove(job.id)}>Delete</button></div></div>)}{jobs.length === 0 && <p className="text-muted">No jobs published yet.</p>}</div></div></div>;
}
export default Jobs;

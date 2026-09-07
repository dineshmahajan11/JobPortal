import { useState } from "react";
import useAuth from "../hooks/useAuth";
import { uploadResume } from "../services/profileService";

function Profile() {
    const { user } = useAuth();
    const [file, setFile] = useState(null);
    const [message, setMessage] = useState("");
    const [error, setError] = useState("");
    const submit = async (event) => { event.preventDefault(); if (!file) return; try { const result = await uploadResume(file); setMessage(result.message || "Resume uploaded successfully."); setError(""); } catch { setError("Could not upload the resume."); } };
    return <div className="row"><div className="col-lg-7"><h2>Profile</h2><div className="card shadow-sm mt-3"><div className="card-body"><h5>{user?.fullName}</h5><p className="text-muted">{user?.email}</p><span className="badge text-bg-primary">{user?.role}</span>{user?.role === "JobSeeker" && <form className="mt-4" onSubmit={submit}><label className="form-label">Resume</label><input className="form-control mb-3" type="file" accept=".pdf,.doc,.docx" onChange={(event) => setFile(event.target.files[0])} />{message && <div className="alert alert-success">{message}</div>}{error && <div className="alert alert-danger">{error}</div>}<button className="btn btn-primary" disabled={!file}>Upload resume</button></form>}</div></div></div></div>;
}
export default Profile;

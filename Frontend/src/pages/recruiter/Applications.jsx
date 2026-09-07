import { useEffect, useState } from "react";
import { getApplicants, getRecruiterJobs, updateApplicationStatus } from "../../services/jobService";

function Applications() {
    const [jobs, setJobs] = useState([]);
    const [selectedJob, setSelectedJob] = useState("");
    const [applicants, setApplicants] = useState([]);
    const loadApplicants = (jobId) => { setSelectedJob(jobId); if (jobId) getApplicants(jobId).then(setApplicants).catch(() => setApplicants([])); };
    useEffect(() => { getRecruiterJobs().then(setJobs).catch(() => setJobs([])); }, []);
    const update = async (applicationId, status) => { await updateApplicationStatus(applicationId, status); loadApplicants(selectedJob); };
    return <div><h2 className="mb-4">Applications</h2><select className="form-select mb-4" value={selectedJob} onChange={(event) => loadApplicants(event.target.value)}><option value="">Select a job</option>{jobs.map((job) => <option value={job.id} key={job.id}>{job.title}</option>)}</select>{selectedJob && <div className="table-responsive"><table className="table align-middle"><thead><tr><th>Applicant</th><th>Email</th><th>Applied</th><th>Status</th></tr></thead><tbody>{applicants.map((applicant) => <tr key={applicant.applicationId}><td>{applicant.applicantName}</td><td>{applicant.email}</td><td>{new Date(applicant.appliedDate).toLocaleDateString()}</td><td><select className="form-select form-select-sm" value={applicant.status} onChange={(event) => update(applicant.applicationId, event.target.value)}><option>Pending</option><option>Shortlisted</option><option>Rejected</option></select></td></tr>)}</tbody></table></div>}</div>;
}
export default Applications;

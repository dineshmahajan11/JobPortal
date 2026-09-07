import api from "./api";

const unwrap = (response) => response.data?.data ?? response.data;

export const getJobs = async (params = {}) => unwrap(await api.get("/Jobs", { params }));
export const getJob = async (id) => unwrap(await api.get(`/Jobs/${id}`));
export const createJob = async (job) => unwrap(await api.post("/Jobs", job));
export const updateJob = async (id, job) => unwrap(await api.put(`/Jobs/${id}`, job));
export const deleteJob = async (id) => api.delete(`/Jobs/${id}`);
export const getRecruiterJobs = async () => (await api.get("/Recruiter/jobs")).data;
export const applyToJob = async (jobId) => (await api.post("/JobApplications/apply", { jobId })).data;
export const getMyApplications = async () => (await api.get("/JobApplications/my")).data;
export const saveJob = async (jobId) => api.post(`/SavedJobs/${jobId}`);
export const getSavedJobs = async () => unwrap(await api.get("/SavedJobs"));
export const removeSavedJob = async (jobId) => api.delete(`/SavedJobs/${jobId}`);
export const getApplicants = async (jobId) => (await api.get(`/Recruiter/jobs/${jobId}/applications`)).data;
export const updateApplicationStatus = async (applicationId, status) =>
    (await api.put(`/Recruiter/applications/${applicationId}/status`, { status })).data;

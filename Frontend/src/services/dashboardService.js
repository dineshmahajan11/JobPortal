import api from "./api";

const getDashboard = async (role) => {
    const endpoint = role === "Recruiter" ? "/Dashboard/recruiter" : "/Dashboard/jobseeker";
    const response = await api.get(endpoint);
    return response.data?.data ?? response.data;
};

export default getDashboard;

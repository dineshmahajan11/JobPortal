import api from "./api";

export const uploadResume = async (file) => {
    const formData = new FormData();
    formData.append("file", file);
    return (await api.post("/Profile/upload-resume", formData)).data;
};

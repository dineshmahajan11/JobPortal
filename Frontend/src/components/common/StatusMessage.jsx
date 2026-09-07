function StatusMessage({ error, message }) {
    return (
        <>
            {error && <div className="alert alert-danger">{error}</div>}
            {message && <div className="alert alert-success">{message}</div>}
        </>
    );
}

export default StatusMessage;

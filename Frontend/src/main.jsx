import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";


// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";

// Bootstrap JS (for dropdowns, collapse, etc.)
import "bootstrap/dist/js/bootstrap.bundle.min.js";

import AuthProvider from "./context/AuthContext.jsx";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>
);
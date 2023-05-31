import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";

const CompanyEditModal = ({ isOpen, onClose, company, onUpdate }) => {
    const [name, setName] = useState(company.name);
    const [url, setUrl] = useState(company.url);
    const [contactPhone, setContactPhone] = useState(company.contactPhone);
    const [contactEmail, setContactEmail] = useState(company.contactEmail);

    const handleUpdate = () => {
        onUpdate(company.id, name, url, contactPhone, contactEmail);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Edit Company Modal"
        >
            <h3>Edit Company</h3>
            <TextField
                label="Name"
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label="URL"
                variant="outlined"
                fullWidth
                value={url}
                onChange={(e) => setUrl(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label="Contact Phone"
                variant="outlined"
                fullWidth
                value={contactPhone}
                onChange={(e) => setContactPhone(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label="Contact Email"
                variant="outlined"
                fullWidth
                value={contactEmail}
                onChange={(e) => setContactEmail(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleUpdate}>
                Update
            </Button>
            <Button variant="contained" color="secondary" onClick={onClose}>
                Cancel
            </Button>
        </Modal>
    );
};

export default CompanyEditModal;

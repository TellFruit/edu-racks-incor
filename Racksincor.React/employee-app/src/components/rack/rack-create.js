import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";

const RackCreateModal = ({ isOpen, onClose, onCreate }) => {
    const [name, setName] = useState("");

    const handleCreate = () => {
        onCreate(name);
        setName("");
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Create Rack Modal"
        >
            <h3>Create Rack</h3>
            <TextField
                label="Name"
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleCreate}>
                Create
            </Button>
            <Button
                variant="contained"
                color="secondary"
                onClick={onClose}
                sx={{ ml: 2 }}
            >
                Cancel
            </Button>
        </Modal>
    );
};

export default RackCreateModal;

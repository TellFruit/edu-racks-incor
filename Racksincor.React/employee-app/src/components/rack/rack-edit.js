import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";

const RackEditModal = ({ isOpen, onClose, rack, onUpdate }) => {
    const [name, setName] = useState(rack.name);

    const handleUpdate = () => {
        onUpdate(rack.id, name);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Edit Rack Modal"
        >
            <h3>Edit Rack</h3>
            <TextField
                label="Name"
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleUpdate}>
                Update
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

export default RackEditModal;

import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";

const ShopCreateModal = ({ isOpen, onClose, onCreate }) => {
    const [name, setName] = useState("");
    const [address, setAddress] = useState("");

    const handleCreate = () => {
        onCreate(name, address);
        setName("");
        setAddress("");
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Create Shop Modal"
        >
            <h3>Create Shop</h3>
            <TextField
                label="Name"
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label="Address"
                variant="outlined"
                fullWidth
                value={address}
                onChange={(e) => setAddress(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleCreate}>
                Create
            </Button>
            <Button variant="contained" color="secondary" onClick={onClose} sx={{ ml: 2 }}>
                Cancel
            </Button>
        </Modal>
    );
};

export default ShopCreateModal;

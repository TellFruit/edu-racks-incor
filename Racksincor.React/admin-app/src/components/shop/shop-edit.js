import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";

const ShopEditModal = ({ isOpen, onClose, shop, onUpdate }) => {
    const [name, setName] = useState(shop.name);
    const [address, setAddress] = useState(shop.address);

    const handleUpdate = () => {
        onUpdate(shop.id, name, address);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Edit Shop Modal"
        >
            <h3>Edit Shop</h3>
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
            <Button variant="contained" color="primary" onClick={handleUpdate}>
                Update
            </Button>
            <Button variant="contained" color="secondary" onClick={onClose}>
                Cancel
            </Button>
        </Modal>
    );
};

export default ShopEditModal;

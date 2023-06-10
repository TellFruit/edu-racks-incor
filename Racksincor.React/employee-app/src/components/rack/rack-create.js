import React, { useState } from "react";
import { Container, Button, TextField, Box } from "@mui/material";
import Modal from "react-modal";
import i18n from "../../i18n/i18n";

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
            contentLabel={i18n.t("rackCreateModal.titleLabel")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{i18n.t("rackCreateModal.titleLabel")}</h3>
                    <TextField
                        label={i18n.t("rackCreateModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleCreate}
                    >
                        {i18n.t("rackCreateModal.createButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {i18n.t("rackCreateModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default RackCreateModal;

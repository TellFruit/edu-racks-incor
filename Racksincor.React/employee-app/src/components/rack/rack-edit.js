import React, { useState } from "react";
import { Container, Button, TextField, Box } from "@mui/material";
import Modal from "react-modal";
import i18n from "../../i18n/i18n";

const RackEditModal = ({ isOpen, onClose, rack, onUpdate }) => {
    const [name, setName] = useState(rack.name);

    const handleUpdate = () => {
        onUpdate(rack.id, name);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel={i18n.t("editRackModal.titleLabel")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{i18n.t("editRackModal.titleLabel")}</h3>
                    <TextField
                        label={i18n.t("editRackModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        {i18n.t("editRackModal.updateButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {i18n.t("editRackModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default RackEditModal;

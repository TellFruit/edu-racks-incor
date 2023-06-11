import React, { useState } from "react";
import { Container, Button, TextField, Box } from "@mui/material";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const RackEditModal = ({ isOpen, onClose, rack, onUpdate }) => {
    const { t } = useTranslation();
    const [name, setName] = useState(rack.name);

    const handleUpdate = () => {
        onUpdate(rack.id, name);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel={t("editRackModal.titleLabel")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("editRackModal.titleLabel")}</h3>
                    <TextField
                        label={t("editRackModal.nameLabel")}
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
                        {t("editRackModal.updateButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("editRackModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default RackEditModal;

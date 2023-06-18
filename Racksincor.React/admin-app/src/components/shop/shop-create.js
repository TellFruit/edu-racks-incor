import React, { useState } from "react";
import { Container, Box, TextField, Button } from "@mui/material";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const ShopCreateModal = ({ isOpen, onClose, onCreate }) => {
    const { t } = useTranslation();
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
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("shopCreateModal.createShop")}</h3>
                    <TextField
                        label={t("shopCreateModal.name")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("shopCreateModal.address")}
                        variant="outlined"
                        fullWidth
                        value={address}
                        onChange={(e) => setAddress(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleCreate}
                    >
                        {t("shopCreateModal.create")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("shopCreateModal.cancel")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default ShopCreateModal;

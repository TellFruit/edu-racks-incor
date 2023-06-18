import React, { useState } from "react";
import { Container, Box, TextField, Button } from "@mui/material";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const CompanyEditModal = ({ isOpen, onClose, company, onUpdate }) => {
    const { t } = useTranslation();
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
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("companyEditModal.editCompany")}</h3>
                    <TextField
                        label={t("companyEditModal.name")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("companyEditModal.url")}
                        variant="outlined"
                        fullWidth
                        value={url}
                        onChange={(e) => setUrl(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("companyEditModal.contactPhone")}
                        variant="outlined"
                        fullWidth
                        value={contactPhone}
                        onChange={(e) => setContactPhone(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("companyEditModal.contactEmail")}
                        variant="outlined"
                        fullWidth
                        value={contactEmail}
                        onChange={(e) => setContactEmail(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        {t("companyEditModal.update")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("companyEditModal.cancel")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default CompanyEditModal;

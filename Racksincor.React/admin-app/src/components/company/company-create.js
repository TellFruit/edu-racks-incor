import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const CompanyCreateModal = ({ isOpen, onClose, onCreate }) => {
    const { t } = useTranslation();
    const [name, setName] = useState("");
    const [url, setUrl] = useState("");
    const [contactPhone, setContactPhone] = useState("");
    const [contactEmail, setContactEmail] = useState("");

    const handleCreate = () => {
        onCreate(name, url, contactPhone, contactEmail);
        setName("");
        setUrl("");
        setContactPhone("");
        setContactEmail("");
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Create Company Modal"
        >
            <h3>{t("companyCreateModal.createCompany")}</h3>
            <TextField
                label={t("companyCreateModal.name")}
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label={t("companyCreateModal.url")}
                variant="outlined"
                fullWidth
                value={url}
                onChange={(e) => setUrl(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label={t("companyCreateModal.contactPhone")}
                variant="outlined"
                fullWidth
                value={contactPhone}
                onChange={(e) => setContactPhone(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label={t("companyCreateModal.contactEmail")}
                variant="outlined"
                fullWidth
                value={contactEmail}
                onChange={(e) => setContactEmail(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleCreate}>
                {t("companyCreateModal.create")}
            </Button>
            <Button
                variant="contained"
                color="secondary"
                onClick={onClose}
                sx={{ ml: 2 }}
            >
                {t("companyCreateModal.cancel")}
            </Button>
        </Modal>
    );
};

export default CompanyCreateModal;

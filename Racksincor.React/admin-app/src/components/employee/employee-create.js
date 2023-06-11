import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import { useTranslation } from "react-i18next";

const EmployeeCreateModal = ({ isOpen, onClose, onCreate }) => {
    const { t } = useTranslation();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [passwordConfirm, setPasswordConfirm] = useState("");

    const handleCreate = () => {
        onCreate(email, password, passwordConfirm);
        setEmail("");
        setPassword("");
        setPasswordConfirm("");
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Create User Modal"
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("employeeCreateModal.createEmployee")}</h3>
                    <TextField
                        label={t("employeeCreateModal.email")}
                        variant="outlined"
                        fullWidth
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("employeeCreateModal.password")}
                        variant="outlined"
                        fullWidth
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("employeeCreateModal.confirmPassword")}
                        variant="outlined"
                        fullWidth
                        value={passwordConfirm}
                        onChange={(e) => setPasswordConfirm(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleCreate}
                    >
                        {t("employeeCreateModal.create")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("employeeCreateModal.cancel")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default EmployeeCreateModal;

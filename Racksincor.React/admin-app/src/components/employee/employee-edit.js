import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import { useTranslation } from "react-i18next";

const EmployeeEditModal = ({ isOpen, onClose, employee, onUpdate }) => {
    const { t } = useTranslation();
    const [email, setEmail] = useState(employee.email);
    const [password, setPassword] = useState("");
    const [passwordConfirm, setPasswordConfirm] = useState("");

    const handleUpdate = () => {
        onUpdate(employee.id, email, password, passwordConfirm);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Edit Employee Modal"
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("employeeEditModal.editEmployee")}</h3>
                    <TextField
                        label={t("employeeEditModal.email")}
                        variant="outlined"
                        fullWidth
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("employeeEditModal.password")}
                        variant="outlined"
                        fullWidth
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("employeeEditModal.confirmPassword")}
                        variant="outlined"
                        fullWidth
                        value={passwordConfirm}
                        onChange={(e) => setPasswordConfirm(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        {t("employeeEditModal.update")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("employeeEditModal.cancel")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default EmployeeEditModal;

import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const ShopEditModal = ({ isOpen, onClose, shop, onUpdate }) => {
    const { t } = useTranslation();
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
            <h3>{t("shopEditModal.editShop")}</h3>
            <TextField
                label={t("shopEditModal.name")}
                variant="outlined"
                fullWidth
                value={name}
                onChange={(e) => setName(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <TextField
                label={t("shopEditModal.address")}
                variant="outlined"
                fullWidth
                value={address}
                onChange={(e) => setAddress(e.target.value)}
                sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleUpdate}>
                {t("shopEditModal.update")}
            </Button>
            <Button
                variant="contained"
                color="secondary"
                onClick={onClose}
                sx={{ ml: 2 }}
            >
                {t("shopEditModal.cancel")}
            </Button>
        </Modal>
    );
};

export default ShopEditModal;

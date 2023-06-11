import React, { useState } from "react";
import {
    Container,
    Button,
    TextField,
    Box,
    FormControlLabel,
    Checkbox,
} from "@mui/material";
import Modal from "react-modal";
import { useTranslation } from "react-i18next";

const ProductCreateModal = ({ isOpen, onClose, onCreate }) => {
    const { t } = useTranslation();
    const [name, setName] = useState("");
    const [price, setPrice] = useState("");
    const [isInStock, setIsInStock] = useState(true);

    const handleCreate = () => {
        onCreate(name, price, isInStock);
        setName("");
        setPrice("");
        setIsInStock(true);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel={t("createProductModal.title")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("createProductModal.title")}</h3>
                    <TextField
                        label={t("createProductModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={t("createProductModal.priceLabel")}
                        variant="outlined"
                        fullWidth
                        value={price}
                        onChange={(e) => setPrice(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <FormControlLabel
                        control={
                            <Checkbox
                                checked={isInStock}
                                onChange={(e) => setIsInStock(e.target.checked)}
                            />
                        }
                        label={t("createProductModal.isInStockLabel")}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleCreate}
                    >
                        {t("createProductModal.createButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("createProductModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default ProductCreateModal;

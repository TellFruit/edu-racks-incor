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
import i18n from "../../i18n/i18n";

const ProductEditModal = ({ isOpen, onClose, product, onUpdate }) => {
    const [name, setName] = useState(product.name);
    const [price, setPrice] = useState(product.price);
    const [isInStock, setIsInStock] = useState(product.isInStock);

    const handleUpdate = () => {
        onUpdate(product.id, name, price, isInStock);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel={i18n.t("editProductModal.title")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{i18n.t("editProductModal.title")}</h3>
                    <TextField
                        label={i18n.t("editProductModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label={i18n.t("editProductModal.priceLabel")}
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
                        label={i18n.t("editProductModal.isInStockLabel")}
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        {i18n.t("editProductModal.updateButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {i18n.t("editProductModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default ProductEditModal;

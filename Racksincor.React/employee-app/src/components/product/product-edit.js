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
            contentLabel="Edit Product Modal"
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>Edit Product</h3>
                    <TextField
                        label="Name"
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label="Price"
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
                        label="Is In Stock"
                        sx={{ marginBottom: 2 }}
                    />
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        Update
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        Cancel
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default ProductEditModal;

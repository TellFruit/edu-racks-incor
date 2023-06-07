import React from "react";
import {
    Table,
    TableContainer,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
} from "@mui/material";
import Button from "@mui/material/Button";

const ProductActionTable = ({ products, onActionClick, actionText }) => {
    return (
        <TableContainer sx={{ height: 400, maxHeight: 400 }}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Name</TableCell>
                        <TableCell align="center">Action</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {products.map((product) => (
                        <TableRow key={product.id}>
                            <TableCell>{product.name}</TableCell>
                            <TableCell align="center">
                                <Button
                                    variant="outlined"
                                    onClick={() => onActionClick(product)}
                                >
                                    {actionText}
                                </Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default ProductActionTable;

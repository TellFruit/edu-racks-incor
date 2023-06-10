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
import i18n from "../../i18n/i18n";

const ProductActionTable = ({ products, onActionClick, actionText }) => {
    return (
        <TableContainer sx={{ height: 400, maxHeight: 400 }}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>{i18n.t("productTable.name")}</TableCell>
                        <TableCell align="center">
                            {i18n.t("productTable.action")}
                        </TableCell>
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

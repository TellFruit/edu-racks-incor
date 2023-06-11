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
import { useTranslation } from "react-i18next";

const ProductActionTable = ({ products, onActionClick, actionText }) => {
    const { t } = useTranslation();
    
    return (
        <TableContainer sx={{ height: 400, maxHeight: 400 }}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>{t("productTable.name")}</TableCell>
                        <TableCell align="center">
                            {t("productTable.action")}
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

import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";
import { useTranslation } from "react-i18next";

const CompanyList = ({ companies, onDelete, onOpenEditModal, onViewShops }) => {
    const { t } = useTranslation();
    const [page, setPage] = useState(1);
    const companiesPerPage = 5;
    const totalPages = Math.ceil(companies.length / companiesPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * companiesPerPage;
    const endIndex = startIndex + companiesPerPage;
    const displayedCompanies = companies.slice(startIndex, endIndex);

    return (
        <div>
            {displayedCompanies.map((company) => (
                <div key={company.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>
                                        {t("companyList.name")}: {company.name}
                                    </p>
                                    <p>
                                        {t("companyList.url")}: {company.url}
                                    </p>
                                    <p>
                                        {t("companyList.contactPhone")}:{" "}
                                        {company.contactPhone}
                                    </p>
                                    <p>
                                        {t("companyList.contactEmail")}:{" "}
                                        {company.contactEmail}
                                    </p>
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <Box display="flex" justifyContent="flex-end">
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onOpenEditModal(company)}
                                    >
                                        {t("companyList.update")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => onDelete(company.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("companyList.delete")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onViewShops(company.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("companyList.viewShops")}
                                    </Button>
                                </Box>
                            </Grid>
                        </Grid>
                    </Paper>
                </div>
            ))}
            <Pagination
                count={totalPages}
                page={page}
                onChange={handlePageChange}
                color="primary"
                size="large"
                showFirstButton
                showLastButton
            />
        </div>
    );
};

export default CompanyList;

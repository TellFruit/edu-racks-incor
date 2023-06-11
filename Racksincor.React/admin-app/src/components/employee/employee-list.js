import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";
import { useTranslation } from "react-i18next";

const EmployeeList = ({ employees, onDelete, onOpenEditModal }) => {
    const { t } = useTranslation();
    const [page, setPage] = useState(1);
    const employeesPerPage = 5;
    const totalPages = Math.ceil(employees.length / employeesPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * employeesPerPage;
    const endIndex = startIndex + employeesPerPage;
    const displayedemployees = employees.slice(startIndex, endIndex);

    return (
        <div>
            {displayedemployees.map((employee) => (
                <div key={employee.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>
                                        {t("employeeList.email")}:{" "}
                                        {employee.email}
                                    </p>
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <div
                                    style={{
                                        display: "flex",
                                        justifyContent: "flex-end",
                                    }}
                                >
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() =>
                                            onOpenEditModal(employee)
                                        }
                                    >
                                        {t("employeeList.update")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => onDelete(employee.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("employeeList.delete")}
                                    </Button>
                                </div>
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

export default EmployeeList;

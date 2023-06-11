import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "../api/instance";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import EmployeeList from "../components/employee/employee-list";
import EmployeeCreateModal from "../components/employee/employee-create";
import EmployeeEditModal from "../components/employee/employee-edit";
import { getToken } from "../api/token";
import { useTranslation } from "react-i18next";

const EmployeePage = () => {
    const token = getToken();
    const { shopId } = useParams();
    const [shop, setShop] = useState(null);
    const [employees, setEmployees] = useState([]);
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedEmployee, setSelectedEmployee] = useState(null);
    const { t } = useTranslation();

    useEffect(() => {
        fetchShop();
        fetchEmployees();
    }, []);

    const fetchShop = async () => {
        try {
            const response = await axios.get(`/shop/${shopId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setShop(response.data[0]);
        } catch (error) {
            console.error("Error fetching shop:", error);
        }
    };

    const fetchEmployees = async () => {
        try {
            const response = await axios.get(`/employee/shop/${shopId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setEmployees(response.data);
        } catch (error) {
            console.error("Error fetching employees:", error);
        }
    };

    const handleCreate = async (email, password, passwordConfirm) => {
        try {
            const response = await axios.post(
                `/auth/register`,
                {
                    email,
                    password,
                    passwordConfirm,
                    role: "Employee",
                    shopId: shopId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const createdEmployee = response.data;
            setEmployees((prevEmployees) => [
                ...prevEmployees,
                createdEmployee,
            ]);
            closeCreateModal();
        } catch (error) {
            console.error("Error creating employee:", error);
        }
    };

    const handleUpdate = async (id, email, password, passwordConfirm) => {
        try {
            const response = await axios.put(
                `/user/${id}`,
                {
                    email,
                    password,
                    passwordConfirm,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const updatedEmployee = response.data;
            setEmployees((prevEmployees) =>
                prevEmployees.map((employee) =>
                    employee.id === updatedEmployee.id
                        ? updatedEmployee
                        : employee
                )
            );
            closeEditModal();
        } catch (error) {
            console.error("Error updating employee:", error);
        }
    };

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/user/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setEmployees((prevEmployees) =>
                prevEmployees.filter((employee) => employee.id !== id)
            );
        } catch (error) {
            console.error("Error deleting employee:", error);
        }
    };

    const openCreateModal = () => {
        setCreateModalIsOpen(true);
    };

    const closeCreateModal = () => {
        setCreateModalIsOpen(false);
    };

    const openEditModal = (employee) => {
        setSelectedEmployee(employee);
        setEditModalIsOpen(true);
    };

    const closeEditModal = () => {
        setSelectedEmployee(null);
        setEditModalIsOpen(false);
    };

    return (
        <Container maxWidth="md">
            <Box sx={{ mt: 8 }}>
                <h2>{t("employeePage.title", { shopName: shop?.name })}</h2>
                <div>
                    <h3>{t("employeePage.createEmployee")}</h3>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={openCreateModal}
                    >
                        {t("employeePage.createButton")}
                    </Button>
                    <EmployeeCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreate={handleCreate}
                    />
                </div>
                <div>
                    <h3>{t("employeePage.employeeList")}</h3>
                    <EmployeeList
                        employees={employees}
                        onDelete={handleDelete}
                        onOpenEditModal={openEditModal}
                    />
                    {selectedEmployee && (
                        <EmployeeEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            employee={selectedEmployee}
                            onUpdate={handleUpdate}
                        />
                    )}
                </div>
            </Box>
        </Container>
    );
};

export default EmployeePage;

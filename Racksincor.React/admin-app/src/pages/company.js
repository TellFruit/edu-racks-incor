import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from '../api/instance';
import { getToken } from '../api/token';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';
import CompanyList from '../components/company/company-list';
import CompanyCreateModal from '../components/company/company-create';
import CompanyEditModal from '../components/company/company-edit';

const CompanyPage = () => {
  const token = getToken();
  const [companies, setCompanies] = useState([]);
  const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
  const [editModalIsOpen, setEditModalIsOpen] = useState(false);
  const [selectedCompany, setSelectedCompany] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetchCompanies();
  }, []);

  const fetchCompanies = async () => {
    try {
      const response = await axios.get('/company', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      setCompanies(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const handleCreate = async (name, url, contactPhone, contactEmail) => {
    try {
      const response = await axios.post(
        '/company',
        {
          name,
          url,
          contactPhone,
          contactEmail,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      if (response.status === 200) {
        fetchCompanies();
        setCreateModalIsOpen(false);
      } else {
        console.error('Create operation failed');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleUpdate = async (id, name, url, contactPhone, contactEmail) => {
    try {
      const response = await axios.put(
        `/company/${id}`,
        {
          name,
          url,
          contactPhone,
          contactEmail,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      if (response.status === 200) {
        fetchCompanies();
        setEditModalIsOpen(false);
      } else {
        console.error('Update operation failed');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/company/${id}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      fetchCompanies();
    } catch (error) {
      console.error(error);
    }
  };

  const handleViewShops = (companyId) => {
    navigate(`/company/${companyId}/shops`);
  };

  const openCreateModal = () => {
    setCreateModalIsOpen(true);
  };

  const closeCreateModal = () => {
    setCreateModalIsOpen(false);
  };

  const openEditModal = (company) => {
    setSelectedCompany(company);
    setEditModalIsOpen(true);
  };

  const closeEditModal = () => {
    setEditModalIsOpen(false);
  };

  return (
    <Container maxWidth="md">
      <Box sx={{ mt: 8 }}>
        <h2>Company Page</h2>
        <div>
          <h3>Create Company</h3>
          <Button variant="contained" color="primary" onClick={openCreateModal}>
            Create
          </Button>
          <CompanyCreateModal
            isOpen={createModalIsOpen}
            onClose={closeCreateModal}
            onCreate={handleCreate}
          />
        </div>
        <div>
          <h3>Company List</h3>
          <CompanyList
            companies={companies}
            onDelete={handleDelete}
            onOpenEditModal={openEditModal}
            onViewShops={handleViewShops}
          />
          {selectedCompany && (
            <CompanyEditModal
              isOpen={editModalIsOpen}
              onClose={closeEditModal}
              company={selectedCompany}
              onUpdate={handleUpdate}
            />
          )}
        </div>
      </Box>
    </Container>
  );
};

export default CompanyPage;

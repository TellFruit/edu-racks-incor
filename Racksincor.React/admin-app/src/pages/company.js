import React, { useState, useEffect } from 'react';
import axios from '../api/instance';
import { getToken } from '../api/token';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';

const token = getToken()

const CompanyPage = () => {
  const [companies, setCompanies] = useState([]);
  const [name, setName] = useState('');
  const [url, setUrl] = useState('');
  const [contactPhone, setContactPhone] = useState('');
  const [contactEmail, setContactEmail] = useState('');

  useEffect(() => {
    fetchCompanies();
  }, []);

  const fetchCompanies = async () => {
    try {
      const response = await axios.get('/company',
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      setCompanies(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const handleCreate = async () => {
    try {
      const response = await axios.post('/company', {
        name,
        url,
        contactPhone,
        contactEmail
      },
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      if (response.status === 200) {
        fetchCompanies();
      } else {
        console.error('Create operation failed');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleUpdate = async (id) => {
    try {
      const response = await axios.put(`/company/${id}`, {
        name,
        url,
        contactPhone,
        contactEmail
      },
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      if (response.status === 200) {
        fetchCompanies();
      } else {
        console.error('Update operation failed');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/company/${id}`);
      fetchCompanies();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Container maxWidth="md">
      <Box sx={{ marginTop: 8 }}>
        <h2>Company Page</h2>
        <div>
          <h3>Create Company</h3>
          <TextField
            label="Name"
            variant="outlined"
            fullWidth
            value={name}
            onChange={(e) => setName(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <TextField
            label="URL"
            variant="outlined"
            fullWidth
            value={url}
            onChange={(e) => setUrl(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <TextField
            label="Contact Phone"
            variant="outlined"
            fullWidth
            value={contactPhone}
            onChange={(e) => setContactPhone(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <TextField
            label="Contact Email"
            variant="outlined"
            fullWidth
            value={contactEmail}
            onChange={(e) => setContactEmail(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <Button variant="contained" color="primary" onClick={handleCreate}>
            Create
          </Button>
        </div>
        <div>
          <h3>Company List</h3>
          {companies.map((company) => (
            <div key={company.id}>
              <p>Name: {company.name}</p>
              <p>URL: {company.url}</p>
              <p>Contact Phone: {company.contactPhone}</p>
              <p>Contact Email: {company.contactEmail}</p>
              <Button variant="contained" color="primary" onClick={() => handleUpdate(company.id)}>
                Update
              </Button>
              <Button variant="contained" color="secondary" onClick={() => handleDelete(company.id)}>
                Delete
              </Button>
              <hr />
            </div>
          ))}
        </div>
      </Box>
    </Container>
  );
};

export default CompanyPage;

import { useFormik } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import { useHistory, useParams } from 'react-router-dom';
import React, { useEffect } from 'react';
import { GetCategoryService, UpdateCategoryService } from '../../../service/admin/CategoryService';

const UpdateCategoryPage = () => {
  const formik = useFormik({
    initialValues: {
      id: '',
      name: '',
    },
    onSubmit: (values, { setSubmitting }) => {
      if (values.name === '') {
        setSubmitting(false);
        return;
      }
      UpdateCategoryService({ name: values.name, id: values.id })
        .then(function (response) {
          // handle success
          history.push(`/categories`);
        })
        .catch(function (error) {
          // handle error
          console.log(error);
          setSubmitting(false);
        })
    },
    isSubmitting: false,
  })
  const history = useHistory();
  const { categoryID } = useParams();

  useEffect(() => {
    let didCancel = false;
    GetCategoryService(categoryID)
      .then(function (response) {
        if (!didCancel) {
          formik.setFieldValue("id", response.data.id);
          formik.setFieldValue("name", response.data.name);
        }
      })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
    return () => didCancel = true;
  }, [categoryID]);


  return (
    <Form noValidate onSubmit={formik.handleSubmit}>

      <Form.Group controlId="validationFormikid">
        <InputGroup>
          <Form.Control
            type="hidden"
            name="id"
            value={formik.values.id}
          />
        </InputGroup>
      </Form.Group>

      <Row className="mb-3">
        <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormikname">
          <Form.Label>Name Category</Form.Label>
          <InputGroup hasValidation>
            <Form.Control
              type="text"
              placeholder="Name Category"
              aria-describedby="inputGroupPrepend"
              name="name"
              value={formik.values.name}
              onChange={formik.handleChange}
            />
          </InputGroup>
        </Form.Group>
      </Row>

      <Row className="mb-3">
        <Col sm={3}>
          <Button type="submit" variant="primary" disabled={formik.isSubmitting}>Update Category</Button>
        </Col>
      </Row>
    </Form>
  )
}

export default UpdateCategoryPage;
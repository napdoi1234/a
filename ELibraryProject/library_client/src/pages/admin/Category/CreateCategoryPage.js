import { Formik, } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';
import * as yup from 'yup';
import React from 'react';
import { CreateCategoryService } from './../../../service/admin/CategoryService';

const schema = yup.object().shape({
  name: yup.string().required(),
});

const initialValues = {
  name: '',
}

const CreateCategoryPage = () => {
  const history = useHistory();

  const handleCreate = (values, { setSubmitting }) => {
    CreateCategoryService({ name: values.name }).then(function (response) {
      // handle success
      history.push(`/categories`);
    })
      .catch(function (error) {
        // handle error
        console.log(error);
        setSubmitting(false);
      })
  }

  return (
    <>
      <Formik
        validationSchema={schema}
        onSubmit={handleCreate}
        initialValues={initialValues}
      >
        {({
          handleSubmit,
          handleChange,
          handleBlur,
          values,
          errors,
          touched,
          isSubmitting,
        }) => (
          <Form noValidate onSubmit={handleSubmit}>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormikname">
                <Form.Label>Name Category</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="text"
                    placeholder="Name Category"
                    aria-describedby="inputGroupPrepend"
                    name="name"
                    value={values.name}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isInvalid={touched.name && errors.name}
                  />
                  <Form.Control.Feedback type="invalid">
                    {errors.name}
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
            </Row>
            <Row className="mb-3">
              <Col sm={3}>
                <Button type="submit" variant="primary" disabled={isSubmitting}>Create Category</Button>
              </Col>
            </Row>
          </Form>
        )}
      </Formik>
    </>
  )
}

export default CreateCategoryPage;
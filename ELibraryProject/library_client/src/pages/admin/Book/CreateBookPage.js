import { Formik, } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';
import * as yup from 'yup';
import { CreateBookService } from '../../../service/admin/BookService';
import React from 'react';

const schema = yup.object().shape({
  name: yup.string().required(),
  author: yup.string(),
});

const initialValues = {
  name: '',
  author: '',
}

const CreateBookPage = () => {
  const history = useHistory();

  const handleCreate = (values, { setSubmitting }) => {
    CreateBookService({ nameBook: values.name, author: values.author }).then(function (response) {
      // handle success
      history.push(`/books`);
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
              <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormikUsername">
                <Form.Label>Name Book</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="text"
                    placeholder="Name Book"
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
              <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormik03">
                <Form.Label>Author</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="text"
                    placeholder="Author"
                    name="author"
                    value={values.author}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isInvalid={touched.author && errors.author}
                  />

                  <Form.Control.Feedback type="invalid">
                    {errors.author}
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
            </Row>
            <Row className="mb-3">
              <Col sm={3}>
                <Button type="submit" variant="primary" disabled={isSubmitting}>Create Book</Button>
              </Col>
            </Row>
          </Form>
        )}
      </Formik>
    </>
  )
}

export default CreateBookPage;
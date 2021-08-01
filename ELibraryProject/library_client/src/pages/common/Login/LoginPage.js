import { Formik, } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import * as yup from 'yup';
import React, { useContext } from 'react';
import CurrentUserContext from '../../../contexts/CurrentUserContext';
import LoginService from '../../../service/common/LoginService';
import { useHistory } from 'react-router-dom';

const schema = yup.object().shape({
  user: yup.string().required(),
  password: yup.string().required(),
});

const initialValues = {
  user: '',
  password: '',
}
const LoginPage = () => {
  const { setCurrentUser } = useContext(CurrentUserContext);
  const history = useHistory();

  const handleLogin = (values, { setSubmitting }) => {
    LoginService({ user: values.user, password: values.password }).then(function (response) {
      // handle success
      setCurrentUser({
        token: response.data.token,
        role: response.data.role,
      });
      window.localStorage.setItem('token', response.data.token);
      window.localStorage.setItem('role', response.data.role);
      history.push('/books');
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
        onSubmit={handleLogin}
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
                <Form.Label>User Name</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="text"
                    placeholder="User Name"
                    aria-describedby="inputGroupPrepend"
                    name="user"
                    value={values.user}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isInvalid={touched.user && errors.user}
                  />
                  <Form.Control.Feedback type="invalid">
                    {errors.user}
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
            </Row>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormik03">
                <Form.Label>Password</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="password"
                    placeholder="Password"
                    name="password"
                    value={values.password}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isInvalid={touched.password && errors.password}
                  />

                  <Form.Control.Feedback type="invalid">
                    {errors.password}
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
            </Row>
            <Row className="mb-3">
              <Col sm={3}>
                <Button type="submit" variant="primary" disabled={isSubmitting}>Login</Button>
              </Col>
            </Row>
          </Form>
        )}
      </Formik>
    </>
  )
}
export default LoginPage;
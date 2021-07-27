import { Formik, } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import * as yup from 'yup';

const schema = yup.object().shape({
  user: yup.string().required(),
  password: yup.string().required(),
});

const initialValues = {
  user: '',
  password: '',
}
const LoginPage = () => {
  return (
    <>
      <Formik
        validationSchema={schema}
        onSubmit={console.log}
        initialValues={initialValues}
      >
        {({
          handleSubmit,
          handleChange,
          values,
          errors,
        }) => (
          <Form noValidate onSubmit={handleSubmit}>
            <Row className="mb-3">
              <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormikUsername">
                <Form.Label>Email</Form.Label>
                <InputGroup hasValidation>
                  <Form.Control
                    type="email"
                    placeholder="Email"
                    aria-describedby="inputGroupPrepend"
                    name="email"
                    value={values.email}
                    onChange={handleChange}
                    isInvalid={!!errors.email}
                  />
                  <Form.Control.Feedback type="invalid">
                    {errors.email}
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
                    isInvalid={!!errors.password}
                  />

                  <Form.Control.Feedback type="invalid">
                    {errors.password}
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
            </Row>
            <Button type="submit" variant="primary">Submit form</Button>
          </Form>
        )}
      </Formik>
    </>
  )
}
export default LoginPage;
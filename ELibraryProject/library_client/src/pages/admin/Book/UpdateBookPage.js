import { useFormik } from 'formik';
import { Form, Button, InputGroup, Row, Col } from 'react-bootstrap';
import { useHistory, useParams } from 'react-router-dom';
import { GetBookService, UpdateBookService } from '../../../service/admin/BookService';
import React, { useEffect } from 'react';
import CategoryConstant from './../../../shared/constants/CategoryConstant';
import { GetCategoriesService } from './../../../service/admin/CategoryService';

const UpdateBookPage = () => {
  const formik = useFormik({
    initialValues: {
      id: '',
      name: '',
      author: '',
      categoryID: [{
        id: '',
        name: '',
      }],
      categoryList: [{
        id: '',
        name: '',
      }]
    },
    onSubmit: (values, { setSubmitting }) => {
      if (values.category === undefined) values.category = [];
      if (values.name === '') {
        setSubmitting(false);
        return;
      }
      UpdateBookService({ name: values.name, author: values.author, categoryID: values.category, id: values.id })
        .then(function (response) {
          // handle success
          history.push(`/books`);
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
  const { bookId } = useParams();

  useEffect(() => {
    let didCancel = false;
    GetBookService(bookId)
      .then(function (response) {
        if (!didCancel) {
          formik.setFieldValue("id", response.data.id);
          formik.setFieldValue("name", response.data.name);
          formik.setFieldValue("author", response.data.author !== null ? response.data.author : '');
          formik.setFieldValue("categoryID", response.data.categoryID.length === 0
            ? [1] : response.data.categoryID);

          GetCategoriesService(CategoryConstant.pageIndex, CategoryConstant.GetAllSize).then(function (response) {
            formik.setFieldValue("categoryList", response.data.items);
          })
            .catch(function (error) {
              // handle error
              console.log(error);
            })
        }
      })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
    return () => didCancel = true;
  }, [bookId]);


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
        <Form.Group as={Col} md="3" className="mb-3" controlId="validationFormikUsername">
          <Form.Label>Name Book</Form.Label>
          <InputGroup hasValidation>
            <Form.Control
              type="text"
              placeholder="Name Book"
              aria-describedby="inputGroupPrepend"
              name="name"
              value={formik.values.name}
              onChange={formik.handleChange}
            />
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
              value={formik.values.author}
              onChange={formik.handleChange}
            />
          </InputGroup>
        </Form.Group>
      </Row>

      <Row className="mb-3">
        <fieldset>
          <Form.Group as={Row} className="mb-3">
            <Form.Label as="legend" column sm={2}>
              Categories of book
            </Form.Label>
            <Col sm={1}>
              {formik.values.categoryList.map(category => {
                return (
                  <Form.Check
                    type="checkbox"
                    key={category.id}
                    label={category.name}
                    value={category.id}
                    id={category.id}
                    defaultChecked={formik.values.categoryID.includes(category.id) ? true : false}
                    name="category"
                    onChange={formik.handleChange}
                  />
                )
              })
              }
            </Col>
          </Form.Group>
        </fieldset>
      </Row>
      <Row className="mb-3">
        <Col sm={3}>
          <Button type="submit" variant="primary" disabled={formik.isSubmitting}>Update Book</Button>
        </Col>
      </Row>
    </Form>
  )
}

export default UpdateBookPage;
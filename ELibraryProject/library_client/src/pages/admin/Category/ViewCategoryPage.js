import React, { useState, useEffect } from 'react';
import { Table, Button, Modal } from 'react-bootstrap';
import { Link, useHistory } from "react-router-dom";
import Paging from '../../common/Pagination/Pagination';
import { DeleteCatgoryService, GetCategoriesService } from './../../../service/admin/CategoryService';
import CategoryConstant from './../../../shared/constants/CategoryConstant';

const ViewCategoryPage = () => {
  const [categories, setCategories] = useState();
  const [modeOrder, setModeOrder] = useState(CategoryConstant.NoneOrder);
  const [pageIndex, setPageIndex] = useState(CategoryConstant.PageIndex);
  const [show, setShow] = useState(false);
  const [id, setId] = useState();
  const history = useHistory()

  const handleClose = () => setShow(false);
  const handleDelete = () => {
    DeleteCatgoryService(id).then(function (response) {
      history.go(0);
    })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
  }
  const handleShow = (evt) => {
    setShow(true);
    setId(evt.target.id);
  }

  useEffect(() => {
    let didCancel = false;
    GetCategoriesService(pageIndex, CategoryConstant.PageSize).then(function (response) {
      // handle success
      if (!didCancel) {
        let index = (response.data.pageIndex - 1) * response.data.pageSize
        response.data.items.forEach(x => { x.index = index; index++; });
        setCategories(response.data);
      }
    })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
    return () => didCancel = true
  }, [pageIndex]);


  const OrderCategories = () => {
    if (categories.length !== 0) {
      if (modeOrder === CategoryConstant.NoneOrder) {
        setModeOrder(CategoryConstant.ASCOrder);
        categories.items.sort((a, b) => a.name.localeCompare(b.name));
      }
      else if (modeOrder === CategoryConstant.ASCOrder) {
        setModeOrder(CategoryConstant.DESCOrder);
        categories.items.sort((a, b) => b.name.localeCompare(a.name));
      }
      else {
        setModeOrder(CategoryConstant.NoneOrder);
        categories.items.sort((a, b) => a.index - b.index);
      }
    }
  }

  return (
    <div>
      <Link to={`/category`} style={{ color: 'white', float: 'right', paddingBottom: '10px' }}>
        <Button variant="dark" >Create A New Category</Button>
      </Link>
      {
        categories !== undefined ?
          <div>
            <Table striped bordered hover variant="dark">
              <thead>
                <tr>
                  <th>{CategoryConstant.IdHeader}</th>
                  <th onClick={OrderCategories}>{CategoryConstant.NameHeader} {modeOrder}</th>
                  <th>{CategoryConstant.DetailHeader}</th>
                  <th>{CategoryConstant.ActionHeader}</th>
                </tr>
              </thead>
              <tbody>
                {categories.items.map(category => {
                  return (
                    <tr key={category.id}>
                      <td>{category.index}</td>
                      <td>{category.name}</td>
                      <td >
                        <Link to={`/category/${category.id}`} style={{ color: 'white' }}>{CategoryConstant.DetailField}</Link>
                      </td>
                      <td>
                        <Button variant="dark" onClick={handleShow} id={category.id}>
                          Delete
                        </Button>
                      </td>
                    </tr>
                  )
                })
                }
              </tbody>
            </Table>
            <Paging list={categories} setIndex={setPageIndex} />
          </div>
          :
          <Table striped bordered hover variant="dark">
            <thead>
              <tr>
                <th>{CategoryConstant.IdHeader}</th>
                <th>{CategoryConstant.NameHeader} {modeOrder}</th>
                <th>{CategoryConstant.DetailHeader}</th>
                <th>{CategoryConstant.ActionHeader}</th>
              </tr>
            </thead>
          </Table>
      }
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>Do you want to delete this category({id}) ?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            No
          </Button>
          <Button variant="primary" onClick={handleDelete}>
            Yes
          </Button>
        </Modal.Footer>
      </Modal>

    </div>
  );
}

export default ViewCategoryPage;
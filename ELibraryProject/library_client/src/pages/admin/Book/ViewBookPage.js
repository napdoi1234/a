import React, { useState, useEffect } from 'react';
import { Table, Button, Modal } from 'react-bootstrap';
import BookConstant from '../../../shared/constants/BookConstant';
import { GetBooksService } from '../../../service/admin/BookService';
import { Link, useHistory } from "react-router-dom";
import Paging from '../../common/Pagination/Pagination';
import { DeleteBookService } from '../../../service/admin/BookService';

const ViewBookPage = () => {
  const [books, setBooks] = useState();
  const [modeOrder, setModeOrder] = useState(BookConstant.NoneOrder);
  const [pageIndex, setPageIndex] = useState(BookConstant.PageIndex);
  const [show, setShow] = useState(false);
  const [id, setId] = useState();
  const history = useHistory()

  const handleClose = () => setShow(false);
  const handleDelete = () => {
    DeleteBookService(id).then(function (response) {
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
    GetBooksService(pageIndex).then(function (response) {
      // handle success
      if (!didCancel) {
        let index = (response.data.pageIndex - 1) * response.data.pageSize
        response.data.items.forEach(x => { x.index = index; index++; });
        setBooks(response.data);
      }
    })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
    return () => didCancel = true
  }, [pageIndex]);


  const OrderBooks = () => {
    if (books.length !== 0) {
      if (modeOrder === BookConstant.NoneOrder) {
        setModeOrder(BookConstant.ASCOrder);
        books.items.sort((a, b) => a.name.localeCompare(b.name));
      }
      else if (modeOrder === BookConstant.ASCOrder) {
        setModeOrder(BookConstant.DESCOrder);
        books.items.sort((a, b) => b.name.localeCompare(a.name));
      }
      else {
        setModeOrder(BookConstant.NoneOrder);
        books.items.sort((a, b) => a.index - b.index);
      }
    }
  }

  return (
    <div>
      <Link to={`/book`} style={{ color: 'white', float: 'right', paddingBottom: '10px' }}>
        <Button variant="dark" >Create A New Book</Button>
      </Link>
      {
        books !== undefined ?
          <div>
            <Table striped bordered hover variant="dark">
              <thead>
                <tr>
                  <th>{BookConstant.IdHeader}</th>
                  <th onClick={OrderBooks}>{BookConstant.NameHeader} {modeOrder}</th>
                  <th>{BookConstant.AuthorHeader}</th>
                  <th>{BookConstant.CategoryHeader}</th>
                  <th>{BookConstant.DetailHeader}</th>
                  <th>{BookConstant.ActionHeader}</th>
                </tr>
              </thead>
              <tbody>
                {books.items.map(book => {
                  return (
                    <tr key={book.id}>
                      <td>{book.index}</td>
                      <td>{book.name}</td>
                      <td>{book.author}</td>
                      <td>{book.categoryName.join(' , ')}</td>
                      <td >
                        <Link to={`/book/${book.id}`} style={{ color: 'white' }}>{BookConstant.DetailField}</Link>
                      </td>
                      <td>
                        <Button variant="dark" onClick={handleShow} id={book.id}>
                          Delete
                        </Button>
                      </td>
                    </tr>
                  )
                })
                }
              </tbody>
            </Table>
            <Paging list={books} setIndex={setPageIndex} />
          </div>
          :
          <Table striped bordered hover variant="dark">
            <thead>
              <tr>
                <th>{BookConstant.IdHeader}</th>
                <th>{BookConstant.NameHeader} {modeOrder}</th>
                <th>{BookConstant.AuthorHeader}</th>
                <th>{BookConstant.CategoryHeader}</th>
                <th>{BookConstant.ActionHeader}</th>
              </tr>
            </thead>
          </Table>
      }
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Book</Modal.Title>
        </Modal.Header>
        <Modal.Body>Do you want to delete this book({id}) ?</Modal.Body>
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

export default ViewBookPage;
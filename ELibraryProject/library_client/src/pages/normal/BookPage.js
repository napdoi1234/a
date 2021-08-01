import React, { useState, useEffect } from 'react';
import { Table, Button, Modal } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import Paging from './../common/Pagination/Pagination';
import BookConstant from './../../shared/constants/BookConstant';
import { BorrowBookService, GetBooksService } from '../../service/normal/BookService';

const BookPage = () => {
  const [books, setBooks] = useState();
  const [modeOrder, setModeOrder] = useState(BookConstant.NoneOrder);
  const [pageIndex, setPageIndex] = useState(BookConstant.PageIndex);
  const [show, setShow] = useState(false);
  const [idBooks, setIdBooks] = useState([]);
  const history = useHistory()

  const handleClose = () => setShow(false);
  const handleBorrow = () => {
    BorrowBookService({ idBooks }).then(function (response) {
      history.go(0);
    })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
  }
  const handleShow = () => {
    if (idBooks.length === 0) return;
    setShow(true);
  }

  const handleCheck = (e) => {
    let array = idBooks;
    if (idBooks.length < 5 && e.currentTarget.checked) setIdBooks([...idBooks, e.currentTarget.value]);
    else if (!e.currentTarget.checked) setIdBooks(array.filter(x => x !== e.currentTarget.value));
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
      <Button variant="dark" onClick={handleShow} style={{ float: 'right' }}>Confirm List Borrow</Button>
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
                      <td>
                        {idBooks.length < 5 ?
                          <input
                            id={book.id}
                            value={book.id}
                            name="radio"
                            type="checkbox"
                            onChange={handleCheck}
                          />
                          : idBooks.includes(book.id) ?
                            <input
                              id={book.id}
                              value={book.id}
                              name="radio"
                              type="checkbox"
                              onChange={handleCheck}
                            /> :
                            <input
                              id={book.id}
                              value={book.id}
                              name="radio"
                              type="checkbox"
                              disabled
                            />
                        }
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
          <Modal.Title>Borrow Book</Modal.Title>
        </Modal.Header>
        <Modal.Body>Do you want to borrow those book ?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            No
          </Button>
          <Button variant="primary" onClick={handleBorrow}>
            Yes
          </Button>
        </Modal.Footer>
      </Modal>

    </div>
  );
}

export default BookPage;
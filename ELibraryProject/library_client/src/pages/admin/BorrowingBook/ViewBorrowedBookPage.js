import { GetBorrowedBookService } from "../../../service/admin/BookService";
import { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import BookConstant from './../../../shared/constants/BookConstant';
import { Modal, Table, Button } from 'react-bootstrap';
import Paging from './../../common/Pagination/Pagination';
import { ConfirmBorrowedBookService } from './../../../service/admin/BookService';

const ViewBorrowedBookPage = () => {
  const [books, setBooks] = useState();
  const [pageIndex, setPageIndex] = useState(BookConstant.PageIndex);
  const [show, setShow] = useState(false);
  const [id, setId] = useState();
  const history = useHistory()

  const handleClose = () => setShow(false);
  const handleConfirm = (evt) => {
    ConfirmBorrowedBookService({ id: id, status: evt.target.id }).then(function (response) {
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
    GetBorrowedBookService(pageIndex).then(function (response) {
      // handle success
      if (!didCancel) {
        let firstRequest = response.data.items[0].id;
        let data = [{
          id: response.data.items[0].id,
          book: [response.data.items[0].nameBook],
          userName: response.data.items[0].userName,
          dateRequest: response.data.items[0].dateRequest.slice(0, 10),
          status: response.data.items[0].status,
        }];
        for (let i = 1; i < response.data.items.length; i++) {
          if (firstRequest !== response.data.items[i].id) {
            data.push({
              id: response.data.items[i].id,
              book: [response.data.items[i].nameBook],
              userName: response.data.items[i].userName,
              dateRequest: response.data.items[i].dateRequest.slice(0, 10),
              status: response.data.items[i].status,
            })

            firstRequest = response.data.items[i].id;
          }
          else {

            data[data.length - 1].book.push(response.data.items[i].nameBook);
          }
        }
        console.log(data[0].dateRequest)
        response.data.items = data;
        setBooks(response.data);
      }
    })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
    return () => didCancel = true
  }, [pageIndex]);

  return (
    <div>
      {
        books !== undefined ?
          <div>
            <Table striped bordered hover variant="dark">
              <thead>
                <tr>
                  <th>{BookConstant.IdHeader}</th>
                  <th>{BookConstant.NameHeader}</th>
                  <th>{BookConstant.UserHeader}</th>
                  <th>{BookConstant.DateHeader}</th>
                  <th>{BookConstant.StatusHeader}</th>
                  <th>{BookConstant.ActionHeader}</th>
                </tr>
              </thead>
              <tbody>
                {books.items.map(book => {
                  return (
                    <tr key={book.id}>
                      <td>{book.id}</td>
                      <td>{book.book.join(' , ')}</td>
                      <td>{book.userName}</td>
                      <td>{book.dateRequest}</td>
                      <td>{book.status}</td>
                      <td>
                        {
                          book.status === 'Waitting' ?
                            <Button variant="dark" onClick={handleShow} id={book.id}>
                              Confirm
                            </Button>
                            :
                            <Button variant="dark" onClick={handleShow} id={book.id} disabled>
                              Confirmed
                            </Button>
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
                <th>{BookConstant.NameHeader}</th>
                <th>{BookConstant.UserHeader}</th>
                <th>{BookConstant.DateHeader}</th>
                <th>{BookConstant.StatusHeader}</th>
              </tr>
            </thead>
          </Table>
      }
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Request</Modal.Title>
        </Modal.Header>
        <Modal.Body>Do you want to confirm this request ?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleConfirm} id="Approve">
            Approve
          </Button>
          <Button variant="primary" onClick={handleConfirm} id="Reject">
            Reject
          </Button>
        </Modal.Footer>
      </Modal>

    </div>
  );
}

export default ViewBorrowedBookPage;
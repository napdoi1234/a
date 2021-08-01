import { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { GetBorrowBookService } from '../../service/normal/BookService';
import BookConstant from './../../shared/constants/BookConstant';
import Paging from './../common/Pagination/Pagination';

const ViewBorrowingBookPage = () => {
  const [books, setBooks] = useState();
  const [pageIndex, setPageIndex] = useState(BookConstant.PageIndex);

  useEffect(() => {
    let didCancel = false;
    GetBorrowBookService(pageIndex).then(function (response) {
      // handle success
      if (!didCancel) {
        let firstRequest = response.data.items[0].id;
        let data = [{
          id: response.data.items[0].id,
          book: [response.data.items[0].nameBook],
          userName: response.data.items[0].userName,
          dateRequest: response.data.items[0].dateRequest,
          status: response.data.items[0].status,
        }];
        for (let i = 1; i < response.data.items.length; i++) {
          if (firstRequest !== response.data.items[i].id) {
            data.push({
              id: response.data.items[i].id,
              book: [response.data.items[i].nameBook],
              userName: response.data.items[i].userName,
              dateRequest: response.data.items[i].dateRequest,
              status: response.data.items[i].status,
            })
            firstRequest = response.data.items[i].id;
          }
          else {

            data[data.length - 1].book.push(response.data.items[i].nameBook);
          }
        }
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
                  <th>{BookConstant.ManagerHeader}</th>
                  <th>{BookConstant.DateHeader}</th>
                  <th>{BookConstant.StatusHeader}</th>
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
                <th>{BookConstant.ManagerHeader}</th>
                <th>{BookConstant.DateHeader}</th>
                <th>{BookConstant.StatusHeader}</th>
              </tr>
            </thead>
          </Table>
      }
    </div>
  );
}

export default ViewBorrowingBookPage;
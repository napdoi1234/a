import axios from "axios";
import BookConstant from '../../shared/constants/BookConstant';

export function GetBooksService(index) {
  return axios.get(BookConstant.BooksURL, {
    params: {
      pageSize: BookConstant.PageSize,
      pageIndex: index
    }
  });
};

export function GetBookService(id) {
  return axios.get(`${BookConstant.BookURL}${id}`);
};

export function CreateBookService({ nameBook, author }) {
  return axios.post(BookConstant.BooksURL, {
    name: nameBook,
    author: author
  });
}

export function UpdateBookService({ id, name, author, categoryID }) {
  return axios.put(BookConstant.BooksURL, {
    author: author,
    id: id,
    name: name,
    categoryID: categoryID,
  });
}

export function DeleteBookService(id) {
  return axios.delete(`${BookConstant.BookURL}${id}`);
}

export function GetBorrowedBookService(index) {
  return axios.get(BookConstant.BorrowedBookURL, {
    params: {
      pageSize: BookConstant.PageSize,
      pageIndex: index
    }
  });
};

export function ConfirmBorrowedBookService({ id, status }) {
  return axios.post(BookConstant.BorrowedBookURL, {
    id: id,
    status: status,
  });
};

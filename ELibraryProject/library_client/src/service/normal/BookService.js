import axios from "axios";
import BookConstant from '../../shared/constants/BookConstant';

export function GetBooksService(index) {
  return axios.get(BookConstant.NormalBooksURL, {
    params: {
      pageSize: BookConstant.PageSize,
      pageIndex: index
    }
  });
};

export function GetBorrowBookService(index) {
  return axios.get(BookConstant.BorrowingBookURL, {
    params: {
      pageSize: BookConstant.PageSize,
      pageIndex: index
    }
  });
};

export function BorrowBookService({ idBooks }) {
  return axios.post(BookConstant.BorrowingBookURL, {
    idBooks: idBooks,
  });
};
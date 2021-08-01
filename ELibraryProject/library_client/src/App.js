import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  NavLink,
  Redirect,
} from "react-router-dom";
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar, Nav, Container, } from 'react-bootstrap';
import { useState } from 'react';
import CurrentUserContext from './contexts/CurrentUserContext';
import LoginPage from './pages/common/Login/LoginPage';
import CreateBookPage from './pages/admin/Book/CreateBookPage';
import UpdateBookPage from './pages/admin/Book/UpdateBookPage';
import ViewCategoryPage from './pages/admin/Category/ViewCategoryPage';
import CreateCategoryPage from './pages/admin/Category/CreateCategoryPage';
import UpdateCategoryPage from './pages/admin/Category/UpdateCategoryPage';
import ViewBookPage from './pages/admin/Book/ViewBookPage';
import ViewBorrowedBookPage from './pages/admin/BorrowingBook/ViewBorrowedBookPage';
import LoginConstant from './shared/constants/LoginConstant';
import BookPage from './pages/normal/BookPage';
import ViewBorrowingBookPage from './pages/normal/ViewBorrowingBookPage';

function App() {
  const [currentUser, setCurrentUser] = useState({
    token: window.localStorage.getItem("token"),
    role: window.localStorage.getItem("role"),
  });

  const handleLogout = () => {
    setCurrentUser({
      role: null,
      token: null,
    });
    window.localStorage.clear();
  }

  return (
    <div className="App">
      <CurrentUserContext.Provider value={{ currentUser, setCurrentUser }}>
        <Router>
          {currentUser.role === null ? <Redirect to='/' /> : null}
          <Navbar bg="dark" variant="dark" className="navbarCommon">
            <Navbar.Brand href="/">Library Managerment</Navbar.Brand>
            <Container >
              <Nav >
                {currentUser.role !== null ?
                  <input type="button" value="Logout" onClick={handleLogout} style={{ backgroundColor: 'black', color: 'white' }} />
                  :
                  <NavLink to="/" className="navLink" activeClassName="active">Home</NavLink>
                }
                {
                  currentUser.role === LoginConstant.AdminRole ?
                    <>
                      <NavLink to="/books" className="navLink" activeClassName="active">Books</NavLink>
                      <NavLink to="/categories" className="navLink" activeClassName="active">Categories</NavLink>
                      <NavLink to="/borrowed_book" className="navLink" activeClassName="active">Borrowed Book</NavLink>
                    </>
                    : currentUser.role === LoginConstant.NormalRole ?
                      <>
                        <NavLink to="/books" className="navLink" activeClassName="active">Books</NavLink>
                        <NavLink to="/borrowed_book" className="navLink" activeClassName="active">Borrowed Book</NavLink>
                      </> : <></>
                }

              </Nav>
            </Container>
          </Navbar>

          <Switch>
            <Route path="/" exact>
              <LoginPage />
            </Route>

            <Route path="/book" exact>
              <CreateBookPage />
            </Route>
            <Route path="/book/:bookId" exact>
              <UpdateBookPage />
            </Route>
            <Route path="/categories" exact>
              <ViewCategoryPage />
            </Route>
            <Route path="/category" exact>
              <CreateCategoryPage />
            </Route>
            <Route path="/category/:categoryID" exact>
              <UpdateCategoryPage />
            </Route>

            <Route path="/borrowed_book" exact
              render={
                () => {
                  if (currentUser.role === LoginConstant.AdminRole) {
                    return <ViewBorrowedBookPage />
                  }
                  else if (currentUser.role === LoginConstant.NormalRole)
                    return <ViewBorrowingBookPage />
                }
              }
            />
            <Route
              path="/books"
              exact
              render={
                () => {
                  if (currentUser.role === LoginConstant.AdminRole) {
                    return <ViewBookPage />
                  }
                  else if (currentUser.role === LoginConstant.NormalRole)
                    return <BookPage />
                }
              }
            />
          </Switch>
        </Router>
      </CurrentUserContext.Provider>
    </div>
  );
}

export default App;

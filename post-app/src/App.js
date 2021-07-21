import PostsPage from './pages/Posts/PostsPage';
import HomePage from './pages/Home/HomePage';
import ProfilePage from './pages/Profile/ProfilePage';
import LoginPage from './pages/Login/LoginPage';
import PostPage from './pages/Post/PostPage';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  NavLink
} from "react-router-dom";
import { useState } from 'react';
import CurrentUserContext from './contexts/CurrentUserContext';
import LoginConstant from './shared/constants/LoginConstant';
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar, Nav, Container, } from 'react-bootstrap';
import './index.css'

function App() {

  const [currentUser, setCurrentUser] = useState({
    userId: window.localStorage.getItem("userId"),
    token: window.localStorage.getItem("token"),
  });

  const handleLogout = () => {
    setCurrentUser({
      userId: null,
      token: null,
    });
    window.localStorage.clear();
  }

  return (
    <div>
      <CurrentUserContext.Provider value={{ currentUser, setCurrentUser }}>
        <Router>
          <Navbar bg="dark" variant="dark" className="navbarCommon">
            <Navbar.Brand href="/">Posts Application</Navbar.Brand>
            <Container >
              <Nav >
                <NavLink to="/" className="navLink">Home</NavLink>
                <NavLink to="/posts" className="navLink">Posts</NavLink>
                <NavLink to="/profile" className="navLink">Profile</NavLink>
                {
                  currentUser.userId !== null ? <input type="button" value="Logout" onClick={handleLogout} /> :
                    <NavLink to="/login" id="login" className="navLink">Login</NavLink>
                }
              </Nav>
            </Container>
          </Navbar>

          <Switch>
            <Route path="/" exact>
              <HomePage />
            </Route>
            <Route path="/posts" exact>
              <PostsPage />
            </Route>
            <Route path="/posts/:postId">
              <PostPage />
            </Route>
            <Route
              path="/profile"
              exact
              render={
                () => {
                  if (currentUser.token === null) {
                    return <LoginPage title={LoginConstant.MessageWarning} />
                  }
                  return <ProfilePage />
                }
              }
            />
            <Route path="/login">
              <LoginPage />
            </Route>
          </Switch>

        </Router>
      </CurrentUserContext.Provider>
    </div>
  );
}

export default App;

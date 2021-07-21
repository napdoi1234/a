import PostsPage from './pages/Posts/PostsPage';
import HomePage from './pages/Home/HomePage';
import ProfilePage from './pages/Profile/ProfilePage';
import LoginPage from './pages/Login/LoginPage';
import PostPage from './pages/Post/PostPage';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import { useState } from 'react';
import CurrentUserContext from './contexts/CurrentUserContext';
import LoginConstant from './constants/LoginConstant';
import React from 'react';

function App() {

  const [currentUser, setCurrentUser] = useState({
    userId: null,
    token: null,
  });

  const handleLogout = () => {
    setCurrentUser({
      userId: null,
      token: null,
    });
  }

  return (
    <div>
      <CurrentUserContext.Provider value={{ currentUser, setCurrentUser }}>
        <Router>
          <div style={{ display: "flex" }}>

            <Link to="/" style={{ padding: "10px" }}>Home</Link>

            <Link to="/posts" style={{ padding: "10px" }}>Posts</Link>

            <Link to="/profile" style={{ padding: "10px" }}>Profile</Link>

            {
              currentUser.userId !== null ? <input type="button" id="logout"
                style={{ padding: "10px" }} value="Logout" onClick={handleLogout} /> :
                <Link to="/login" style={{ padding: "10px" }} id="login">Login</Link>
            }

          </div>

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
                    return <LoginPage title={LoginConstant.Message} />
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

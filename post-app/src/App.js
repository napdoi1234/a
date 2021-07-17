import PostsPage from './pages/PostsPage';
import HomePage from './pages/HomePage';
import ProfilePage from './pages/ProfilePage';
import LoginPage from './pages/LoginPage';
import PostPage from './pages/PostPage';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import { useEffect,useState } from 'react';

function App() {

  const[didLogout,setDidLogout]=useState(false);

  let loginElement;
  let logoutElement;
  let clickLogoutElement;

  useEffect(()=>{
    loginElement = document.getElementById("login");
    logoutElement = document.getElementById("logout");
    clickLogoutElement = document.getElementById("remoteLogout");
  },[didLogout])

  const hanldeLogout = () => {
    setDidLogout(true)
    localStorage.clear();
    loginElement.style.display = "block";
    logoutElement.style.display = "none";
    if(clickLogoutElement !== null){
      clickLogoutElement.click();
    }
  }
  return (
    <div>
      <Router>
        <div style={{ display: "flex" }}>

          <Link to="/" style={{ padding: "10px" }}>Home</Link>

          <Link to="/posts" style={{ padding: "10px" }}>Posts</Link>

          <Link to="/profile" style={{ padding: "10px" }}>Profile</Link>

          <Link to="/login" style={{ padding: "10px" }} id="login">Login</Link>

          <input type="button" id="logout"
            style={{ display: "none", padding: "0px" }} value="Logout" onClick={hanldeLogout} />
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
          <Route path="/profile">
            <ProfilePage setDidLogout = {setDidLogout}/>
          </Route>
          <Route path="/login">
            <LoginPage setDidLogout = {setDidLogout}/>
          </Route>
        </Switch>

      </Router>
    </div>
  );
}

export default App;

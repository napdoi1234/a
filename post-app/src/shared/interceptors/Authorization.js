import axios from "axios";

function Authorization() {
 axios.interceptors.request.use(
  function (config) {
   let token = window.localStorage.getItem('token');
   if (token !== null) {
    config.headers = {
     'Authorization': token,
    }
   }
   return config;
  }
 );
}

export default Authorization;

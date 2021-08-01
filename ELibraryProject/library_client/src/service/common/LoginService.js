import axios from "axios";
import LoginConstant from "../../shared/constants/LoginConstant";

export default function LoginService({ user, password }) {
  return axios.post(LoginConstant.LoginURL, {
    userName: user,
    password: password
  });
}
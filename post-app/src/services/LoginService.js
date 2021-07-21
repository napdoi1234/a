import axios from "axios";
import LoginConstant from "../shared/constants/LoginConstant";

export default function LoginService() {
 return axios.get(LoginConstant.GetMockToken);
}
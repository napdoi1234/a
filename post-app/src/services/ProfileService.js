import axios from "axios";
import ProfileConstant from "../shared/constants/ProfileConstant";

export default function ProfileService(id) {
 return axios.get(`${ProfileConstant.GetMockProfile}${id}`);
}
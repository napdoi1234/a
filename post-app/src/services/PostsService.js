import axios from "axios";
import PostsConstant from "../shared/constants/PostsConstant";

export default function PostsService() {
 return axios.get(PostsConstant.LinkGetPosts);
}
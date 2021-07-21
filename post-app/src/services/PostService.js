import axios from "axios";
import PostsConstant from "../shared/constants/PostsConstant";

export default function PostService(postId) {
 return axios.get(`${PostsConstant.LinkGetPosts}/${postId}`);
}
import { useState, useEffect } from "react";
import axios from "axios";
import PostsConstant from "../constants/PostsConstant";
import { Link } from "react-router-dom";

const PostsPage = props => {
    const [posts, setPosts] = useState();
    const [searchPosts, setSearchPosts] = useState('');
    const [modeOrder, setModeOrder] = useState(PostsConstant.NoneOrder);

    useEffect(() => {
        axios.get(PostsConstant.LinkGetPosts)
            .then(function (response) {
                // handle success
                setPosts(response.data);

            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    }, []);

    let filterPosts = posts !== undefined ?
        posts.filter(p => p.title.toLowerCase().includes(searchPosts.toLowerCase())) : [];

    const OrderPosts = () => {
        if (filterPosts.length !== 0) {
            if (modeOrder === PostsConstant.NoneOrder) {
                setModeOrder(PostsConstant.ASCOrder);
                posts.sort((a, b) => a.title.localeCompare(b.title));
            }
            else if (modeOrder === PostsConstant.ASCOrder) {
                setModeOrder(PostsConstant.DESCOrder);
                posts.sort((a, b) => b.title.localeCompare(a.title));
            }
            else {
                setModeOrder(PostsConstant.NoneOrder);
                posts.sort((a, b) => a.id - b.id);
            }
        }
    }

    return (

        <div>
            <input type="text" value={searchPosts} onChange={event => setSearchPosts(event.target.value)} placeholder="Search Post" />
            <table style={{ width: "100%" }}>
                <thead>
                    <tr>
                        <th>{PostsConstant.IdHeader}</th>
                        <th onClick={OrderPosts}>{PostsConstant.TitleHeader} {modeOrder}</th>
                        <th>{PostsConstant.ActionHeader}</th>
                    </tr>
                </thead>
                <tbody>
                    {filterPosts.map(post => {
                        return (
                            <tr key = {post.id}>
                                <td>{post.id}</td>
                                <td>{post.title}</td>
                                <td><Link to={`/posts/${post.id}`}>{PostsConstant.DetailField}</Link></td>
                            </tr>
                        )
                    })
                    }
                </tbody>
            </table>
        </div>
    );
};

export default PostsPage;
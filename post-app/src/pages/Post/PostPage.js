import { useParams } from "react-router";
import { useEffect, useState } from "react";
import axios from "axios";
import PostsConstant from "../../constants/PostsConstant";
import Post from "./PostComponent/Post";
import React from 'react';

const PostPage = props => {
    const { postId } = useParams();
    const [post, setPost] = useState();

    useEffect(() => {
        let didCancel = false;
        axios.get(`${PostsConstant.LinkGetPosts}/${postId}`)
            .then(function (response) {
                // handle success
                if (!didCancel)
                    setPost(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
        return () => didCancel = true
    }, [postId]);

    return (
        <div>
            {post !== undefined ? <Post id={post.id} title={post.title} body={post.body} /> : null}

        </div>
    );
};

export default PostPage;
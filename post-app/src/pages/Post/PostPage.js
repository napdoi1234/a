import { useParams } from "react-router";
import { useEffect, useState } from "react";
import Post from "./PostComponent/Post";
import React from 'react';
import PostService from "../../services/PostService";

const PostPage = props => {
    const { postId } = useParams();
    const [post, setPost] = useState();

    useEffect(() => {
        let didCancel = false;

        PostService(postId).then(function (response) {
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
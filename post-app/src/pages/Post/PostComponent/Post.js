import React from 'react';

const Post = ({ id, title, body }) => {
    return (
        <>
            <div>
                <h4>ID: {id}</h4>
                <h4>Title: {title}</h4>
                <h4>Body: {body}</h4>
            </div>
        </>
    );
};

export default Post;
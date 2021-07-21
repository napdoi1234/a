import { useState, useEffect } from "react";
import PostsConstant from "../../shared/constants/PostsConstant";
import { Link } from "react-router-dom";
import React from 'react';
import { Table, InputGroup, FormControl } from "react-bootstrap";
import styles from './PostsPage.module.css';
import PostsService from "../../services/PostsService";

const PostsPage = props => {
    const [posts, setPosts] = useState();
    const [searchPosts, setSearchPosts] = useState('');
    const [modeOrder, setModeOrder] = useState(PostsConstant.NoneOrder);

    useEffect(() => {
        PostsService().then(function (response) {
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
            <InputGroup size="sm" className={`mb-3 ${styles.searchInput}`}>
                <FormControl type="text" value={searchPosts}
                    onChange={event => setSearchPosts(event.target.value)} placeholder="Search Post" />
            </InputGroup>
            <Table striped bordered hover variant="dark">
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
                            <tr key={post.id}>
                                <td>{post.id}</td>
                                <td>{post.title}</td>
                                <td ><Link to={`/posts/${post.id}`} style={{ color: 'white' }}>{PostsConstant.DetailField}</Link></td>
                            </tr>
                        )
                    })
                    }
                </tbody>
            </Table>
        </div>
    );
};

export default PostsPage;
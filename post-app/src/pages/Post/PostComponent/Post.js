import React from 'react';
import { Card } from 'react-bootstrap';
import styles from './Post.module.css';

const Post = ({ id, title, body }) => {
    return (
        <>
            <Card className={styles.card}>
                <Card.Body>
                    <Card.Title>User Detail</Card.Title>
                    <Card.Text >
                        ID: {id}
                    </Card.Text>
                    <Card.Text>
                        Title: {title}
                    </Card.Text>
                    <Card.Text>
                        Body: {body}
                    </Card.Text>
                </Card.Body>
            </Card>
        </>
    );
};

export default Post;
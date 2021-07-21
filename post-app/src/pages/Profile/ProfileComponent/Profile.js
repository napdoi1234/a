import React from 'react';
import { Card } from 'react-bootstrap';
import styles from './Profile.module.css';

const Profile = ({ name, id }) => {
    return (
        <Card className={styles.card}>
            <Card.Body>
                <Card.Title>Profile</Card.Title>
                <Card.Text >
                    Name : {name}
                </Card.Text>
                <Card.Text>
                    UserID : {id}
                </Card.Text>
            </Card.Body>
        </Card>
    );
};

export default Profile;
import React from 'react';

const Profile = ({ name, id }) => {
    return (
        <div>

            <h4>Profile</h4>
            <p>Name : {name}</p>
            <p>UserID : {id}</p>

        </div>
    );
};

export default Profile;
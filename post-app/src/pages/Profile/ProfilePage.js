import Profile from "./ProfileComponent/Profile";
import { useState, useEffect, useContext } from "react";
import axios from "axios";
import ProfileConstant from "../../constants/ProfileConstant";
import CurrentUserContext from "../../contexts/CurrentUserContext";
import React from 'react';

const ProfilePage = () => {
    const [profile, setProfile] = useState();
    const { currentUser } = useContext(CurrentUserContext);

    useEffect(() => {
        let didCancel = false;
        axios.get(`${ProfileConstant.GetMockProfile}${currentUser.userId}`)
            .then(function (response) {
                // handle success
                if (!didCancel)
                    setProfile(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
        return () => didCancel = true;
    }, [currentUser.userId])

    const handleLogOut = () => {
        setProfile(undefined);
    }

    return (
        <div>
            {
                profile !== undefined ? <Profile id={profile.id} name={profile.name} /> : <p>Something went wrong</p>
            }
            <input type="hidden" onClick={handleLogOut} id="remoteLogout" />

        </div>
    );
};

export default ProfilePage;
import Profile from "../components/Profile/Profile";
import Login from "../components/LoginComponent/Login";
import { useState, useEffect } from "react";
import axios from "axios";
import ProfileConstant from "../constants/ProfileConstant";

const ProfilePage = ({setDidLogout}) => {
    const token = window.localStorage.getItem("token");
    const [profile, setProfile] = useState();
    const userId = window.localStorage.getItem("userId");

    useEffect(() => {
        axios.get(`${ProfileConstant.GetMockProfile}${userId}`)
            .then(function (response) {
                // handle success
                setProfile(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
                setProfile(undefined);
            })
    }, [userId])

    const handleLogOut = ()=>{
        setProfile(undefined);
    }

    return (
        <div>
            {
                (token !== null) ?
                    profile !== undefined ? <Profile id={profile.id} name={profile.name} /> : <p>Something went wrong</p> :
                    <div>
                        <p>You need to login to continue</p>
                        <Login setProfile={setProfile} setDidLogout = {setDidLogout}/>
                    </div>
            }
            <input type = "hidden" onClick = {handleLogOut} id = "remoteLogout"/>

        </div>
    );
};

export default ProfilePage;
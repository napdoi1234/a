import { useForm } from "react-hook-form";
import axios from "axios";
import LoginConstant from "../../constants/LoginConstant";
import ProfileConstant from "../../constants/ProfileConstant";
import { useState,useEffect } from "react";

const Login = ({ setProfile,setDidLogout }) => {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [confirm, setConfirm] = useState('');

    let loginElement;
    let logoutElement;
    let submitElement;

    useEffect(()=>{
        loginElement = document.getElementById("login");
        logoutElement = document.getElementById("logout");
        submitElement = document.getElementById("submit");
    })

    const onSubmit = () => {
        document.getElementById("submit").disabled = true;
        axios.get(LoginConstant.GetMockToken)
            .then(function (response) {
                // handle success
                window.localStorage.setItem("token", response.data.token);
                window.localStorage.setItem("userId", response.data.userId);
                setConfirm(LoginConstant.LoginSuccess);
                loginElement.style.display = "none";
                logoutElement.style.display = "block";
                if(setProfile !== undefined)
                    axios.get(`${ProfileConstant.GetMockProfile}${response.data.userId}`)
                        .then(function (response) {
                            // handle success
                            setProfile(response.data);
                        })
                        .catch(function (error) {
                            // handle error
                            console.log(error);
                        })
                setDidLogout(false);
                submitElement.disabled = false;
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    }

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)} style={{ padding: "15px" }}>

                <input
                    id="email"
                    {...register("email", {
                        required: "required",
                        pattern: {
                            value: /\S+@\S+\.\S+/,
                            message: "Must be valid email"
                        }
                    })}
                    type="email"
                    placeholder="Email"
                />
                <br />
                {errors.email && <span role="alert" style={{ color: "red" }}>{errors.email.message}</span>}

                <br />
                <br />
                <input
                    id="password"
                    {...register("password", {
                        required: "required",
                        minLength: {
                            value: 8,
                            message: "At least 8 characters"
                        }
                    })}
                    type="password"
                    placeholder="Password"
                />
                <br />
                {errors.password && <span role="alert" style={{ color: "red" }}>{errors.password.message}</span>}
                <br />
                <br />
                <button type="submit" id="submit">Submit</button>
            </form>

            <div style={{ color: "green", margin: "20px" }}>{confirm}</div>
        </>
    );
};

export default Login;
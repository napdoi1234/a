import { useForm } from "react-hook-form";
import axios from "axios";
import LoginConstant from "../../constants/LoginConstant";
import { useState, useContext } from "react";
import CurrentUserContext from "../../contexts/CurrentUserContext";
import React from 'react';

const LoginPage = ({ title }) => {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [confirm, setConfirm] = useState(' ');
    const { setCurrentUser } = useContext(CurrentUserContext);

    const onSubmit = () => {
        setConfirm('');
        axios.get(LoginConstant.GetMockToken)
            .then(function (response) {
                // handle success
                setConfirm(LoginConstant.LoginSuccess);
                setCurrentUser({
                    userId: response.data.userId,
                    token: response.data.token,
                })
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    }

    return (
        <>
            <p>{title}</p>
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
                {confirm !== '' ? <button type="submit" id="submit">Submit</button>
                    : <button type="submit" id="submit" disabled={true}>Submit</button>
                }

            </form>

            <div style={{ color: "green", margin: "20px" }}>{confirm}</div>
        </>
    );
};

export default LoginPage;
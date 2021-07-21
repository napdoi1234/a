import { useForm } from "react-hook-form";
import LoginConstant from "../../shared/constants/LoginConstant";
import { useState, useContext } from "react";
import CurrentUserContext from "../../contexts/CurrentUserContext";
import React from 'react';
import { Form, Button, Alert } from "react-bootstrap";
import styles from './LoginPage.module.css';
import LoginService from "../../services/LoginService";

const LoginPage = ({ title }) => {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [confirm, setConfirm] = useState(LoginConstant.MessageLogin);
    const { setCurrentUser } = useContext(CurrentUserContext);

    const onSubmit = () => {
        setConfirm('');
        LoginService().then(function (response) {
            // handle success
            setConfirm(LoginConstant.LoginSuccess);
            setCurrentUser({
                userId: response.data.userId,
                token: response.data.token,
            });
            window.localStorage.setItem('token', response.data.token);
            window.localStorage.setItem('userId', response.data.userId);
        })
            .catch(function (error) {
                // handle error
                setConfirm(LoginConstant.MessageLogin);
                console.log(error);
            })
    }

    return (
        <>
            <Form onSubmit={handleSubmit(onSubmit)} className={styles.formLogin}>
                <p className={styles.title}>{title}</p>
                <Form.Group className={`mb-3 ${styles.groupInputLogin}`}>
                    <Form.Label>Email address</Form.Label>
                    <Form.Control
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
                    {errors.email && <span role="alert" className={styles.errorMessage}>{errors.email.message}</span>}

                </Form.Group>
                <Form.Group className={`mb-3' ${styles.groupInputLogin}`}>
                    <Form.Label>Password</Form.Label>
                    <Form.Control
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
                    {errors.password && <span role="alert" className={styles.errorMessage}>{errors.password.message}</span>}
                </Form.Group>
                <Form.Group className={`mb-3' ${styles.groupInputLogin}`}>
                    {confirm !== '' ? <Button variant="secondary" type="submit" >Submit</Button>
                        : <Button variant="secondary" type="submit" disabled={true}>Submit</Button>
                    }
                </Form.Group>
            </Form>
            <Alert variant="dark" className={styles.confirmLogin}>
                <div >{confirm}</div>
            </Alert>

        </>
    );
};

export default LoginPage;
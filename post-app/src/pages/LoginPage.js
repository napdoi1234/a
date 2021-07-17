import Login from "../components/LoginComponent/Login";

const LoginPage = ({setDidLogout}) => {
    return (
        <div>
            <Login setDidLogout= {setDidLogout}/>
        </div>
    );
};

export default LoginPage;
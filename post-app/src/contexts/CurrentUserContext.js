import { createContext } from "react";

const CurrentUserContext = createContext({
 userId: null,
 token: null,
});

export default CurrentUserContext;
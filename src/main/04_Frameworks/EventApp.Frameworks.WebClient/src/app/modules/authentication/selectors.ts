import { AuthenticationState } from "../../models/authentication";
import { RootState } from "../../store";

export const selectAuthentication: (state: RootState) => AuthenticationState = state => state.authentication;

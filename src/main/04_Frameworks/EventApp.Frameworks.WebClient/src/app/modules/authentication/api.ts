import axios from "axios";

export async function signUp(login: string, password: string) {
  return await axios.post(`/api/users/signup`, {
    login: login,
    password: password
  });
}

export async function signIn(login: string, password: string) {
  return await axios.post(`/api/users/signin`, {
    login: login,
    password: password
  });
}


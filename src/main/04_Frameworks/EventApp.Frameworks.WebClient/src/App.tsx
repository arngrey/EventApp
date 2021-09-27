import React from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import './App.css';

import { AppContainer } from "./app/components/styles";

import { NavigationBar } from "./app/components/organisms/NavigationBar";

import { HobbyRegister } from "./app/pages/hobby/register";
import { CampaignRegister } from "./app/pages/campaign/register";
import { FieldForm } from './app/components/organisms/FieldForm';
import { useAppDispatch, useAppSelector } from './app/hooks';
import { signUpAsync, signInAsync, logOutAsync } from './app/modules/authentication/slice';
import { PrivateRoute } from './app/components/organisms/PrivateRoute';
import { CommonButtonPanel } from './app/components/molecules/CommonButtonPanel';
import { selectAuthentication } from './app/modules/authentication/selectors';

function App() {
  const dispatch = useAppDispatch();
  const authentication = useAppSelector(selectAuthentication);

  return (
    <AppContainer>
      <BrowserRouter>
        <NavigationBar
          navigationItems={[
            { title: "Главная", path: "/", isVisible: authentication.isAuthenticated  },
            { title: "Хобби", path: "/hobbies", isVisible: authentication.isAuthenticated },
            { title: "Кампании", path: "/campaigns", isVisible: authentication.isAuthenticated },
            { title: "Войти", path: "/signin", isVisible: !authentication.isAuthenticated },
            { title: "Регистрация", path: "/signup", isVisible: !authentication.isAuthenticated }
          ]} />
        <Switch>
          <PrivateRoute path="/hobbies" isAuthenticated={authentication.isAuthenticated}>
            <HobbyRegister />
          </PrivateRoute>
          <PrivateRoute path="/campaigns" isAuthenticated={authentication.isAuthenticated}>
            <CampaignRegister />
          </PrivateRoute>
          <Route path="/signin">
            <FieldForm
              title={"Войти"}
              inputFields={[
                { labelText: "Логин", name: "login" },
                { labelText: "Пароль", name: "password" }
              ]}
              onOk={async (record, history) => { 
                await dispatch(signInAsync(record["login"], record["password"]));
                history.push("/");
              }}
              onCancel={() => {}} />
          </Route>
          <Route path="/signup">
            <FieldForm
              title={"Создать пользователя"}
              inputFields={[
                { labelText: "Логин", name: "login" },
                { labelText: "Пароль", name: "password" }
              ]}
              onOk={async (record, history) => { 
                await dispatch(signUpAsync(record["login"], record["password"]));
                history.push("/");
              }}
              onCancel={() => {}} />
          </Route>          
          <PrivateRoute path="/" isAuthenticated={authentication.isAuthenticated}>
            <CommonButtonPanel
              buttons={[{ 
                text: "Выйти", 
                onClick: async (history) => { 
                  await dispatch(logOutAsync());
                  history.push("/signin");
                } 
              }]}>

            </CommonButtonPanel>
          </PrivateRoute>
        </Switch>        
      </BrowserRouter>
    </AppContainer>
  )
}

export default App;

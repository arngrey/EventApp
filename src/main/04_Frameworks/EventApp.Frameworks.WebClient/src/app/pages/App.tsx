import React from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import './App.css';

import { AppContainer } from "./App.styles";

import { HobbyRegister } from "../containers/hobby/register";
import { CampaignRegister } from "../containers/campaign/register";
import { useAppDispatch, useAppSelector } from '../hooks';
import { logOutAsync } from '../modules/authentication/slice';
import { PrivateRoute } from '../components/organisms/PrivateRoute';
import { CommonButtonPanel } from '../components/molecules/CommonButtonPanel';
import { selectAuthentication } from '../modules/authentication/selectors';
import { NavigationBar } from '../components/organisms/NavigationBar';
import WelcomePage from './welcome/WelcomePage';

function App() {
  const dispatch = useAppDispatch();
  const authentication = useAppSelector(selectAuthentication);

  return (
    <AppContainer>
      <BrowserRouter>
        <Switch>
          <Route path="/welcome">
            <WelcomePage />
          </Route>
          <PrivateRoute path="/hobbies" isAuthenticated={authentication.isAuthenticated}>
            <HobbyRegister />
          </PrivateRoute>
          <PrivateRoute path="/campaigns" isAuthenticated={authentication.isAuthenticated}>
            <CampaignRegister />
          </PrivateRoute>
          <PrivateRoute path="/" isAuthenticated={authentication.isAuthenticated}>
            <NavigationBar
              navigationItems={[
                { title: "Главная", path: "/" },
                { title: "Хобби", path: "/hobbies" },
                { title: "Кампании", path: "/campaigns" }
              ]} />
            <CommonButtonPanel
              buttons={[{ 
                text: "Выйти", 
                onClick: async (history) => { 
                  await dispatch(logOutAsync());
                  history.push("/welcome");
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

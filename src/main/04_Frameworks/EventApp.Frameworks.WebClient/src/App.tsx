import React from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import './App.css';

import { AppContainer } from "./app/components/styles";

import { NavigationBar } from "./app/components/organisms/NavigationBar";

import { HobbyRegister } from "./app/pages/hobby/register";
import { CampaignRegister } from "./app/pages/campaign/register";
import { FieldForm } from './app/components/organisms/FieldForm';
import { useAppDispatch } from './app/hooks';
import { createUserAsync } from './app/slice';

function App() {
  const dispatch = useAppDispatch();
  
  return (
    <AppContainer>
      <BrowserRouter>
        <NavigationBar
          navigationItems={[
            { title: "Хобби", path: "/hobbies"  },
            { title: "Кампании", path: "/campaigns" },
            { title: "Пользователи", path: "/users" },
          ]} />
        <Switch>
          <Route path="/hobbies">
            <HobbyRegister />
          </Route>
          <Route path="/campaigns">
            <CampaignRegister />
          </Route>
          <Route path="/users">
            <FieldForm
              title={"Создать пользователя"}
              inputFields={[
                { labelText: "Имя пользователя", name: "name" }
              ]}
              onOk={async (records) => { 
                await dispatch(createUserAsync(records["name"]));
              }}
              onCancel={() => {}} />
          </Route>           
          <Route path="/">
            {"Главная"}
          </Route>        
        </Switch>        
      </BrowserRouter>
    </AppContainer>
  )
}

export default App;

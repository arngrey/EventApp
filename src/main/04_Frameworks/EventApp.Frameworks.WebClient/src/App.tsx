import React, { useState } from 'react';
import './App.css';
import { useAppDispatch, useAppSelector } from './app/hooks';
import { loadCampaignsAsync, loadHobbiesAsync, loadCampaignMessagesAsync, sendMessageAsync, createUserAsync, createHobbyAsync, addParticipantAsync, createCampaignAsync, selectHobbies, selectCampaigns, selectCampaignMessages } from './app/slice';

import { AppContainer, TableFieldFormContainer } from "./app/components/styles";
import { Table } from "./app/components/organisms/Table";
import { FieldForm } from "./app/components/organisms/FieldForm";

function App() {
  const dispatch = useAppDispatch();
  const hobbies = useAppSelector(selectHobbies);
  const campaigns = useAppSelector(selectCampaigns);
  const campaignMessages = useAppSelector(selectCampaignMessages);
  
  const [campaignId, setCampaignId] = useState<string>("");

  return (
    <AppContainer>
      <TableFieldFormContainer>
        <Table
          title={"Список хобби"}
          columnNames={["Идентификатор", "Наименование"]}
          rows={hobbies.map((hobby: any) => [hobby.id, hobby.name])}
          rowHeight={"1rem"}
          headersHeight={"2rem"}
          buttonPanel={{ buttons: [ { text: "Обновить", onClick: () => { dispatch(loadHobbiesAsync()) } } ] }} />
        <FieldForm 
          title={"Создание хобби"}
          inputFields={[{ labelText: "Наименование", name: "name" }]}
          onOk={async (records) => { 
            await dispatch(createHobbyAsync(records["name"]));
            await dispatch(loadHobbiesAsync());
          }}
          onCancel={() => {}} />
      </TableFieldFormContainer>
      <TableFieldFormContainer>
        <Table
          title={"Список кампаний"}
          columnNames={["Идентификатор", "Наименование", "Участники", "Хобби"]}
          rows={campaigns.map((campaign: any) => [
            campaign.id, 
            campaign.name, 
            campaign.participants.map((p:any) => p.name).join(", "),
            campaign.hobbies.map((p:any) => p.name).join(", ")
          ])}
          rowHeight={"1rem"}
          headersHeight={"2rem"}
          buttonPanel={{ buttons: [ { text: "Обновить", onClick: () => { dispatch(loadCampaignsAsync()) } } ] }} />
        <FieldForm 
          title={"Создание кампании"}
          inputFields={[
            { labelText: "Наименование", name: "name" },
            { labelText: "Идентификатор администратора", name: "administratorId" },
            { labelText: "Идентификаторы хобби через \",\"", name: "hobbyIds" }
          ]}
          onOk={async (records) => { 
            await dispatch(createCampaignAsync(records["name"], records["administratorId"], records["hobbyIds"].split(",")));
            await dispatch(loadCampaignsAsync());
          }}
          onCancel={() => {}} />
      </TableFieldFormContainer>
      <br />
      <label htmlFor="">Введите идентификатор кампании.</label>
      <input type="text" onChange={(e) => setCampaignId(e.target.value)} />
      <TableFieldFormContainer>
        <Table
          title={"Список сообщений кампании"}
          columnNames={["Идентификатор", "Отправитель", "Текст"]}
          rows={campaignMessages.map((campaignMessage: any) => [campaignMessage.id, campaignMessage.sender.name, campaignMessage.text])}
          rowHeight={"1rem"}
          headersHeight={"2rem"}
          buttonPanel={{ buttons: [ { text: "Обновить", onClick: () => { dispatch(loadCampaignMessagesAsync(campaignId)) } } ] }} /> 
        <FieldForm 
          title={"Отправить сообщение"}
          inputFields={[
            { labelText: "Идентификатор пользователя", name: "userId" },
            { labelText: "Идентификатор кампании", name: "campaignId" },
            { labelText: "Текст", name: "text" }
          ]}
          onOk={async (records) => {
            await dispatch(sendMessageAsync(records["userId"], records["campaignId"], records["text"]));
            await dispatch(loadCampaignMessagesAsync(records["campaignId"]));
          }}
          onCancel={() => {}} />               
      </TableFieldFormContainer>
      <FieldForm 
          title={"Добавить участника в кампанию"}
          inputFields={[
            { labelText: "Идентификатор пользователя", name: "userId" },
            { labelText: "Идентификаторы кампании", name: "campaignId" }
          ]}
          onOk={async (records) => { 
            await dispatch(addParticipantAsync(records["userId"], records["campaignId"]));
            await dispatch(loadCampaignsAsync());
          }}
          onCancel={() => {}} />
      <FieldForm 
          title={"Создать пользователя"}
          inputFields={[
            { labelText: "Имя пользователя", name: "name" }
          ]}
          onOk={async (records) => { 
            await dispatch(createUserAsync(records["name"]));
          }}
          onCancel={() => {}} />
    </AppContainer>
  );
}

export default App;

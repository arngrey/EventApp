import React, { useState } from "react";
import { FieldForm } from "../../components/organisms/FieldForm";
import { Table } from "../../components/organisms/Table";
import { TableFieldFormContainer } from "../../components/styles";
import { RegisterContainer } from "../styles";
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, sendMessageAsync, addParticipantAsync, createCampaignAsync, selectCampaigns, selectCampaignMessages } from '../../../app/slice';

export const CampaignRegister: React.FC = () => {
    const dispatch = useAppDispatch();
    const campaigns = useAppSelector(selectCampaigns);
    const campaignMessages = useAppSelector(selectCampaignMessages);
    
    const [campaignId, setCampaignId] = useState<string>("");
    return (
        <RegisterContainer>
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
        </RegisterContainer>
    )
}
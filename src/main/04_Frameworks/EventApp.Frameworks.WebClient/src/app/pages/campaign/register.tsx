import React, { useState } from "react";
import { FieldForm } from "../../components/organisms/FieldForm";
import { Table } from "../../components/organisms/Table";
import { RegisterContainer } from "../styles";
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, sendMessageAsync, addParticipantAsync, createCampaignAsync, selectCampaigns, selectCampaignMessages } from '../../../app/slice';
import { Popup } from "../../components/atoms/Popup";
import { CommonButtonPanel } from "../../components/molecules/CommonButtonPanel";

export const CampaignRegister: React.FC = () => {
    const dispatch = useAppDispatch();
    const campaigns = useAppSelector(selectCampaigns);
    const campaignMessages = useAppSelector(selectCampaignMessages);
    
    const [campaignId, setCampaignId] = useState<string>("");
    const [isAddingCampaignPopupVisible, setAddingCampaignPopupVisibility] = useState<boolean>(false);
    const [isCardPopupVisible, setCardPopupVisibility] = useState<boolean>(false);
    const [isAddingMessagePopupVisible, setAddingMessagePopupVisibility] = useState<boolean>(false);
    const [isAddingParticipantPopupVisible, setAddingParticipantPopupVisibility] = useState<boolean>(false);
    return (
        <RegisterContainer>
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
                buttonPanel={{ buttons: [ 
                    { text: "Обновить", onClick: () => { dispatch(loadCampaignsAsync()) } },
                    { text: "Добавить кампанию", onClick: () => { setAddingCampaignPopupVisibility(true); } }
                ] }}
                onRowClick={(row) => {
                    setCampaignId(row[0]); 
                    setCardPopupVisibility(true);
                    dispatch(loadCampaignMessagesAsync(row[0]));
                }} />
            <Popup isVisible={isAddingCampaignPopupVisible}>
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
                        setAddingCampaignPopupVisibility(false);
                    }}
                    onCancel={() => { setAddingCampaignPopupVisibility(false); }} />
            </Popup>          
            <Popup isVisible={isCardPopupVisible}>
                <Table
                    title={"Список сообщений кампании"}
                    columnNames={["Идентификатор", "Отправитель", "Текст"]}
                    rows={campaignMessages.map((campaignMessage: any) => [campaignMessage.id, campaignMessage.sender.name, campaignMessage.text])}
                    rowHeight={"1rem"}
                    headersHeight={"2rem"}
                    buttonPanel={{ buttons: [ 
                        { text: "Обновить", onClick: () => { dispatch(loadCampaignMessagesAsync(campaignId)); } },
                        { text: "Создать сообщение", onClick: () => { setAddingMessagePopupVisibility(true); } },
                    ] }} /> 
                <Popup isVisible={isAddingMessagePopupVisible}>
                    <FieldForm 
                        title={"Отправить сообщение"}
                        inputFields={[
                        { labelText: "Идентификатор пользователя", name: "userId" },
                        { labelText: "Текст", name: "text" }
                        ]}
                        onOk={async (records) => {
                            await dispatch(sendMessageAsync(records["userId"], campaignId, records["text"]));
                            await dispatch(loadCampaignMessagesAsync(campaignId));
                            setAddingMessagePopupVisibility(false);
                        }}
                        onCancel={() => { setAddingMessagePopupVisibility(false); }} />
                </Popup>
                <Popup isVisible={isAddingParticipantPopupVisible}>
                    <FieldForm 
                        title={"Добавить участника в кампанию"}
                        inputFields={[
                            { labelText: "Идентификатор пользователя", name: "userId" }
                        ]}
                        onOk={async (records) => { 
                            await dispatch(addParticipantAsync(records["userId"], campaignId));
                            await dispatch(loadCampaignsAsync());
                            setAddingParticipantPopupVisibility(false);
                        }}
                        onCancel={() => { setAddingParticipantPopupVisibility(false); }} />   
                </Popup>
                <CommonButtonPanel
                    buttons={[
                        { text: "Закрыть", onClick: () => { setCardPopupVisibility(false); } },
                        { text: "Добавить участника", onClick: () => { setAddingParticipantPopupVisibility(true); } }
                    ]} />                    
            </Popup>            
        </RegisterContainer>
    )
}
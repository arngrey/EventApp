import React, { useState } from "react";
import { CardContainer } from "../../styles";
import { useAppDispatch, useAppSelector } from '../../../hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, sendMessageAsync, addParticipantAsync, selectCampaignMessages, selectCampaign } from '../../../slice';
import { selectAuthentication } from '../../../modules/authentication/selectors';
import { Table } from "../../../components/organisms/Table";
import { Popup } from "../../../components/atoms/Popup";
import { CommonButtonPanel } from "../../../components/molecules/CommonButtonPanel";
import { FieldForm } from "../../../components/organisms/FieldForm";
import { CommonButtonPanelContainer, TableContainer } from "./styles";
import { UserFlatDto } from "../../../models/user";

export type CampaignCardProps = {
    campaignId: string;
    onClose: () => void;
}

export const CampaignCard: React.FC<CampaignCardProps> = (props) => {
    const dispatch = useAppDispatch();
    const authentication = useAppSelector(selectAuthentication);
    const campaign = useAppSelector(selectCampaign(props.campaignId));
    const campaignMessages = useAppSelector(selectCampaignMessages);
    const [isAddingMessagePopupVisible, setAddingMessagePopupVisibility] = useState<boolean>(false);
    const [isAddingParticipantPopupVisible, setAddingParticipantPopupVisibility] = useState<boolean>(false);

    if (!authentication.isAuthenticated) {
        return null;
    }

    if (campaign === undefined) {
        return null;
    }

    return (
        <CardContainer>
            <TableContainer>
                <Table
                    title={"Список сообщений кампании"}
                    columnNames={["Идентификатор", "Отправитель", "Текст"]}
                    rows={campaignMessages.map((campaignMessage: any) => [campaignMessage.id, campaignMessage.sender.login, campaignMessage.text])}
                    rowHeight={"1rem"}
                    headersHeight={"2rem"}
                    buttonPanel={{ buttons: [ 
                        { text: "Обновить", onClick: () => { dispatch(loadCampaignMessagesAsync(props.campaignId)); } },
                        { text: "Создать сообщение", onClick: () => { setAddingMessagePopupVisibility(true); } },
                    ] }} />
            </TableContainer>
            <CommonButtonPanelContainer>
                <CommonButtonPanel
                    buttons={[
                        { text: "Закрыть", onClick: () => { props.onClose(); } },
                        { text: "Присоединиться", onClick: async () => { 
                            await dispatch(addParticipantAsync(authentication.userId, campaign.id));
                            await dispatch(loadCampaignsAsync());
                        }, isVisible: !campaign.participants.some((participant: UserFlatDto) => participant.id === authentication.userId) },
                        { text: "Добавить участника", onClick: () => { setAddingParticipantPopupVisibility(true); }, isVisible: campaign.administrator.id === authentication.userId }
                    ]} />   
            </CommonButtonPanelContainer>                
            <Popup isVisible={isAddingMessagePopupVisible}>
                <FieldForm 
                    title={"Отправить сообщение"}
                    inputFields={[
                        { labelText: "Текст", name: "text" }
                    ]}
                    onOk={async (records) => {
                        if (!authentication.isAuthenticated) {
                            return;
                        }
                        await dispatch(sendMessageAsync(authentication.userId, props.campaignId, records["text"]));
                        await dispatch(loadCampaignMessagesAsync(props.campaignId));
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
                        await dispatch(addParticipantAsync(records["userId"], props.campaignId));
                        await dispatch(loadCampaignsAsync());
                        setAddingParticipantPopupVisibility(false);
                    }}
                    onCancel={() => { setAddingParticipantPopupVisibility(false); }} />   
            </Popup>
        </CardContainer>
    )
}
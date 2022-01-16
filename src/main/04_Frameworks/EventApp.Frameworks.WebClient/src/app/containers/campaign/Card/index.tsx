import React, { useState } from "react";
import { CardContainer } from "../../styles";
import { useAppDispatch, useAppSelector } from '../../../hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, sendMessageAsync, addParticipantAsync } from '../../../slice';
import { selectAuthentication } from '../../../modules/authentication/selectors';
import { CommonTable } from "../../../components/organisms/CommonTable";
import { Popup } from "../../../components/atoms/Popup";
import { CommonButtonPanel } from "../../../components/molecules/CommonButtonPanel";
import { CommonTitle } from "../../../components/atoms/CommonTitle";
import { FieldForm } from "../../../components/organisms/FieldForm";
import { CommonButtonPanelContainer, TableContainer, CardTitleContainer } from "./styles";
import { UserFlatDto } from "../../../models/user";
import { selectCampaign } from "../../../selectors"

export type CampaignCardProps = {
    campaignId: string;
    onClose: () => void;
}

export const CampaignCard: React.FC<CampaignCardProps> = (props) => {
    const dispatch = useAppDispatch();
    const authentication = useAppSelector(selectAuthentication);
    const campaign = useAppSelector(selectCampaign(props.campaignId));
    const [isAddingMessagePopupVisible, setAddingMessagePopupVisibility] = useState<boolean>(false);

    if (!authentication.isAuthenticated) {
        return null;
    }

    if (campaign === undefined) {
        return null;
    }

    const campaignMessages = campaign.messages === undefined ? [] : campaign.messages;

    return (
        <CardContainer>
            <CardTitleContainer>
                <CommonTitle 
                    text={`Кампания ${campaign.name}`} />
            </CardTitleContainer>
            <TableContainer>
                <CommonTable
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
                            await dispatch(loadCampaignMessagesAsync(props.campaignId));
                        }, isVisible: !campaign.participants.some((participant: UserFlatDto) => participant.id === authentication.userId) }
                    ]} />   
            </CommonButtonPanelContainer>                
            <Popup isVisible={isAddingMessagePopupVisible}>
                <FieldForm 
                    title={"Отправить сообщение"}
                    fields={[
                        { name: "text", type: "input", props: { labelText: "Текст" } },
                    ]}
                    buttons={[
                        { 
                            text: "Отправить", 
                            onClick: async (records) => { 
                                if (!authentication.isAuthenticated) {
                                    return;
                                }
                                await dispatch(sendMessageAsync(authentication.userId, props.campaignId, records["text"]));
                                await dispatch(loadCampaignMessagesAsync(props.campaignId));
                                setAddingMessagePopupVisibility(false);
                            }
                        }, {
                            text: "Отмена", 
                            onClick: async (records) => { 
                                setAddingMessagePopupVisibility(false);
                            }
                        }
                    ]} />
            </Popup>
        </CardContainer>
    )
}